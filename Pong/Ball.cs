using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
    class Ball : GameElement
    {
        private Vector2 movement;
        private Player left;
        private Player right;
        static Random r = new Random();

        public Ball(Player left, Player right)
        {
            int dir = r.Next(180);
            if (dir >= 90)
            {
                dir += 90;
                effect = SpriteEffects.FlipHorizontally;
            }
            dir -= 45;
            const double speed = 4;
            this.movement = new Vector2((float)(speed * Math.Cos(dir)), (float)(speed * Math.Sin(dir)));
            this.location = new Vector2(400, 240);
            this.left = left;
            this.right = right;
            this.Bounds = new Rectangle(location.ToPoint(), new Point(84, 64));
        }

        public override void Update()
        {
            if (location.Y <= 0) {
                this.movement.Y = Math.Abs(this.movement.Y);
            }
            else if (location.Y >= 420)
            {
                this.movement.Y = -Math.Abs(this.movement.Y);
            }

            if (Bounds.Intersects(left.GetBounds()))
            {
                this.movement.X = Math.Abs(this.movement.X);
                effect = SpriteEffects.None;
            }
            else if (Bounds.Intersects(right.GetBounds()))
            {
                this.movement.X = -Math.Abs(this.movement.X);
                effect = SpriteEffects.FlipHorizontally;
            }

            this.location += this.movement;
            UpdateBounds();
        }
    }
}
