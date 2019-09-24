using splanker.src.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace splanker.src.gui
{
    /// <summary>
    /// Exposes graphics functions from a GameFrame
    /// </summary>
    class DrawFacade
    {
        public void DrawSprite(Sprite sprite)
        {
            throw new NotImplementedException();
        }

        public void FillRectangle(GLCoordinate origin, GLCoordinate terminus, Color color)
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Color4(color);

            /*
             *             origin.X        terminus.X
             *   origin.Y  1---------------4
             *             |               |
             *             |               |
             * terminus.Y  2---------------3
             * 
             */

            GL.Vertex2(origin.X  , origin.Y);       // 1
            GL.Vertex2(origin.X  , terminus.Y);     // 2
            GL.Vertex2(terminus.X, terminus.Y);     // 3
            GL.Vertex2(terminus.X, origin.Y);       // 4

            GL.End();
        }

        public void DrawLine(GLCoordinate origin, GLCoordinate terminus, Color color)
        {
            GL.Begin(PrimitiveType.LineLoop);

            GL.Color4(color);
            GL.Vertex2(origin.X, origin.Y);
            GL.Vertex2(terminus.X, terminus.Y);

            GL.End();
        }
    }
}
