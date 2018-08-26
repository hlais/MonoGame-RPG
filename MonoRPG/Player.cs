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
    class Player
    {
        Vector2 position = new Vector2(100, 100);
        int speed = 200;
        int health = 3;
        bool isMoving = false;
        direction playerDirection = direction.down;

        public AnimatedSprite animation;

        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
            }
        }
        public Vector2 Position
        {
            get {
                return position;
            }
           
        }

        public void SetX(float x)
        {
            position.X = x;
        }
        public void SetY(float y)
        {
            position.Y = y;
        }

        public void Update(GameTime gameTime)
        {
            float deltaTime =  speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            KeyboardState keyInput = Keyboard.GetState();

            animation.Update(gameTime);

            isMoving = false;

            if (keyInput.IsKeyDown(Keys.Right))
            {
                playerDirection = direction.right;
                isMoving = true;

            }
            if (keyInput.IsKeyDown(Keys.Left))
            {
                playerDirection = direction.left;
                isMoving = true;

            }
            if (keyInput.IsKeyDown(Keys.Down))
            {
                playerDirection = direction.down;
                isMoving = true;

            }
            if (keyInput.IsKeyDown(Keys.Up))
            {
                playerDirection = direction.up;
                isMoving = true;

            }
            if (isMoving)
            {
                switch (playerDirection)
                {
                    case direction.down:
                        position.Y += deltaTime;
                        break;
                    case direction.up:
                        position.Y -= deltaTime;
                        break;
                    case direction.left:
                        position.X -= deltaTime;
                        break;
                    case direction.right:
                        position.X += deltaTime;
                        break;
                    default:

                        break;
                }
            }


        }
    }
}
