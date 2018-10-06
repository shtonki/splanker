namespace splanker.src.state
{
    class GameState
    {
        public Entity Hero { get; }

        public Room CurrentRoom { get; private set; }

        public GameState()
        {
            CurrentRoom = new Room();

            Hero = new Entity();
        }

        public void Step()
        {
            CurrentRoom.Step();
        }
    }
}
