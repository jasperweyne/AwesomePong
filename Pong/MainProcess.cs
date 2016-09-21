using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    /// <summary>
    ///  The class that controls the game- and draw-loops
    /// </summary>
    public class MainProcess: Game
    {
        
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D player1;
        Texture2D player2;
        PlayerLeft left;
        PlayerRight right;

        /// <summary>
        ///  The method that starts the program and launches the game loop
        /// </summary>
        static void Main()
        {
            MainProcess game = new MainProcess();
            game.Run();
        }

        /// <summary>
        ///  The constructor for MainProcess, inits variables
        /// </summary>
        public MainProcess()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            player1 = Content.Load<Texture2D>("blauweSpeler");
            left = new PlayerLeft(player1);
            player2 = Content.Load<Texture2D>("rodeSpeler");
            left = new PlayerLeft(player2);


            // TODO: use this.Content to load your game content here
        }
        
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            left?.Update();
            right?.Update();

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            left?.Draw(spriteBatch);
            right?.Draw(spriteBatch);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
