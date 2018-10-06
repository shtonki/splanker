namespace splanker.src.state
{
    class GameState
    {
        public Room CurrentRoom { get; private set; }

        public GameState()
        {
            CurrentRoom = new Room();
        }

        public void Step()
        {
            CurrentRoom.Step();
        }
    }
}
