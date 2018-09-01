using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace splanker
{
    class Room
    {
        public List<Entity> entities;

        public Room()
        {
            entities = new List<Entity>();

            var e = new Entity();
            entities.Add(e);
            e.X = 0.5f;
            e.Y = 0.5f;
        }
    }
}
