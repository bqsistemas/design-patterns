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
    public sealed class SingletonLazyOfT
    {
        // reading this will initialize the instance
        public static readonly Lazy<SingletonLazyOfT> _lazy = new Lazy<SingletonLazyOfT>(() => new SingletonLazyOfT());
        public static SingletonLazyOfT Instance
        {
            get
            {
                Logger.Log("Instance called.");
                return _lazy.Value;
            }
        }

        private SingletonLazyOfT()
        {
            // cannot be created except within this class
            Logger.Log("Constructor invoked.");
        }
    }
}
