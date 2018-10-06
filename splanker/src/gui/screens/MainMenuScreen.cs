using splanker.src.gui.GUIElements;
using splanker.src.util;

namespace splanker.src.gui.screens
{
    class MainMenuScreen : Screen
    {
        public MainMenuScreen()
        {
            guiElements.Add(new RectangularElement(
                new GLCoordinate(0, 0),
                new GLCoordinate(0.2f, 0.2f)));
        }

    }
}
