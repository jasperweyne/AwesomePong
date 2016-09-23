using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
    abstract class Player : BaseObject
    {
        public Player(Texture2D tex): base(tex)
        {
        }

        protected void MoveDown()
        {
            // Als onderkant (vandaar +96) van het plaatje hoger is
            // dan onderkant van het scherm, verplaats naar onder
            if (this.location.Y + 96 < 480)
            {
                this.location.Y += 5;
            }
        }

        protected void MoveUp()
        {
            // Als bovenkant van het plaatje lager is dan
            // de bovenkant van het scherm, verplaats naar boven
            if (this.location.Y > 0)
            {
                this.location.Y -= 5;
            }
        }
    }
}
