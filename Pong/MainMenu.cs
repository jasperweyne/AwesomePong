using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    class MainMenu: State
    {
        public override void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                MainProcess.State = new StateOfflineMulti(MainProcess.graphics.GraphicsDevice);
        }
        public override void Draw()
        {
            MainProcess.spriteBatch.Draw(MainProcess.TitleTex, new Vector2(300, MainProcess.graphics.GraphicsDevice.Viewport.Height / 2), Color.White);
            MainProcess.spriteBatch.DrawString(MainProcess.FuckingPrettyFont, "Press enter to start", new Vector2(260, MainProcess.graphics.GraphicsDevice.Viewport.Height / 2 + 30), Color.White);
        }
    }
}
