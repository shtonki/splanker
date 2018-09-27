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
            Launch();
        }

        /// <summary>
        /// Launces the application
        /// </summary>
        public static void Launch()
        {
            Thread t = new Thread(LaunchGUI);
            t.Start();
        }

        /// <summary>
        /// Help function to Launch
        /// <param name="o"></param>
        private static void LaunchGUI()
        {
            var frame = new GameFrame();
            frame.Run(100, 0);
        }
    }
}
