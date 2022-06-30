using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Logging;


namespace SingletonPattern
{
    // Bad code
#nullable enable // after or equal c# 8.0
    public sealed class SingletonLocking
    {
        private static SingletonLocking _instance = null;
        private static readonly object padlock = new object();

        public static SingletonLocking Instance
        {
            get
            {
                Logger.Log("Instance called.");
                lock (padlock) // this lock is used on *every* reference to Singleton
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonLocking();
                    }
                    return _instance;
                }
            }
        }

        private SingletonLocking()
        {
            // cannot be created except within this class
            Logger.Log("Constructor invoked.");
        }
    }
}
