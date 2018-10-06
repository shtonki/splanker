using OpenTK.Input;
using System;

namespace splanker.src.util
{
    class InputUnion
    {
        public enum Directions { Undefined, Up, Down, Repeat };
        public Directions Direction { get; }

        public KeyboardKeyEventArgs KeyboardArgs { get; }
        public bool IsKeyboardInput => KeyboardArgs != null;

        public InputUnion(Directions direction, KeyboardKeyEventArgs keyboardArgs)
        {
            Direction = direction;
            KeyboardArgs = keyboardArgs;
        }

        public override string ToString()
        {
            return KeyboardArgs.Key.ToString();
        }
    }

    /// <summary>
    /// A class which maps an InputUnion to a callback
    /// </summary>
    class HotkeyMapping
    {
        private Func<InputUnion, bool> Filter { get; }
        private Action<InputUnion> Callback { get; }

        public HotkeyMapping(Func<InputUnion, bool> filter, Action<InputUnion> callback)
        {
            this.Filter = filter;
            this.Callback = callback;
        }

        /// <summary>
        /// Filters the input and if it makes it through the filter
        /// a callback ensues
        /// </summary>
        /// <param name="input">The input to be filtered and subsequently provided to the callback</param>
        public void tickle(InputUnion input)
        {
            if (Filter(input))
            {
                Callback(input);
            }
        }
    }
}
