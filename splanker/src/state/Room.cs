using System;
using System.Collections;
using System.Collections.Generic;
using splanker.src.gui;
using splanker.src.gui.GUIElements;
using splanker.src.state;

namespace splanker
{
    abstract class Room
    {
        protected Entities entities { get; set; }
        protected List<IGUIElement> elements { get; set; }

        public void Step()
        {
            foreach (var ent in entities)
            {
                ent.Step();
            }
        }

        public void Add(Entity e)
        {
            entities.Add(e);
        }

        public void Add(IGUIElement g)
        {
            elements.Add(g);
        }

        public List<IGUIElement> GetElements()
        {
            return this.elements;
        }

        public Entities GetEntitites()
        {
            return entities;
        }

        public void Remove(IGUIElement element)
        {
            elements.Remove(element);
        }

        internal void Remove(Entity moveMarker)
        {
            entities.Remove(moveMarker);
        }
    }

    class StartingRoom : Room
    {
        public StartingRoom()
        {
            base.entities = new Entities();
            base.elements = new List<IGUIElement>();
        }
    }
}
