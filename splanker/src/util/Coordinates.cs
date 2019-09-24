using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace splanker.src.util
{
    abstract class Coordinate
    {
        protected float x, y;

        public override string ToString()
        {
            return x + ", " + y;
        }
    }

    class GameCoordinate : Coordinate
    {
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

        public static GameCoordinate operator +(GameCoordinate a, GameCoordinate b)
        {
            return new GameCoordinate(a.X + b.X, a.Y + b.Y);
        }
    }

    class GLCoordinate : Coordinate
    {
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

        //todo: todon't rather amirite
        public GameCoordinate ToGameCoordinate()
        {
            return new GameCoordinate(x * 2 / GameFrame.WIDTH - 1, -(y * 2 / GameFrame.HEIGHT - 1)); ;
        }
    }
}
