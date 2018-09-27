using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace splanker.src.gui
{
    interface GUIElement
    {
        void Draw(DrawFacade drawFacade);
    }
}
