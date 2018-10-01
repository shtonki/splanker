using splanker.src.util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using splanker.src.gui;

namespace splanker
{
    class Entity
    {
        public GameCoordinate Location { get; set; } = new GameCoordinate(0, 0);
        public GameCoordinate Speed { get; set; } = new GameCoordinate(0, 0);

        public void Draw(DrawFacade drawFacade)
        {
            drawFacade.FillRectangle(new GLCoordinate(Location.X, Location.Y), new GLCoordinate(Location.X+0.2f, Location.Y+0.2f), Color.MediumAquamarine);
        }

        public void Step()
        {
            Location += Speed;
        }
    }
}
