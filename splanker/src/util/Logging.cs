using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace splanker.src.util
{
    static class Logging
    {
        public static ILogger DefaultLogger = new ConsoleLogger();
    }

    interface ILogger
    {
        void Log(object debugpurposesonlyplease);
    }

    class ConsoleLogger : ILogger
    {
        public void Log(object debugpurposesonlyplease)
        {
            Console.WriteLine("Logged: {0} at {1}", debugpurposesonlyplease, DateTime.Now);
        }
    }
}
