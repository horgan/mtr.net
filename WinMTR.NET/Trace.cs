using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;
using System.Net.NetworkInformation;
using System.Collections;
using System.Windows.Forms;

namespace WinMTR.NET
{
    /// <summary>
    /// 
    /// </summary>
    public class RouteEntry
    {
        public IPAddress Address { get; set; }
        public bool IsNull { get; set; }
        public int TTL { get; set; }
        public string HostName { get; set; }
        public string Text { get; set; }
        public long LastRoundTrip { get; set; }
        public long AvgRoundTrip { get; set; }
        public long BestRoundTrip { get; set; }
        public long WorstRoundTrip { get; set; }
        public long SentPings { get; set; }
        public long RecvPings { get; set; }
        public float Loss { get; set; }

        public List<long> Records { get; set; }

        public string Location { get; set; }

        public RouteEntry()
        {
            BestRoundTrip = Int64.MaxValue;
            WorstRoundTrip = 0;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class RouteCollection : Dictionary<IPAddress, RouteEntry>
    {

    }

    /// <summary>
    /// 
    /// </summary>
    public enum TraceEventType
    {
        PingSend,
        PingRecv,
        PingStopped
    }

    /// <summary>
    /// 
    /// </summary>
    public class TraceEventArgs : EventArgs
    {
        public TraceEventType TraceEventType { get; private set; }
        public TraceEventArgs(TraceEventType traceEventType)
        {
            TraceEventType = traceEventType;
        }

    }

    public class Trace : IDisposable
    {
        public class TracePingRun
        {
            public Trace Trace { get; private set; }
            public IPAddress Address { get; private set; }
            public IPHostEntry IPHostEntry { get; set; }

            public TracePingRun(Trace trace, IPAddress address)
            {
                Trace = trace;
                Address = address;
            }
        }

        public delegate void TraceEventHandler(object sender, TraceEventArgs e);
        public event TraceEventHandler TraceEvent;

        private Trace()
        {

        }

        //public RouteCollection Route { get; private set; }
        public List<RouteEntry> Route { get; private set; }
        public IPAddress Address { get; private set; }
        public int PingTimeout { get; private set; }
        public int PingTimeFrame { get; private set; }
        public bool ResolveNames { get; private set; }
        public int PingSize { get; private set; }
        public int MaxHops{ get; private set; }



        private Stack RunningThreads = new Stack();


        public Trace(IPAddress address)
            : this(address, 100, 1000, false, 64, 30)
        {

        }

        public Trace(IPAddress address, int pingTimeout, int pingTimeFrame, bool resolveNames, int pingSize, int maxHops)
        {
            Address = address;
            PingTimeout = pingTimeout;
            PingTimeFrame = pingTimeFrame;
            Route = new List<RouteEntry>();
            ResolveNames = resolveNames;
            PingSize = pingSize;
            MaxHops = maxHops;
        }

        public static byte[] MakeByteArray(int length)
        {
            byte[] byteData = new byte[length];
            for (int i = 0; i < byteData.Length; i++)
            {
                byteData[i] = 0x65;
            }
            return byteData;
        }

        public void Start()
        {
            run = true;
            new Thread(TraceRun).Start(this);
        }

        public void Stop()
        {
            run = false;
        }

        public void OnTraceEvent(TraceEventType tet)
        {
            if (TraceEvent != null)
            {
                TraceEvent(this, new TraceEventArgs(tet));
            }

        }

        volatile bool run = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public static void TraceRun(object data)
        {
            if (!(data is Trace))
                return;
            Trace trace = (Trace)data;

            byte[] byteData = MakeByteArray(trace.PingSize);

            PingOptions pingOptions = new PingOptions(1, false);
            Ping ping = new Ping();
            bool run = true;
            int lastTtl = 1;


            while (run && trace.run && lastTtl <= trace.MaxHops)
            {

                pingOptions = new PingOptions(lastTtl, false);
                PingReply pingReply = ping.Send(trace.Address, trace.PingTimeout, byteData, pingOptions);



                if (pingReply.Address != null)
                {
                    run = !pingReply.Address.Equals(trace.Address);
                    lock (trace.Route)
                    {

                        if (null == trace.Route.Find(delegate(RouteEntry re_) { return re_.Address.ToString() == pingReply.Address.ToString(); }))
                        {
                            RouteEntry re = new RouteEntry();
                            re.Address = pingReply.Address;
                            re.IsNull = false;
                            re.TTL = lastTtl;
                            re.Location = "";
                            re.Records = new List<long>();
                            trace.Route.Add(re);
                        }
                        //t.OnTraceEvent(TraceEventType.PingSend);
                    }
                    trace.PingHost(pingReply.Address);
                    Thread.Sleep(1);

                    lastTtl++;
                }
                else
                {
                    if (pingReply.Status == IPStatus.TimedOut )
                    {
                        lastTtl++;

                        lock (trace.Route)
                        {


                            //if (!trace.Route.ContainsKey(trace.Address))
                            if (trace.Route.Count < lastTtl)
                            {
                                RouteEntry re = new RouteEntry();
                                re.Loss = 1;
                                re.Text = "N/A";
                                re.Address = IPAddress.Any;
                                re.TTL = lastTtl - 1;
                                re.IsNull = true;
                                trace.Route.Add(re);

                            }
                        }

                    }
                    //Console.WriteLine("Tracing reply status {0}", pingReply.Status);
                }

            }

        }

        public void PingHost(IPAddress address)
        {
            Thread pingRunThread = new Thread(PingRun);
            RunningThreads.Push(pingRunThread);
            pingRunThread.Start(new TracePingRun(this, address));

            //RouteEntry re = Route.Find(delegate (RouteEntry re_) { return re_.Address == address; });
            //if (re != null && re.Location.Length == 0)
            //{
            //    Thread LocationRunThread = new Thread(LocationRun);
            //    LocationRunThread.Start(new TracePingRun(this, address));
            //}
        }

        private volatile int numThreads;
        private int NumThreads
        {
            get { return numThreads; }
            set
            {
                numThreads = value;
                if (numThreads == 0)
                    OnTraceEvent(TraceEventType.PingStopped);
            }
        }

        public static object LocationRunLock = new object();
        public static void LocationRun(object data)
        {
            if (!(data is TracePingRun))
                return;
            TracePingRun tracePingRun = (TracePingRun)data;

            RouteEntry re = tracePingRun.Trace.Route.Find(delegate (RouteEntry re_) { return re_.Address == tracePingRun.Address; });
            if (re == null) return;
         
            {
                lock (LocationRunLock)
                {
                    if (tracePingRun.Address != null && tracePingRun.Address.ToString().Length > 0)
                    {
                        string content = HttpHelper.HttpGet("http://ip.taobao.com//service/getIpInfo.php?ip=" + tracePingRun.Address.ToString(), "utf-8", "text");
                        if (content.Length > 0)
                        {
                            var obj = fastJSON.JSON.ToObject<TaobaoIPJson>(content);
                            string Location = obj.data.country + " " + obj.data.region + " " + obj.data.city + " " + obj.data.isp;
                            re.Location = Location;
                        }
                    }
                    Thread.Sleep(100);
                }     
            }
        }

        public static void PingRun(object data)
        {

            if (!(data is TracePingRun))
                return;
            TracePingRun tracePingRun = (TracePingRun)data;
            tracePingRun.Trace.numThreads++;
            byte[] byteData = MakeByteArray(tracePingRun.Trace.PingSize);


            if (tracePingRun.Trace.ResolveNames)
                Dns.BeginGetHostEntry(tracePingRun.Address, ReverseCallback, tracePingRun);



            PingOptions pingOptions = new PingOptions(1, false);
            Ping ping = new Ping();
            while (tracePingRun.Trace.run)
            {
                lock (tracePingRun.Trace.Route)
                {
                    //if (tracePingRun.Trace.Route.ContainsKey(tracePingRun.Address))
                    {
                        //RouteEntry re = tracePingRun.Trace.Route[tracePingRun.Address];
                        RouteEntry re = tracePingRun.Trace.Route.Find(delegate(RouteEntry re_) { return re_.Address == tracePingRun.Address; });
                        if (re != null)
                        {
                            re.SentPings++;
                        }
                    }
                }

                if (!tracePingRun.Trace.run)
                    return;


                PingReply pingReply = ping.Send(tracePingRun.Address, tracePingRun.Trace.PingTimeout);

                lock (tracePingRun.Trace.Route)
                {
                    //if (tracePingRun.Trace.Route.ContainsKey(tracePingRun.Address))
                    {
                        //RouteEntry routeEntry = tracePingRun.Trace.Route[tracePingRun.Address];
                        RouteEntry routeEntry = tracePingRun.Trace.Route.Find(delegate(RouteEntry re_) { return re_.Address.ToString() == tracePingRun.Address.ToString(); });
                        routeEntry.AvgRoundTrip = (routeEntry.AvgRoundTrip + pingReply.RoundtripTime) / 2;
                        routeEntry.LastRoundTrip = pingReply.RoundtripTime;
                        routeEntry.Records.Add(pingReply.RoundtripTime);
                        if (routeEntry.Records.Count > 500)
                        {
                            routeEntry.Records.RemoveRange(0, routeEntry.Records.Count - 500);
                        }
                        if (pingReply.Status == IPStatus.Success)
                        {
                            routeEntry.BestRoundTrip = Math.Min(routeEntry.LastRoundTrip, routeEntry.BestRoundTrip);
                            routeEntry.WorstRoundTrip = Math.Max(routeEntry.LastRoundTrip, routeEntry.WorstRoundTrip);
                            routeEntry.RecvPings++;

                            if (tracePingRun.IPHostEntry != null)
                                routeEntry.HostName = tracePingRun.IPHostEntry.HostName;
                        }
                        if (routeEntry.SentPings < routeEntry.RecvPings)
                        {
                            //localhost?
                            routeEntry.Loss = 0;
                            routeEntry.RecvPings = routeEntry.SentPings;
                        }
                        else
                        {
                            routeEntry.Loss = ((float)(routeEntry.SentPings - routeEntry.RecvPings) / routeEntry.SentPings);
                        }

                        if (routeEntry.Address != null && routeEntry.Address.ToString().Length > 0 && routeEntry.Location.Length < 1)
                        {
                            var location = IPLocationSearch.GetIPLocation(tracePingRun.Address.ToString());
                            routeEntry.Location = location.country + location.area;
                            routeEntry.Location = routeEntry.Location.Replace("CZ88.NET", String.Empty);
                        }

                        tracePingRun.Trace.OnTraceEvent(TraceEventType.PingRecv);
                    }
                }
                Thread.Sleep(tracePingRun.Trace.PingTimeFrame);
            }
            tracePingRun.Trace.numThreads--;
        }

        private static void ReverseCallback(IAsyncResult r)
        {
            try
            {
                IPHostEntry ihe = Dns.EndGetHostEntry(r);
                TracePingRun tpr = (TracePingRun)r.AsyncState;
                tpr.IPHostEntry = ihe;

            }
            catch { }
        }

        #region IDisposable Members

        public void Dispose()
        {
            run = false;

        }



        #endregion
    }
}
