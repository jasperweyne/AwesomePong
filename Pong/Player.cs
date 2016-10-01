using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
    abstract class Player : GameElement
    {
        public Player(Vector2 loc)
        {
            this.Bounds = new Rectangle(0, 0, 16, 112);
            this.location = loc;
        }
        protected void MoveDown()
        {
            // Als onderkant (vandaar +96) van het plaatje hoger is
            // dan onderkant van het scherm, verplaats naar onder
            if (this.location.Y + this.Bounds.Height + 5 < 480) {
                this.location.Y += 5;
            } else {
                this.location.Y = 480 - this.Bounds.Height;
            }
        }

        protected void MoveUp()
        {
            // Als bovenkant van het plaatje lager is dan
            // de bovenkant van het scherm, verplaats naar boven
            if (this.location.Y - 5 > 50)
            {
                this.location.Y -= 5;
            } else {
                this.location.Y = 50;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(view, location - new Vector2(9, 8), null, null, null, rotation, null, null, effect);
        }
    }
}
