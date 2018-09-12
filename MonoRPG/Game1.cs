using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoRPG
{
    enum Direction {up,down,left,right };
  
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D playerSprite;
        Texture2D playerDown;
        Texture2D playerUp;
        Texture2D playerLeft;
        Texture2D playerRight;

        Texture2D eyeEnemySprite;
        Texture2D snakeEnemySprite;

        Texture2D bushSprite;
        Texture2D treeSprite;

        Texture2D heartSprite;
        Texture2D bulletSprite;

        Player player = new Player();
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1080;
        }


        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            
            
        }

       
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            playerSprite = Content.Load<Texture2D>("Player/player");
            playerDown = Content.Load<Texture2D>("Player/playerDown");
            playerUp = Content.Load<Texture2D>("Player/playerUp");
            playerLeft = Content.Load<Texture2D>("Player/playerLeft");
            playerRight = Content.Load<Texture2D>("Player/playerRight");

            bushSprite = Content.Load<Texture2D>("Obstacles/bush");
            treeSprite = Content.Load<Texture2D>("Obstacles/tree");

            eyeEnemySprite = Content.Load<Texture2D>("Enemies/eyeEnemy");
            snakeEnemySprite = Content.Load<Texture2D>("Enemies/snakeEnemy");

            bulletSprite = Content.Load<Texture2D>("Misc/bullet");
            heartSprite = Content.Load<Texture2D>("Misc/heart");

            
            AnimatedSprite walkUp = new AnimatedSprite(playerUp, 1, 4);
            AnimatedSprite walkDown = new AnimatedSprite(playerDown, 1, 4);
            AnimatedSprite walkLeft = new AnimatedSprite(playerLeft, 1, 4);
            AnimatedSprite walkRight = new AnimatedSprite(playerRight, 1, 4);

            player.animationsDirection[0] = walkUp;
            player.animationsDirection[1] = walkDown;
            player.animationsDirection[2] = walkLeft;
            player.animationsDirection[3] = walkRight;

            Enemy.enemies.Add(new Snake(new Vector2(100, 200)));
            Enemy.enemies.Add(new Eye(new Vector2(250, 400)));

            Obstacle.obstacles.Add(new Bush(new Vector2(500, 500)));
            Obstacle.obstacles.Add(new Tree(new Vector2(250, 350)));


        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

     
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (player.Health >= 0)
            {
                player.Update(gameTime);
            }

            foreach (Projectiles project in Projectiles.projectiles)
            {
                project.Update(gameTime);
            }

            foreach (Enemy en in Enemy.enemies)
            {
                en.Update(gameTime, player.Position);
            }

            foreach (Projectiles pro in Projectiles.projectiles)
            {
                foreach (Enemy en in Enemy.enemies)
                {
                    int sum = pro.Radius + en.Radius;

                    if (Vector2.Distance(pro.Position, en.Position) < sum)
                    {
                        //collision! 
                        pro.Collided = true;
                        en.Health--;
                        
                    }
                }
                //collided with obstacles
                if (Obstacle.didCollide(pro.Position, pro.Radius))
                {
                    pro.Collided = true;
                }
                    
            }

            foreach (Enemy en in Enemy.enemies)
            {
                
                int sum = player.Radius + en.Radius;
                if (Vector2.Distance(en.Position, player.Position) < sum && player.HealthTimer <=0 )
                {
                    player.Health--;
                    player.HealthTimer = 1.5f;
                }
            }
            Projectiles.projectiles.RemoveAll(x => x.Collided == true);
            Enemy.enemies.RemoveAll(x => x.Health <= 0);




            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.ForestGreen);
            if (player.Health >= 0)
            {
                player.animation.Draw(spriteBatch, new Vector2(player.Position.X - 48, player.Position.Y - 48));
            }
            
            spriteBatch.Begin();
            foreach (Projectiles project in Projectiles.projectiles)
            {
                spriteBatch.Draw(bulletSprite, new Vector2(project.Position.X - project.Radius, project.Position.Y - project.Radius), Color.White);
            }

            foreach (Enemy en in Enemy.enemies)
            {
                Texture2D spriteToDraw;
                int rad;
                if (en.GetType() == typeof(Snake))
                {
                    spriteToDraw = snakeEnemySprite;
                    rad = 50;
                }
                else
                {
                    spriteToDraw = eyeEnemySprite;
                    rad = 73;
                }
                spriteBatch.Draw(spriteToDraw, new Vector2(en.Position.X- rad, en.Position.Y -rad), Color.White);
            }

            foreach (Obstacle o in Obstacle.obstacles)
            {
                Texture2D spriteToDraw;
                if (o.GetType() == typeof(Tree))
                {
                    spriteToDraw = treeSprite;
                }
                else
                {
                    spriteToDraw = bushSprite;
                }
                spriteBatch.Draw(spriteToDraw, o.Position, Color.White);

                

            }


            for (int i = 0; i < player.Health; i++)
            {
                spriteBatch.Draw(heartSprite, new Vector2(i * 63, 3), Color.White);
            }
        


            // TODO: Add your drawing code here

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
