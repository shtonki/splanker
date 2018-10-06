using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace splanker.src.gui
{
    interface IGUIElement
    {
        void Draw(DrawFacade drawFacade);
    }
}
