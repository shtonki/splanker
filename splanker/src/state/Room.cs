using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace splanker
{
    class Room
    {
        public Entities Entities { get; } = new Entities();

        public Room()
        {
        }

    }

    /// <summary>
    /// Class which acts as a container class for the set of
    /// Entities in a room.
    /// </summary>
    class Entities : IEnumerable<Entity>
    {
        private List<Entity> EntityList = new List<Entity>();

        /// <summary>
        /// Adds an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <todo> Callbacks </todo>
        public void Add(Entity entity)
        {
            EntityList.Add(entity);
        }

        public IEnumerator<Entity> GetEnumerator()
        {
            return EntityList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return EntityList.GetEnumerator();
        }
    }
}
