using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using splanker.src.util;

namespace splanker.src.gui
{
    class Hero : Entity
    {
        public GameCoordinate GoingTo { get; set; }

        public Hero()
        {
            GoingTo = base.Location;
            Color = Color.BlueViolet;
        }

        public void GameStep()
        {
            this.Location = GoingTo;
        }
    }
}
