using splanker.src.gui.GUIElements;
using splanker.src.util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }

    class Screen
    {
        public List<GUIElement> guiElements = new List<GUIElement>();

        public void Draw(DrawFacade drawFacade)
        {
            foreach (var guiElement in guiElements)
            {
                guiElement.Draw(drawFacade);
            }
        }
    }
}
