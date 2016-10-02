using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;

namespace Pong
{
    class AIPlayer : Player
    {
        public AIPlayer(Texture2D tex, ScreenLocation scrLoc, Color color) : base(tex, scrLoc, color)
        {
        }

        public override void Update()
        {
            this.movement = Vector2.Zero;
            switch (this.ScreenSide) {
                case ScreenLocation.Top:
                case ScreenLocation.Bottom:
                    if (this.Bounds.Center.X < MainProcess.GState.Elems.OfType<Ball>().Single<Ball>().GetBounds().Center.X)
                        this.MoveDown();
                    else
                        this.MoveUp();
                    break;
                case ScreenLocation.Left:
                case ScreenLocation.Right:
                    if (this.Bounds.Center.Y < MainProcess.GState.Elems.OfType<Ball>().Single<Ball>().GetBounds().Center.Y)
                        this.MoveDown();
                    else
                        this.MoveUp();
                    break;
            }
            this.location += this.movement;
            UpdateBounds();
        }
    }
}
