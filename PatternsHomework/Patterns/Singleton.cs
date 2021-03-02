using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatternsHomework.Patterns
{
    class Singleton
    {
        private Singleton()
        {
        }

        private static Singleton _instance;

        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }

            return _instance;
        }

        public static void someBusinessLogic()
        {
            // ...
        }
    }
}
