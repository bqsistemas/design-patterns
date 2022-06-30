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
    public sealed class SingletonNaive
    {
        private static SingletonNaive? _instance;
        public static SingletonNaive Instance
        {
            get
            {
                Logger.Log("Instance called.");
                #region before c# 8.0
                /* 
                 if (_instance == null)
                 {
                     _instance = new Singleton();
                 }
                 return _instance;
                */
                #endregion
                #region after or equal c# 8.0 - current implementation
                return _instance ??= new SingletonNaive();
                #endregion
            }
        }
        private SingletonNaive()
        {
            Logger.Log("Constructor invoked.");
        }
    }
}
