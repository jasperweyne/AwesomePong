using System;
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
            left = new PlayablePlayer(Keys.S, Keys.W, new Vector2(50, 300));
            right = new PlayablePlayer(Keys.Down, Keys.Up, new Vector2(750, 50));
            ball = new Ball(left, right);
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
            spriteBatch.Draw(MainProcess.GameBarTex, new Vector2(0, 48), Color.White);
            left.Draw(spriteBatch);
            right.Draw(spriteBatch);
            ball.Draw(spriteBatch);
        }
    }
}
