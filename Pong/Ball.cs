using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
    class Ball : BaseObject
    {
        private Vector2 movement = new Vector2(1, -3);

        public Ball()
        {
            this.location = new Vector2(400, 240);
        }

        public override void Update(Player left, Player right)
        {
            if (location.Y <= 0) {
                this.movement.Y = Math.Abs(this.movement.Y);
            }
            else if (location.Y >= 420)
            {
                this.movement.Y = -Math.Abs(this.movement.Y);
            }

            this.location += this.movement;
        }
    }
}
