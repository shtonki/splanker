using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace splanker
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            launch();
        }

        public static void launch()
        {
            ManualResetEventSlim loadre = new ManualResetEventSlim();
            Thread t = new Thread(launchEx);
            t.Start(loadre);
            loadre.Wait();
        }

        private static void launchEx(object o)
        {
            ManualResetEventSlim loadre = (ManualResetEventSlim)o;
            var frame = new GameFrame();
            frame.Run(100, 0);
        }
    }
}
