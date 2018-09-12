using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoRPG
{
    class Obstacle
    {
        public static List<Obstacle> obstacles = new List<Obstacle>();
        protected Vector2 position;
        protected int radius;
        protected Vector2 hitPos;

        public Vector2 Position
        {
            get { return position; }
        }

        public Vector2 HitPos
        {
            get { return hitPos; }
        }

        public int Radius
        {
            get { return radius; }
        }

        public Obstacle(Vector2 newPos)
        {
            position = newPos;
        }
        public static bool didCollide(Vector2 otherPos, int otherRad)
        {
            foreach (Obstacle o in Obstacle.obstacles)
            {
                int sum = o.radius + otherRad;
                if (Vector2.Distance(otherPos, o.hitPos) < sum)
                {
                    return true;
                }

            }
            return false;
        }
    }

    class Tree : Obstacle
    {

        public Tree(Vector2 newPos) : base(newPos)
        {
            radius = 50;
            hitPos = new Vector2(position.X + 64, position.Y + 150);

        }
       
    }
    class Bush : Obstacle
    {
        public Bush(Vector2 newPos): base(newPos)
        {
            radius = 56;
            hitPos = new Vector2(position.X + 56, position.Y + 57);

        }

    }
}
