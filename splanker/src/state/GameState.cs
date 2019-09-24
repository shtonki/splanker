using splanker.src.util;

namespace splanker.src.state
{
    class GameState
    {
        public Entity Hero { get; }

        public Room CurrentRoom { get; private set; }

        public GameState()
        {
            CurrentRoom = new StartingRoom();
            Hero = new Entity();
            Hero.Location = new GameCoordinate(0.2f, 0.2f);
            Hero.Size = new GameCoordinate(0.1f, 0.1f);
            CurrentRoom.Add(Hero);

        }

        public void Step()
        {
            CurrentRoom.Step();
        }
    }
}
