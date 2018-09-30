using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace splanker.src.util
{
    class GameCoordinate
    {
        private float x, y;

        public float X
        {
            get { return x; }
            set { x = value; }
        }

        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        public GameCoordinate(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class GLCoordinate
    {
        private float x, y;

        public GLCoordinate(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public float X
        {
            get { return x; }
            set { x = value; }
        }

        public float Y
        {
            get { return y; }
            set { y = value; }
        }
    }
}
