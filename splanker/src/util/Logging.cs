using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace splanker.src.util
{
    static class Logging
    {
        public static Logger DefaultLogger = new ConsoleLogger();
    }

    interface Logger
    {
        void Log(object debugpurposesonlyplease);
    }

    class ConsoleLogger : Logger
    {
        public void Log(object debugpurposesonlyplease)
        {
            Console.WriteLine("Logged: {0} at {1}", debugpurposesonlyplease, DateTime.Now);
        }
    }
}
