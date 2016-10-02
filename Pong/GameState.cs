using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Pong
{
    public class GameState: State
    {
        public Rectangle Field = new Rectangle(0, 50, MainProcess.graphics.GraphicsDevice.Viewport.Width, MainProcess.graphics.GraphicsDevice.Viewport.Height - 50);
        public List<GameElement> Elems = new List<GameElement>();
        private List<GameElement> ElemsClone = new List<GameElement>();
        private bool mode;
        private Scores scores;

        public GameState(bool lives = true)
        {
            this.mode = lives;
            foreach (Player player in Elems.OfType<Player>()) {
                if (lives)
                    player.Score = 3;
                else
                    player.Score = 0;
            }
            this.scores = new Scores();
        }

        public virtual void Hit(Ball obj, Player player, Player by)
        {
            obj.Reset();
            if (this.mode) {
                --player.Score;
                if (player.Score < 0) {
                    scores.SetScore(player.Color, Elems.Count);
                    Elems.Remove(player);
                    if (Elems.OfType<Player>().Count<GameElement>() <= 1) {
                        scores.SetScore(Elems.OfType<Player>().Single<Player>().Color, Elems.Count);
                        MainProcess.State = scores;
                    }
                }
            } else {
                ++by.Score;
            }
        }

        public override void Update()
        {
            ElemsClone.Clear();
            ElemsClone.AddRange(this.Elems);
            foreach (GameElement elem in ElemsClone)
                elem.Update();
        }

        public override void Draw()
        {
            foreach (GameElement elem in this.ElemsClone)
                elem.Draw();
            int cx = MainProcess.graphics.GraphicsDevice.Viewport.Width / 2;
            int tw = MainProcess.TitleTex.Width / 2;
            MainProcess.spriteBatch.Draw(MainProcess.GameBarTex, Vector2.Zero, Color.White);
            MainProcess.spriteBatch.Draw(MainProcess.TitleTex, new Vector2(cx - tw, 25 - MainProcess.TitleTex.Height / 2), Color.White);
            List<Player> PlayerList = MainProcess.GState.Elems.OfType<Player>().ToList<Player>();
            for (int i = 0; i < PlayerList.Count; ++i) {
                int posX = (cx - tw) / (PlayerList.Count + 1);
                Vector2 size = MainProcess.ClassyAsFuckFont.MeasureString(PlayerList[i].Score.ToString());
                Vector2 pos = new Vector2(posX * (i + 1) - size.X / 2, 25 - size.Y / 2);
                MainProcess.spriteBatch.DrawString(MainProcess.ClassyAsFuckFont, PlayerList[i].Score.ToString(), pos, PlayerList[i].Color);
            }
        }
    }
}
