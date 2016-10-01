using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    class StateOfflineMulti: State
    {
        Player left;
        Player right;
        Ball ball;

        public StateOfflineMulti() {
            left = new PlayablePlayer(Keys.S, Keys.W, Player.ScreenLocation.Left);
            right = new PlayablePlayer(Keys.Down, Keys.Up, Player.ScreenLocation.Right);
            ball = new Ball(new List<Player> { left, right });
            left.SetTexture(MainProcess.PlayerTex);
            right.SetTexture(MainProcess.PlayerTex);
            ball.SetTexture(MainProcess.BallTex);
        }

        public override void Update() {
            left.Update();
            right.Update();
            ball.Update();
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(MainProcess.TitleTex, new Vector2(330, 9), Color.White);
            spriteBatch.Draw(MainProcess.GameBarTex, new Vector2(0, 48), Color.White);
            left.Draw(spriteBatch);
            right.Draw(spriteBatch);
            ball.Draw(spriteBatch);
        }
    }
}
