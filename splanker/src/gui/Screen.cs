using splanker.src.gui.GUIElements;
using splanker.src.util;
using System.Collections.Generic;
using splanker.src.state;
using splanker.src.gui.screens;

namespace splanker.src.gui
{
    static class ScreenController
    {
        public static Screen MainMenuScreen = new MainMenuScreen();

        public static GameScreen GenerateGameScreen(GameState gs)
        {
            var screen = new GameScreen(gs);

            return screen;
        }
    }

    abstract class Screen
    {

        /// <summary>
        /// Contains all the guiElements which are rendered to a frame
        /// </summary>
        public List<IGUIElement> guiElements = new List<IGUIElement>();

        protected List<HotkeyMapping> Keybindings { get; } = new List<HotkeyMapping>();

        public virtual void HandleInput(InputUnion input)
        {
            Logging.DefaultLogger.Log(input);

            foreach (var keybinding in Keybindings)
            {
                keybinding.tickle(input);
            }
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

    
}
