using splanker.src.util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace splanker.src.gui.GUIElements
{
    class RectangularElement : IGUIElement
    {
        public GLCoordinate Origin;
        public GLCoordinate Terminus;

        public RectangularElement(GLCoordinate origin, GLCoordinate terminus)
        {
            Origin = origin;
            Terminus = terminus;
        }

        public void Draw(DrawFacade drawFacade)
        {
            drawFacade.FillRectangle(Origin, Terminus, Color.Crimson);
        }
    }
}
