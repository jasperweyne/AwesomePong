using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    class StateOfflineMulti: GameState
    {
        Player left;
        Player right;

        public StateOfflineMulti()
        {
            this.Field = new Rectangle(0, 50, MainProcess.graphics.GraphicsDevice.Viewport.Width, MainProcess.graphics.GraphicsDevice.Viewport.Height - 50);
            left = new PlayablePlayer(this, MainProcess.PlayerTex, Keys.S, Keys.W, Player.ScreenLocation.Left);
            right = new PlayablePlayer(this, MainProcess.PlayerTex, Keys.Down, Keys.Up, Player.ScreenLocation.Right);
            GameElement ball = new Ball(this, MainProcess.BallTex);
            this.Elems.Add(left);
            this.Elems.Add(right);
            this.Elems.Add(ball);
        }

        public override void Draw()
        {
            base.Draw();
            MainProcess.spriteBatch.Draw(MainProcess.GameBarTex, Vector2.Zero, Color.White);
            MainProcess.spriteBatch.Draw(MainProcess.TitleTex, new Vector2(330, 9), Color.White);
            if (left != null)
                MainProcess.spriteBatch.DrawString(MainProcess.ClassyAsFuckFont, left.Lives.ToString(), new Vector2(0, 0), Color.White);
            if (right != null)
                MainProcess.spriteBatch.DrawString(MainProcess.ClassyAsFuckFont, right.Lives.ToString(), new Vector2(750, 0), Color.White);
        }
    }
}
