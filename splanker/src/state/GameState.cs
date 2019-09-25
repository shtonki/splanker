using System;
using splanker.src.gui;
using splanker.src.gui.GUIElements;
using splanker.src.util;

namespace splanker.src.state
{
    class GameState
    {
        public Hero Hero { get; }

        public Room CurrentRoom { get; private set; }
        NextTurnButton ntb = new NextTurnButton();

        public GameState()
        {
            CurrentRoom = new StartingRoom();
            Hero = new Hero();
            Hero.Location = new GameCoordinate(0.2f, 0.2f);
            Hero.Size = new GameCoordinate(0.1f, 0.1f);
            CurrentRoom.Add(Hero);
     
            ntb.Location = new GameCoordinate(0.8f, 0.8f);
            Console.WriteLine("NTB: " + ntb.Location.X);
            ntb.Size = new GameCoordinate(0.2f, 0.2f);
            Console.WriteLine("NTB: " + ntb.Location.X);
            CurrentRoom.Add(ntb);
        }

        public void GameStep()
        {
            Hero.GameStep();
        }

        public void Step()
        {
            CurrentRoom.Step(); 
        }
    }
}
