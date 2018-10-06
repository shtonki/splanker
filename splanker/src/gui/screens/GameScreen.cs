
using splanker.src.state;
using splanker.src.util;
using System;

namespace splanker.src.gui.screens
{
    class GameScreen : Screen
    {
        public GameState GameState { get; }

        public GameScreen(GameState gameState)
        {
            GameState = gameState;

            // Keyboard

            Bind(new Hotkey(
                input => input.IsKeyboardInput && input.KeyboardArgs.Key == OpenTK.Input.Key.D,
                _ => GameState.Hero.Speed.X = 0.01f,
                _ => GameState.Hero.Speed.X = 0
                ));

            Bind(new Hotkey(
                input => input.IsKeyboardInput && input.KeyboardArgs.Key == OpenTK.Input.Key.A,
                _ => GameState.Hero.Speed.X = -0.01f,
                _ => GameState.Hero.Speed.X = 0
                ));

            Bind(new Hotkey(
                input => input.IsKeyboardInput && input.KeyboardArgs.Key == OpenTK.Input.Key.W,
                _ => GameState.Hero.Speed.Y = 0.01f,
                _ => GameState.Hero.Speed.Y = 0
                ));

            Bind(new Hotkey(
                input => input.IsKeyboardInput && input.KeyboardArgs.Key == OpenTK.Input.Key.S,
                _ => GameState.Hero.Speed.Y = -0.01f,
                _ => GameState.Hero.Speed.Y = 0
                ));

            // Game Pad

            Bind(new Hotkey(
                input => input.IsGamePadInput && input.GamePadButtonArgs == OpenTK.Input.Buttons.DPadLeft,
                _ => GameState.Hero.Speed.X = -0.01f,
                _ => GameState.Hero.Speed.X = 0
                ));

            Bind(new Hotkey(
                input => input.IsGamePadInput && input.GamePadButtonArgs == OpenTK.Input.Buttons.DPadRight,
                _ => GameState.Hero.Speed.X = 0.01f,
                _ => GameState.Hero.Speed.X = 0
                ));

            Bind(new Hotkey(
                input => input.IsGamePadInput && input.GamePadButtonArgs == OpenTK.Input.Buttons.DPadUp,
                _ => GameState.Hero.Speed.Y = 0.01f,
                _ => GameState.Hero.Speed.Y = 0
                ));

            Bind(new Hotkey(
                input => input.IsGamePadInput && input.GamePadButtonArgs == OpenTK.Input.Buttons.DPadDown,
                _ => GameState.Hero.Speed.Y = -0.01f,
                _ => GameState.Hero.Speed.Y = 0
                ));
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
            base.Step();
            GameState.Step();
        }

        public void Bind(Hotkey hotkey)
        {
            Keybindings.Add(hotkey.Activate);
            Keybindings.Add(hotkey.Deactivate);
        }

        public void Unbind(Hotkey hotkey)
        {
            // this can't be done because the old keybindings are sort of just
            // hanging out in empty space with no way of identifying what is what
            // so you have no clue what to unbind.
            throw new NotImplementedException("you're fucked");
        }
    }
}
