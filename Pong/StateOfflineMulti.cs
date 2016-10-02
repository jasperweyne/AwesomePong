using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace Pong
{
    class StateOfflineMulti: GameState
    {
        public StateOfflineMulti()
        {
            this.Field = new Rectangle(0, 50, MainProcess.graphics.GraphicsDevice.Viewport.Width, MainProcess.graphics.GraphicsDevice.Viewport.Height - 50);
            this.Elems.Add(new PlayablePlayer(this, MainProcess.PlayerTex, Keys.S, Keys.W, Player.ScreenLocation.Left, Color.Yellow));
            this.Elems.Add(new PlayablePlayer(this, MainProcess.PlayerTex, Keys.Down, Keys.Up, Player.ScreenLocation.Right, Color.Blue));
            this.Elems.Add(new Ball(this, MainProcess.BallTex));
        }
    }
}
