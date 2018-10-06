﻿using OpenTK.Input;
using System;

namespace splanker.src.util
{
    class InputUnion
    {
        public enum Directions { Undefined, Up, Down, Repeat };
        public Directions Direction { get; }

        public KeyboardKeyEventArgs KeyboardArgs { get; }
        public bool IsKeyboardInput => KeyboardArgs != null;

        public Buttons? GamePadButtonArgs { get; }
        public bool IsGamePadInput => GamePadButtonArgs != null;

        public InputUnion(Directions direction, KeyboardKeyEventArgs keyboardArgs)
        {
            Direction = direction;
            KeyboardArgs = keyboardArgs;
        }

        public InputUnion(Directions direction, Buttons gamePadButtonArgs)
        {
            Direction = direction;
            GamePadButtonArgs = gamePadButtonArgs;
        }

        public override string ToString()
        {
            if (IsKeyboardInput)
            {
                return KeyboardArgs.Key.ToString();
            }
            if (IsGamePadInput)
            {
                return GamePadButtonArgs.ToString();
            }

            return "Failed to stringify InputUnion";
        }
    }

    /// <summary>
    /// A class which maps an InputUnion to a callback
    /// </summary>
    class HotkeyMapping
    {
        public delegate void HotkeyCallback(InputUnion input);
        public delegate bool HotkeyFilter(InputUnion input);

        private HotkeyFilter Filter { get; }
        private HotkeyCallback Callback { get; }

        public HotkeyMapping(HotkeyFilter filter, HotkeyCallback callback)
        {
            this.Filter = filter;
            this.Callback = callback;
        }

        /// <summary>
        /// Filters the input and if it makes it through the filter
        /// a callback ensues
        /// </summary>
        /// <param name="input">The input to be filtered and subsequently provided to the callback</param>
        public void Tickle(InputUnion input)
        {
            if (Filter(input))
            {
                Callback(input);
            }
        }

    }

    class Hotkey
    {
        public HotkeyMapping Activate { get; }
        public HotkeyMapping Deactivate { get; }

        public Hotkey(
            HotkeyMapping.HotkeyFilter filter,
            HotkeyMapping.HotkeyCallback activate,
            HotkeyMapping.HotkeyCallback deactivate
            )
        {
            Activate = new HotkeyMapping(input => 
                filter(input) && input.Direction == InputUnion.Directions.Down, activate);
            Deactivate = new HotkeyMapping(input =>
                filter(input) && input.Direction == InputUnion.Directions.Up, deactivate);
        }
    }
}
