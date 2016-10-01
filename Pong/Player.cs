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
        public ScreenLocation ScreenSide { get; }
        private Vector2 locModif;

        public enum ScreenLocation {
            Top,
            Right,
            Bottom,
            Left
        }
        public Player(ScreenLocation scrLoc)
        {
            this.ScreenSide = scrLoc;
            switch (scrLoc) {
                case ScreenLocation.Top:
                case ScreenLocation.Bottom:
                    if (scrLoc == ScreenLocation.Top)
                        this.location = new Vector2(345, 100);
                    else
                        this.location = new Vector2(345, 430);
                    this.locModif = new Vector2(8, 9);
                    this.Bounds = new Rectangle(this.location.ToPoint(), new Point(112, 16));
                    this.rotation = 1.57079633f; // 90 degrees in radians
                    break;
                case ScreenLocation.Left:
                case ScreenLocation.Right:
                    if (scrLoc == ScreenLocation.Left)
                        this.location = new Vector2(50, 185);
                    else
                        this.location = new Vector2(750, 185);
                    this.locModif = new Vector2(9, 8);
                    this.Bounds = new Rectangle(this.location.ToPoint(), new Point(16, 112));
                    break;
            }
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
            spriteBatch.Draw(this.view, this.location - this.locModif, null, null, null, this.rotation, null, null, this.effect);
        }
    }
}
