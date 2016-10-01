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
        Ball ball;

        public StateOfflineMulti(GraphicsDevice graphics)
        {
            this.Field = new Rectangle(0, 50, graphics.Viewport.Width, graphics.Viewport.Height - 50);
            left = new PlayablePlayer(this, Keys.S, Keys.W, Player.ScreenLocation.Left);
            right = new PlayablePlayer(this, Keys.Down, Keys.Up, Player.ScreenLocation.Right);
            ball = new Ball(this, new List<GameElement> { left, right });
            left.SetTexture(MainProcess.PlayerTex);
            right.SetTexture(MainProcess.PlayerTex);
            ball.SetTexture(MainProcess.BallTex);
        }

        public override void Update() {
            left.Update();
            right.Update();
            ball.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(MainProcess.GameBarTex, Vector2.Zero, Color.White);
            spriteBatch.Draw(MainProcess.TitleTex, new Vector2(330, 9), Color.White);
            left.Draw(spriteBatch);
            right.Draw(spriteBatch);
            ball.Draw(spriteBatch);
        }
    }
}
