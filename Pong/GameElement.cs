using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Pong
{
    public abstract class GameElement: BaseObject
    {
        protected Rectangle Bounds;

        public Rectangle GetBounds()
        {
            return this.Bounds;
        }

        protected void UpdateBounds()
        {
            this.Bounds.Location = this.location.ToPoint();
        }
    }
}
