using splanker.src.gui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using splanker.src.state;
using splanker.src.util;
using splanker.src.Network;
using System.Net.NetworkInformation;
using System.Globalization;

namespace splanker
{
    internal class Program
    {
        /// <summary>
        /// The frequency in Hz that GameFrame.OnUpdateFrame gets called and 
        /// subsequently the tickrate for Screen.Update
        /// </summary>
        public const int OpenGLUpdateFrequency = 100;

        public const bool RunDebugNonsense = false;

        public static void DebugNonsense(string[] args)
        {
            var gameConnection = new GameConnection();
            gameConnection.Connect();
        }


        private static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            if (RunDebugNonsense)
            {
                DebugNonsense(args);
            }

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
            GameState gameState = new GameState();

            //frame.CurrentScreen = ScreenController.MainMenuScreen;
            frame.CurrentScreen = ScreenController.GenerateGameScreen(gameState);
            frame.Run(OpenGLUpdateFrequency, 0);
        }
    }
}
