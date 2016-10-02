using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
    public abstract class GameState: State
    {
        public Rectangle Field;
        public List<GameElement> Elems = new List<GameElement>();
        public virtual void Hit(Ball obj, Player player, Player by)
        {
            obj.Reset();
            --player.Score;
            if (player.Score < 0) {
                Elems.Remove(player);
                if (Elems.OfType<Player>().Count<GameElement>() <= 1)
                    MainProcess.State = new StateOfflineMulti();
            }
        }

        public override void Update()
        {
            List<GameElement> clone = new List<GameElement>(this.Elems.Count);
            clone.AddRange(this.Elems);
            foreach (GameElement elem in clone)
                elem.Update();
        }

        public override void Draw()
        {
            foreach (GameElement elem in this.Elems)
                elem.Draw();
        }
    }
}
