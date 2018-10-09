using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinMTR
{
    public class Singleton<T> where T : new()
    {
        Singleton() { }

        class SingletonCreator
        {
            static SingletonCreator() { }
            internal static readonly T instance = new T();
        }

        public static T Instance
        {
            get { return SingletonCreator.instance; }
        }

    }
}
