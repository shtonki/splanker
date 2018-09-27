using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace splanker
{
    class GameFrame : GameWindow
    {
        Room room = new Room();

        public GameFrame() : base(1024, 720, new GraphicsMode(32, 24, 0, 32))
        {
            
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Width, Height);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(Color.CornflowerBlue);
            GL.PushMatrix();

            foreach (var en in room.Entities)
            {
                GL.Begin(PrimitiveType.Quads);

                GL.Color4(Color.AliceBlue);

                var x = en.X;
                var y = en.Y;
                var w = 0.1;
                var h = 0.1;

                GL.Vertex2(x, y);
                GL.Vertex2(x, y+h);
                GL.Vertex2(x+w, y+h);
                GL.Vertex2(x+w, y);

                GL.End();
            }
            this.SwapBuffers();
            GL.PopMatrix();
        }
    }
}
