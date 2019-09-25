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
        public GameCoordinate Size { get; set; } = new GameCoordinate(0.01f, 0.01f);
        public GameCoordinate Speed { get; set; } = new GameCoordinate(0, 0);
        public System.Drawing.Color Color { get; set; } = Color.Aquamarine;

        public Entity()
        {

        }

        public Entity(GameCoordinate location)
        {
            this.Location = location;
        }

        public virtual void Draw(DrawFacade drawFacade)
        {
            drawFacade.FillRectangle(
                new GLCoordinate(Location.X, Location.Y),
                new GLCoordinate(Location.X + Size.X, Location.Y + Size.Y),
                Color);
        }

        public virtual bool Contains(GameCoordinate coordinate)
        {
            if (Location.X < coordinate.X && Location.X + Size.X > coordinate.X &&
                Location.Y < coordinate.Y && Location.Y + Size.Y > coordinate.Y)
                return true;
            return false;
        }

        public virtual void Step()
        {
            Location += Speed;
        }
    }
}
