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
            this.location.Y += 5;
        }

        protected void MoveUp()
        {
            this.location.Y -= 5;
        }
    }
}
