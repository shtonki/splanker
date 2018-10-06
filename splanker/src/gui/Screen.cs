using splanker.src.gui.GUIElements;
using splanker.src.util;
using System.Collections.Generic;
using splanker.src.state;

namespace splanker.src.gui
{
    static class ScreenController
    {
        public static Screen MainMenuScreen = GenerateMainMenu();

        private static Screen GenerateMainMenu()
        {
            var screen = new Screen();
            

            screen.guiElements.Add(new RectangularElement(
                new GLCoordinate(0, 0), 
                new GLCoordinate(0.2f, 0.2f)));

            return screen;
        }

        public static GameScreen GenerateGameScreen(GameState gs)
        {
            var screen = new GameScreen(gs);

            return screen;
        }
    }

    class Screen
    {
        /// <summary>
        /// Contains all the guiElements which are rendered to a frame.
        /// </summary>
        public List<IGUIElement> guiElements = new List<IGUIElement>();

        public virtual void HandleInput(InputUnion input)
        {
            Logging.DefaultLogger.Log(input);
        }

        /// <summary>
        /// Draws one frame of the screen.
        /// </summary>
        /// <param name="drawFacade">The DrawFacade provides an interface the screen can use to draw to the frame.</param>
        public virtual void Draw(DrawFacade drawFacade)
        {
            foreach (var guiElement in guiElements)
            {
                guiElement.Draw(drawFacade);
            }
        }

        public virtual void Step()
        {
        }
    }

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
