using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
    public class Ball : GameElement
    {
        private static Random r = new Random();
        private Player last;

        public Ball(GameState state, Texture2D tex): base(tex)
        {
            double dir = r.NextDouble() * Math.PI;
            if (dir >= Math.PI / 2) {
                dir += Math.PI / 2;
                effect = SpriteEffects.FlipHorizontally;
            }
            dir -= Math.PI / 4;
            const double speed = 4;
            this.movement = new Vector2((float)(speed * Math.Cos(dir)), (float)(speed * Math.Sin(dir)));
            this.location = state.Field.Center.ToVector2();
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
            
            foreach (GameElement elem in MainProcess.GState.Elems) {
                if (this.Bounds.Intersects(elem.GetBounds()) && elem != this) {
                    if (elem is Player) {
                        Vector2 minkowski = (this.Bounds.Center - elem.GetBounds().Center).ToVector2() * ((this.Bounds.Size + elem.GetBounds().Size).ToVector2() / 2);
                        if (minkowski.Y > minkowski.X) {
                            if (minkowski.Y > -minkowski.X) {
                                // top
                                this.location.X = oldLoc.X;
                                this.movement.Y = -this.movement.Y;
                            } else {
                                // left
                                this.location.Y = oldLoc.Y;
                                this.movement.X = -this.movement.X;
                            }
                        } else {
                            if (minkowski.Y > -minkowski.X) {
                                // right
                                this.location.Y = oldLoc.Y;
                                this.movement.X = -this.movement.X;
                            } else {
                                // bottom
                                this.location.X = oldLoc.X;
                                this.movement.Y = -this.movement.Y;
                            }
                        }
                        this.location += elem.Movement;
                        UpdateLoc();
                        this.last = (Player)elem;
                    }
                }
            }
        }
    }
}
