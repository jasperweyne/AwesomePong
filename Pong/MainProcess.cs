using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Pong
{
    /// <summary>
    ///  The class that controls the game- and draw-loops
    /// </summary>
    public class MainProcess: Game
    {
        public static GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;

        public static Texture2D PlayerTex;
        public static Texture2D BallTex;
        public static Texture2D TitleTex;
        public static Texture2D GameBarTex;
        public static SpriteFont ClassyAsFuckFont;  // parisienne
        public static SpriteFont FuckingPrettyFont; // #comicsans ftw!

        public static GameState GState
        {
            get {
                if (State is GameState)
                    return (GameState)State;
                return null;
            }
        }
        public static State State;

        Song PinkFluffyMotherfuckingUnicorn;

        public static void ChangeState(State state)
        {
            State = state;
        }

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
        
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            PlayerTex = Content.Load<Texture2D>("playerbar");
            BallTex = Content.Load<Texture2D>("unicorn");
            TitleTex = Content.Load<Texture2D>("title");
            GameBarTex = Content.Load<Texture2D>("topbar");
            ClassyAsFuckFont = Content.Load<SpriteFont>("Parisienne");
            //PinkFluffyMotherfuckingUnicorn = Content.Load<Song>("pinkfluffyunicorn");
            State = new StateOfflineMulti(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            State.Update();

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(255,0,255));

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            State.Draw();
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
