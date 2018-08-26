using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoRPG
{
    enum direction {down,up,left,right };
  
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

            player.animation = new AnimatedSprite(playerDown, 1, 4);

        }

  
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

     
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.Update(gameTime);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.ForestGreen);
            player.animation.Draw(spriteBatch, player.Position);

            spriteBatch.Begin();
            




            // TODO: Add your drawing code here

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
