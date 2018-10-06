using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace splanker.src.util
{
    class InputUnion
    {
        public KeyboardKeyEventArgs KeyboardArgs { get; }

        public InputUnion(KeyboardKeyEventArgs keyboardArgs)
        {
            KeyboardArgs = keyboardArgs;
        }

        public override string ToString()
        {
            return KeyboardArgs.Key.ToString();
        }
    }


    class Hotkey
    {
        public Action DownAction { get; }
        public Action UpAction { get; }
    }
}
