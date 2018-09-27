using splanker.src.gui;
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
        /// Launches the application
        /// </summary>
        public static void Launch()
        {
            Thread guiThread = new Thread(LaunchGUI);
            guiThread.Start();
        }

        /// <summary>
        /// Help function to Launch
        /// <param name="o"></param>
        private static void LaunchGUI()
        {
            var frame = new GameFrame();
            frame.CurrentScreen = ScreenController.MainMenuScreen;
            frame.Run(100, 0);
        }
    }
}
