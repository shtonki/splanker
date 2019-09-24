using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace splanker.src.state
{

    class Entities : IEnumerable<Entity>
    {
        private List<Entity> EntityList = new List<Entity>();

        public void Add(Entity entity)
        {
            EntityList.Add(entity);
        }

        public void Remove(Entity entity)
        {
            EntityList.Remove(entity);
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
