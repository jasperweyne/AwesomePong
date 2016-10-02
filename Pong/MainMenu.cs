﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    class MainMenu: State
    {
        public override void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter)) {
                MainProcess.State = new GameState();
                MainProcess.GState.Elems.Add(new PlayablePlayer(MainProcess.PlayerTex, Keys.S, Keys.W, Player.ScreenLocation.Left, Color.Yellow));
                MainProcess.GState.Elems.Add(new PlayablePlayer(MainProcess.PlayerTex, Keys.Down, Keys.Up, Player.ScreenLocation.Right, Color.Blue));
                MainProcess.GState.Elems.Add(new Ball(MainProcess.BallTex));
            }
        }
        public override void Draw()
        {
            Vector2 pos = new Vector2(MainProcess.graphics.GraphicsDevice.Viewport.Width / 2 - MainProcess.TitleTex.Width / 2, 25 - MainProcess.TitleTex.Height / 2);
            MainProcess.spriteBatch.Draw(MainProcess.TitleTex, pos, Color.White);
            MainProcess.spriteBatch.DrawString(MainProcess.FuckingPrettyFont, "Press enter to start", new Vector2(260, MainProcess.graphics.GraphicsDevice.Viewport.Height / 2 + 30), Color.White);
        }
    }
}
