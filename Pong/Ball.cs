using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;

namespace Pong
{
    public class Ball : GameElement
    {
        private static Random r = new Random();
        private Player last;

        public Ball(Texture2D tex): base(tex)
        {
            double dir = r.NextDouble() * Math.PI;
            if (dir >= Math.PI / 2) {
                dir += Math.PI / 2;
                effect = SpriteEffects.FlipHorizontally;
            }
            dir -= Math.PI / 4;
            const double speed = 4;
            this.movement = new Vector2((float)(speed * Math.Cos(dir)), (float)(speed * Math.Sin(dir)));
            this.location = MainProcess.GState.Field.Center.ToVector2();
            this.Bounds = new Rectangle(location.ToPoint(), new Point(84, 64));
        }

        public void Reset()
        {
            double dir = r.NextDouble() * Math.PI;
            if (dir >= Math.PI / 2) {
                dir += Math.PI / 2;
                effect = SpriteEffects.FlipHorizontally;
            }
            dir -= Math.PI / 4;
            const double speed = 4;
            this.movement = new Vector2((float)(speed * Math.Cos(dir)), (float)(speed * Math.Sin(dir)));
            this.location = MainProcess.GState.Field.Center.ToVector2();
        }

        private void UpdateLoc()
        {
            this.location += this.movement;
            UpdateBounds();
            if (this.movement.X < 0)
                this.effect = SpriteEffects.FlipHorizontally;
            else
                this.effect = SpriteEffects.None;
        }

        private Player getPlayer(Player.ScreenLocation loc)
        {
            return MainProcess.GState.Elems.OfType<Player>().SingleOrDefault<Player>(player => player.ScreenSide == loc);
        }

        public override void Update()
        {
            Vector2 oldLoc = this.location;

            if (this.location.Y <= MainProcess.GState.Field.Top) {
                Player hit = getPlayer(Player.ScreenLocation.Top);
                if (hit == null)
                    this.movement.Y = Math.Abs(this.movement.Y);
                else if (this.location.Y + this.Bounds.Height <= MainProcess.GState.Field.Top)
                    MainProcess.GState.Hit(this, hit, last);
            } else if (this.location.Y + this.Bounds.Height >= MainProcess.GState.Field.Bottom) {
                Player hit = getPlayer(Player.ScreenLocation.Bottom);
                if (hit == null)
                    this.movement.Y = -Math.Abs(this.movement.Y);
                else if (this.location.Y >= MainProcess.GState.Field.Bottom)
                    MainProcess.GState.Hit(this, hit, last);
            }
            if (this.location.X <= MainProcess.GState.Field.Left) {
                Player hit = getPlayer(Player.ScreenLocation.Left);
                if (hit == null)
                    this.movement.X = Math.Abs(this.movement.X);
                else if (this.location.X + this.Bounds.Width <= MainProcess.GState.Field.Left)
                    MainProcess.GState.Hit(this, hit, last);
            } else if (this.location.X + this.Bounds.Width >= MainProcess.GState.Field.Right) {
                Player hit = getPlayer(Player.ScreenLocation.Right);
                if (hit == null)
                    this.movement.X = -Math.Abs(this.movement.X);
                else if (this.location.X >= MainProcess.GState.Field.Right)
                    MainProcess.GState.Hit(this, hit, last);
            }
            UpdateLoc();
            
            if (MainProcess.GState != null)
                foreach (GameElement elem in MainProcess.GState.Elems) {
                    if (this.Bounds.Intersects(elem.GetBounds()) && elem != this) {
                        if (elem is Player) {
                            Rectangle dBoundsX = new Rectangle(new Point((int)(oldLoc.X + this.movement.X), (int)oldLoc.Y), this.Bounds.Size);
                            if (dBoundsX.Intersects(elem.GetBounds())) {
                                this.location.Y = oldLoc.Y;
                                this.movement.X *= -1;
                                if (elem.GetBounds().Intersects(new Rectangle((this.location + this.movement).ToPoint(), this.Bounds.Size))) {
                                    if (elem.Movement.X > 0)
                                        this.location.X = elem.GetBounds().Right - this.movement.X;
                                    else
                                        this.location.X = elem.GetBounds().Left - this.Bounds.Width - this.movement.X;
                                }
                            }
                            Rectangle dBoundsY = new Rectangle(new Point((int)oldLoc.X, (int)(oldLoc.Y + this.movement.Y)), this.Bounds.Size);
                            if (dBoundsY.Intersects(elem.GetBounds())) {
                                this.location.X = oldLoc.X;
                                this.movement.Y *= -1;
                                if (elem.GetBounds().Intersects(new Rectangle((this.location + this.movement).ToPoint(), this.Bounds.Size))) {
                                    if (elem.Movement.Y > 0)
                                        this.location.Y = elem.GetBounds().Bottom - this.movement.Y;
                                    else
                                        this.location.Y = elem.GetBounds().Top - this.Bounds.Height - this.movement.Y;
                                }
                            }
                            UpdateLoc();
                            this.last = (Player)elem;
                        }
                    }
                }
        }
    }
}
