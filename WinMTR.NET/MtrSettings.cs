using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinMTR.NET
{

    public class MtrSettingsClass : ISettings
    {
        public List<string> SavedHosts{ get; set; }
        public int Interval { get; set; }
        public int PingSize{ get; set; }
        public bool ResolveNames{ get; set; }
        public int MaxLRUHosts{ get; set; }
        public int MaxHops { get; set; }
        public int MaxTimeout{ get; set; }

        public MtrSettingsClass():base()
        {

            if (SavedHosts == null)
            {
                SavedHosts = new List<string>();

            }

            Interval = 1000;
            PingSize = 64;
            ResolveNames = false;
            MaxHops = 30;
            MaxTimeout = 1000;


        }
    }

    public class MtrSettings : Settings<MtrSettingsClass>
    {
    }
}
