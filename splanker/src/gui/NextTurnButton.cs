using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using splanker.src.state;
using splanker.src.util;

namespace splanker.src.gui.GUIElements
{
    class NextTurnButton : Entity, IInteractable
    {
        private bool interacted = false;

        public void Interact(GameState gs)
        {
            if (Color == Color.Red) Color = Color.Green;
            else Color = Color.Red;

            gs.GameStep();
        }


        public override void Step()
        {
            base.Step();
        }
    }
}
