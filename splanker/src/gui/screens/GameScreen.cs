
using splanker.src.state;

namespace splanker.src.gui.screens
{
    class GameScreen : Screen
    {
        public GameState GameState { get; }

        public GameScreen(GameState gameState)
        {
            GameState = gameState;
        }

        public override void Draw(DrawFacade drawFacade)
        {
            base.Draw(drawFacade);
            foreach (var entity in GameState.CurrentRoom.Entities)
            {
                entity.Draw(drawFacade);
            }

        }

        public override void Step()
        {
            base.Step();
            GameState.Step();
        }
    }
}
