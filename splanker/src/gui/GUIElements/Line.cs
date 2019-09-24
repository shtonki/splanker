using System.Drawing;
using splanker.src.util;

namespace splanker.src.gui.GUIElements
{
    class Line : IGUIElement
    {
        public GLCoordinate Origin;
        public GLCoordinate Terminus;

        public Line(GLCoordinate origin, GLCoordinate terminus)
        {
            Origin = origin;
            Terminus = terminus;
        }

        public void Draw(DrawFacade drawFacade)
        {
            drawFacade.DrawLine(Origin, Terminus, Color.BlueViolet);
        }
    }
}
