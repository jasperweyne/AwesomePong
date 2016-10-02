using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Pong
{
    public abstract class Player : GameElement
    {
        public ScreenLocation ScreenSide { get; }
        public int Score = 3;
        private float speed;
        private Vector2 locModif;

        public enum ScreenLocation {
            Top,
            Right,
            Bottom,
            Left
        }
        public Player(GameState state, Texture2D tex, ScreenLocation scrLoc): base(tex)
        {
            this.ScreenSide = scrLoc;
            switch (scrLoc) {
                case ScreenLocation.Top:
                case ScreenLocation.Bottom:
                    if (scrLoc == ScreenLocation.Top)
                        this.location = new Vector2(state.Field.Center.X - 56, state.Field.Top + 50 - 8);
                    else
                        this.location = new Vector2(state.Field.Center.X - 56, state.Field.Bottom - 50 - 8);
                    this.locModif = new Vector2(-120, 9);
                    this.Bounds = new Rectangle(this.location.ToPoint(), new Point(112, 16));
                    this.rotation = (float)Math.PI / 2;
                    this.speed = state.Field.Width / 200;
                    break;
                case ScreenLocation.Left:
                case ScreenLocation.Right:
                    if (scrLoc == ScreenLocation.Left)
                        this.location = new Vector2(state.Field.Left + 50 - 8, state.Field.Center.Y - 56);
                    else
                        this.location = new Vector2(state.Field.Right - 50 - 8, state.Field.Center.Y - 56);
                    this.locModif = new Vector2(9, 8);
                    this.Bounds = new Rectangle(this.location.ToPoint(), new Point(16, 112));
                    this.speed = state.Field.Height / 200;
                    break;
            }
        }
        protected void MoveDown()
        {
            // Als onderkant (vandaar +96) van het plaatje hoger is
            // dan onderkant van het scherm, verplaats naar onder
            if (this.ScreenSide == ScreenLocation.Left || this.ScreenSide == ScreenLocation.Right) {
                if (this.location.Y + this.Bounds.Height + this.speed < MainProcess.GState.Field.Bottom) {
                    this.movement.Y = this.speed;
                } else {
                    this.movement.Y = MainProcess.GState.Field.Bottom - this.Bounds.Height - this.location.Y;
                }
            } else {
                if (this.location.X + this.Bounds.Width + this.speed < MainProcess.GState.Field.Right) {
                    this.movement.X = this.speed;
                } else {
                    this.movement.X = MainProcess.GState.Field.Right - this.Bounds.Width - this.location.X;
                }
            }
        }

        protected void MoveUp()
        {
            // Als bovenkant van het plaatje lager is dan
            // de bovenkant van het scherm, verplaats naar boven
            if (this.ScreenSide == ScreenLocation.Left || this.ScreenSide == ScreenLocation.Right) {
                if (this.location.Y - this.speed > MainProcess.GState.Field.Top) {
                    this.movement.Y = -this.speed;
                } else {
                    this.movement.Y = MainProcess.GState.Field.Top - this.location.Y;
                }
            } else {
                if (this.location.X - this.speed > MainProcess.GState.Field.Left) {
                    this.movement.X = -this.speed;
                } else {
                    this.movement.X = MainProcess.GState.Field.Left - this.location.X;
                }
            }
        }

        public override void Draw()
        {
            MainProcess.spriteBatch.Draw(this.view, this.location - this.locModif, null, null, null, this.rotation, null, null, this.effect);
        }
    }
}
