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
        Direction playerDirection = Direction.down;
        int radius = 30;
        float healthTimer = 0f;

        public AnimatedSprite animation;
        public AnimatedSprite[] animationsDirection = new AnimatedSprite [4];

        private KeyboardState kstateOld = Keyboard.GetState();

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

        public float HealthTimer
        {
            get { return healthTimer; }
            set { healthTimer = value; }
        }
        public int Radius
        {
            get { return radius; }
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
            float healthDt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (healthTimer > 0)
            {
                healthTimer -= healthDt;
            }

            //switch (playerDirection)
            //{
            //    case direction.down:
            //        animation = animationsDirection[1];
            //        break;
            //    case direction.up:
            //        animation = animationsDirection[0];
            //        break;
            //    case direction.left:
            //        animation = animationsDirection[2];
            //        break;
            //    case direction.right:

            //        animation = animationsDirection[3];
            //        break;
            //    default:
            //        break;
            //}

            // OR simply below
            animation = animationsDirection[(int)playerDirection];


            if (isMoving)
            {
                animation.Update(gameTime);
            }
            else
            {
                animation.SetFrame(1);
            }

            isMoving = false;

            if (keyInput.IsKeyDown(Keys.Right))
            {
                playerDirection = Direction.right;
               
                isMoving = true;

            }
            if (keyInput.IsKeyDown(Keys.Left))
            {
                playerDirection = Direction.left;
               
                isMoving = true;

            }
            if (keyInput.IsKeyDown(Keys.Down))
            {
                playerDirection = Direction.down;
                
                isMoving = true;

            }
            if (keyInput.IsKeyDown(Keys.Up))
            {
                playerDirection = Direction.up;
               
                isMoving = true;

            }
            if (isMoving)
            {
                //checking for collition
                Vector2 tempos = position;


                switch (playerDirection)
                {
                    case Direction.down:
                        tempos.Y += deltaTime;
                        if (!Obstacle.didCollide(tempos, radius))
                        {
                            position.Y += deltaTime;
                        }
                        
                        break;
                    case Direction.up:
                        tempos.Y -= deltaTime;
                        if (!Obstacle.didCollide(tempos, radius))
                        {
                            position.Y -= deltaTime;
                        }
                        break;
                    case Direction.left:
                        tempos.X -= deltaTime;
                        if (!Obstacle.didCollide(tempos, radius))
                        {
                            position.X -= deltaTime;
                        }
                        break;

                    case Direction.right:
                        tempos.X += deltaTime;
                        if (!Obstacle.didCollide(tempos, radius))
                        {
                            position.X += deltaTime;
                        }
                        break;
                    default:

                        break;
                }
            }

            if (keyInput.IsKeyDown(Keys.Space) && kstateOld.IsKeyUp(Keys.Space))
            {
                Projectiles.projectiles.Add(new Projectiles(position, playerDirection));
            }
            kstateOld = keyInput;

        }
    }
}
