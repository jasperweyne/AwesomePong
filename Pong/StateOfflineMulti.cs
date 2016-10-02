using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    class StateOfflineMulti: GameState
    {

        public StateOfflineMulti()
        {
            this.Field = new Rectangle(0, 50, MainProcess.graphics.GraphicsDevice.Viewport.Width, MainProcess.graphics.GraphicsDevice.Viewport.Height - 50);
            this.Elems.Add(new PlayablePlayer(this, MainProcess.PlayerTex, Keys.S, Keys.W, Player.ScreenLocation.Left));
            this.Elems.Add(new PlayablePlayer(this, MainProcess.PlayerTex, Keys.Down, Keys.Up, Player.ScreenLocation.Right));
            this.Elems.Add(new Ball(this, MainProcess.BallTex));
        }

        public override void Draw()
        {
            base.Draw();
            int cx = MainProcess.graphics.GraphicsDevice.Viewport.Width / 2;
            int tw = MainProcess.TitleTex.Width / 2;
            MainProcess.spriteBatch.Draw(MainProcess.GameBarTex, Vector2.Zero, Color.White);
            MainProcess.spriteBatch.Draw(MainProcess.TitleTex, new Vector2(cx - tw, 25 - MainProcess.TitleTex.Height/2), Color.White);
            List<Player> PlayerList = MainProcess.GState.Elems.OfType<Player>().ToList<Player>();
            for (int i=0; i<PlayerList.Count; ++i) {
                int posX = (cx - tw) / (PlayerList.Count + 1);
                Vector2 size = MainProcess.ClassyAsFuckFont.MeasureString(PlayerList[i].Lives.ToString());
                Vector2 pos = new Vector2(posX * (i + 1) - size.X / 2, 25 - size.Y / 2);
                MainProcess.spriteBatch.DrawString(MainProcess.ClassyAsFuckFont, PlayerList[i].Lives.ToString(), pos, Color.White);
            }
        }
    }
}
