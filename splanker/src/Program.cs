using splanker.src.gui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using splanker.src.state;
using splanker.src.util;

namespace splanker
{
    internal class Program
    {
        /// <summary>
        /// The frequency in Hz that GameFrame.OnUpdateFrame gets called and 
        /// subsequently the tickrate for Screen.Update
        /// </summary>
        public const int OpenGLUpdateFrequency = 100;


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
            GameState gameState = new GameState();
            Entity e1 = gameState.Hero;
            e1.Location = new GameCoordinate(0.2f, 0.2f);
            Entity e2 = new Entity();
            e1.Location = new GameCoordinate(0.7f, 0.7f);
            gameState.CurrentRoom.Entities.Add(e1);
            gameState.CurrentRoom.Entities.Add(e2);


            frame.CurrentScreen = ScreenController.MainMenuScreen;
            frame.CurrentScreen = ScreenController.GenerateGameScreen(gameState);
            frame.Run(OpenGLUpdateFrequency, 0);
        }
    }
}
