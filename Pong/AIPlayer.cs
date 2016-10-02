using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
    class AIPlayer : Player
    {
        public AIPlayer(GameState state, Texture2D tex, ScreenLocation scrLoc) : base(state, tex, scrLoc)
        {
        }

        public override void Update()
        {
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
            UpdateBounds();
        }
    }
}
