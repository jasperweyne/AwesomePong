using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Pong
{
    /// <summary>
    ///  Base class for all player types
    /// </summary>
    abstract class BasePlayer
    {
        protected Vector2 location;
        private Texture2D view;

        public BasePlayer(Texture2D tex)
        {
            this.view = tex;
        }

        public abstract void Update();
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(view, location, Color.White);
        }

    }
}
