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
        private List<Player> playerList;
        static Random r = new Random();

        public Ball(List<Player> playerList)
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
            this.playerList = playerList;
            this.Bounds = new Rectangle(location.ToPoint(), new Point(84, 64));
        }

        public override void Update()
        {
            Vector2 oldLoc = this.location;
            if (this.location.Y <= 50) {
                this.movement.Y = Math.Abs(this.movement.Y);
            }
            else if (this.location.Y + this.Bounds.Height >= 480)
            {
                this.movement.Y = -Math.Abs(this.movement.Y);
            }
            this.location += this.movement;
            UpdateBounds();

            foreach (Player player in this.playerList) {
                if (this.Bounds.Intersects(player.GetBounds())) {
                    this.location.Y = oldLoc.Y;
                    this.movement.X = -this.movement.X;

                    this.location += this.movement;
                    UpdateBounds();

                    if (this.movement.X < 0)
                        this.effect = SpriteEffects.FlipHorizontally;
                    else
                        this.effect = SpriteEffects.None;
                }
            }
        }
    }
}
