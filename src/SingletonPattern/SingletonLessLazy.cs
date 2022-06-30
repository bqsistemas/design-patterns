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
    public sealed class SingletonLessLazy
    {
        private static readonly SingletonLessLazy _instance = new SingletonLessLazy();

        // reading this will initialize the _instance
        public static readonly string GREETING = "Hi!";

        // Tell C# compiler not to mark type as beforefieldinit
        // (https://csharpindepth.com/articles/BeforeFieldInit)
        static SingletonLessLazy()
        {
        }

        public static SingletonLessLazy Instance
        {
            get
            {
                Logger.Log("Instance called.");
                return _instance;
            }
        }

        private SingletonLessLazy()
        {
            // cannot be created except within this class
            Logger.Log("Constructor invoked.");
        }
    }
}
