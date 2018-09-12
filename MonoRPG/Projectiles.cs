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
    class Projectiles
    {
        private Vector2 position;
        private int speed = 700;
        private int radius = 15;
        private Direction direction;
        private bool collided = false;

        public static List<Projectiles> projectiles = new List<Projectiles>();

        public Projectiles(Vector2 newPos, Direction newDir)
        {
            position = newPos;
            direction = newDir;
        }

        public Vector2 Position
        {
            get { return position; }
        }

        public int Radius
        {
            get { return radius; }
        }
        public bool Collided
        {
            get { return collided; }
            set { collided = value; }
        }
        public void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            switch (direction)
            {
                case Direction.up:
                    position.Y -= speed * deltaTime;
                    break;
                case Direction.down:
                    position.Y += speed * deltaTime;
                    break;
                case Direction.left:
                    position.X -= speed * deltaTime;
                    break;
                case Direction.right:
                    position.X += speed * deltaTime;
                    break;
                default:
                    break;
            }
        }
    }
}
