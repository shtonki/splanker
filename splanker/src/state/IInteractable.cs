using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using splanker.src.state;

namespace splanker.src.gui
{
    interface IInteractable
    {
        void Interact(GameState gs);
    }
}
