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
    public sealed class SingletonBetterLocking
    {
        private static SingletonBetterLocking _instance = null;
        private static readonly object padlock = new object();

        public static SingletonBetterLocking Instance
        {
            get
            {
                Logger.Log("Instance called.");
                if (_instance == null) // only get a lock if the instance is null
                {
                    lock (padlock)
                    {
                        if (_instance == null)
                        {
                            _instance = new SingletonBetterLocking();
                        }
                    }
                }
                return _instance;
            }
        }

        private SingletonBetterLocking()
        {
            // cannot be created except within this class
            Logger.Log("Constructor invoked.");
        }
    }
}
