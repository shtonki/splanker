using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using splanker.src.gui;

namespace splanker
{
    class GameFrame : GameWindow
    {
        public Screen CurrentScreen { get; set; }

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

            if (CurrentScreen != null)
            {
                DrawFacade drawFacade = new DrawFacade();

                CurrentScreen.Draw(drawFacade);
            }

            SwapBuffers();
            GL.PopMatrix();
        }
    }
}
