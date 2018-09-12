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
    class Enemy
    {
        private Vector2 position;
        protected int health;
        protected int speed;
        protected int radius;

        public static List<Enemy> enemies = new List<Enemy>();

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public Vector2 Position
        {
            get { return position; }
        }

        public int Radius
        {
           get { return radius; }
        }

        public Enemy(Vector2 newPos)
        {
            position = newPos;
        }

        public void Update(GameTime gameTime, Vector2 playerPos)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Vector2 moveDirection = playerPos - position;
            //normalise reduces vector e.g 5,0 to 1,0 But,  Still points right.
            moveDirection.Normalize();

            Vector2 tempPos = position;

            tempPos += moveDirection * speed* deltaTime;
            if (!Obstacle.didCollide(tempPos, radius))
            {
                position += moveDirection * speed * deltaTime;
            }

        }
    }

    class Snake : Enemy
    {
        public Snake(Vector2 newPos): base (newPos)
        {
            speed = 110;
            radius = 42;
            health = 3;
        }
    }
    class Eye : Enemy
    {
        public Eye(Vector2 newPos) : base(newPos)
        {
            speed = 80;
            radius = 45;
            health = 5;
        }
    }
}
