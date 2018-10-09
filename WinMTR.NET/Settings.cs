using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace WinMTR
{
    public interface ISettings
    {
    }
    public class Settings<T> where T : ISettings, new()
    {

        public const string DEFAULT_FILENAME = "Settings.xml";

        public static string GetDefaultFilename()
        {
            return GetDefaultFilename(DEFAULT_FILENAME);
        }
        public static string GetDefaultFilename(string filename)
        {
            FileInfo fi = new FileInfo(new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase).LocalPath);
            string settFn = fi.Directory.FullName + @"\" + filename;
            return settFn;
        }

        public readonly string Filename;



        private XmlSerializer xmlSerializer = null;

        public T SettingsObject { get; private set; }





        public Settings()
            : this(DEFAULT_FILENAME, false)
        {

        }

        public Settings(string filename)
            : this(filename, true)
        {

        }

        public Settings(string filename, bool isFullPath)
        {

            if (!isFullPath)
            {
                Filename = GetDefaultFilename(filename);
            }
            else
            {
                Filename = filename;
            }


            SettingsObject = new T();
            xmlSerializer = new XmlSerializer(typeof(T));
            Load();
        }


        public static Settings<T> Instance
        {
            get { return Singleton<Settings<T>>.Instance; }
        }





        public void Save()
        {

            FileStream fs = new FileStream(Filename, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
            fs.SetLength(0);
            xmlSerializer.Serialize(fs, SettingsObject);
            fs.Close();
        }

        public void Load()
        {
            if (!File.Exists(Filename))
            {
                return;
            }

            FileStream fs = new FileStream(Filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            SettingsObject = (T)xmlSerializer.Deserialize(fs);
            fs.Close();
        }




    }
}
