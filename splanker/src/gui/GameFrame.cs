using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using splanker.src.gui;
using splanker.src.util;

namespace splanker
{
    class GameFrame : GameWindow
    {

        private const int TheOnlyGamePadIndexWhichWillBeChecked = 0;

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

            HandleGamePad();

            CurrentScreen?.Step();
        }

        private GamePadState PreviousGamePadState;
        private void HandleGamePad()
        {
            var currentGamePadState = GamePad.GetState(TheOnlyGamePadIndexWhichWillBeChecked);
            if (currentGamePadState.IsConnected && PreviousGamePadState.IsConnected)
            {
                // DPad Left
                if (currentGamePadState.DPad.IsLeft)
                    CurrentScreen?.HandleInput(new InputUnion(PreviousGamePadState.DPad.IsLeft ? InputUnion.Directions.Repeat : InputUnion.Directions.Down, Buttons.DPadLeft));
                else if (PreviousGamePadState.DPad.IsLeft)
                    CurrentScreen?.HandleInput(new InputUnion(InputUnion.Directions.Up, Buttons.DPadLeft));

                // DPad Right
                if (currentGamePadState.DPad.IsRight)
                    CurrentScreen?.HandleInput(new InputUnion(PreviousGamePadState.DPad.IsRight ? InputUnion.Directions.Repeat : InputUnion.Directions.Down, Buttons.DPadRight));
                else if (PreviousGamePadState.DPad.IsRight)
                    CurrentScreen?.HandleInput(new InputUnion(InputUnion.Directions.Up, Buttons.DPadRight));

                // DPad Left
                if (currentGamePadState.DPad.IsDown)
                    CurrentScreen?.HandleInput(new InputUnion(PreviousGamePadState.DPad.IsDown ? InputUnion.Directions.Repeat : InputUnion.Directions.Down, Buttons.DPadDown));
                else if (PreviousGamePadState.DPad.IsDown)
                    CurrentScreen?.HandleInput(new InputUnion(InputUnion.Directions.Up, Buttons.DPadDown));

                // DPad Up
                if (currentGamePadState.DPad.IsUp)
                    CurrentScreen?.HandleInput(new InputUnion(PreviousGamePadState.DPad.IsUp ? InputUnion.Directions.Repeat : InputUnion.Directions.Down, Buttons.DPadUp));
                else if (PreviousGamePadState.DPad.IsUp)
                    CurrentScreen?.HandleInput(new InputUnion(InputUnion.Directions.Up, Buttons.DPadUp));

            }
            PreviousGamePadState = currentGamePadState;
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

        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            base.OnKeyDown(e);
            CurrentScreen?.HandleInput(new InputUnion(e.IsRepeat ? InputUnion.Directions.Repeat : InputUnion.Directions.Down, e));
        }

        protected override void OnKeyUp(KeyboardKeyEventArgs e)
        {
            base.OnKeyUp(e);
            CurrentScreen?.HandleInput(new InputUnion(InputUnion.Directions.Up, e));
        }


    }
}
