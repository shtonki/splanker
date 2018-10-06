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
        public List<GUIElement> guiElements = new List<GUIElement>();

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
            GameState.Step();
        }
    }
}
