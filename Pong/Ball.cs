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
        private List<GameElement> elemList;
        static Random r = new Random();

        private bool top    = true;
        private bool bottom = true;
        private bool left   = true;
        private bool right  = true;

        public Ball(GameState state, List<GameElement> elemList)
        {
            double dir = r.NextDouble() * Math.PI;
            if (dir >= Math.PI / 2)
            {
                dir += Math.PI / 2;
                effect = SpriteEffects.FlipHorizontally;
            }
            dir -= Math.PI / 4;
            const double speed = 4;
            this.movement = new Vector2((float)(speed * Math.Cos(dir)), (float)(speed * Math.Sin(dir)));
            this.location = state.Field.Center.ToVector2();
            this.elemList = elemList;
            this.Bounds = new Rectangle(location.ToPoint(), new Point(84, 64));
            
            foreach (GameElement elem in elemList) {
                if (elem is Player) {
                    Player player = (Player)elem;
                    switch (player.ScreenSide) {
                        case Player.ScreenLocation.Top:
                            this.top = false;
                            break;
                        case Player.ScreenLocation.Bottom:
                            this.bottom = false;
                            break;
                        case Player.ScreenLocation.Left:
                            this.left = false;
                            break;
                        case Player.ScreenLocation.Right:
                            this.right = false;
                            break;
                    }
                }
            }
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

        public override void Update()
        {
            Vector2 oldLoc = this.location;

            if (this.location.Y <= MainProcess.GState.Field.Top) {
                if (this.top)
                    this.movement.Y = Math.Abs(this.movement.Y);
            }
            else if (this.location.Y + this.Bounds.Height >= MainProcess.GState.Field.Bottom)
            {
                if (this.bottom)
                    this.movement.Y = -Math.Abs(this.movement.Y);
            }
            if (this.location.X <= MainProcess.GState.Field.Left) {
                if (this.left)
                    this.movement.X = Math.Abs(this.movement.X);
            } else if (this.location.X + this.Bounds.Width >= MainProcess.GState.Field.Right) {
                if (this.right)
                    this.movement.X = -Math.Abs(this.movement.X);
            }
            UpdateLoc();

            foreach (GameElement elem in this.elemList) {
                if (this.Bounds.Intersects(elem.GetBounds())) {
                    this.location.Y = oldLoc.Y;
                    this.movement.X = -this.movement.X;
                    UpdateLoc();
                }
            }
        }
    }
}
