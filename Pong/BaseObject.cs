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
    public abstract class BaseObject
    {
        protected Vector2 location;
        protected Texture2D view;
        protected float rotation = 0.0f;
        protected SpriteEffects effect = SpriteEffects.None;

        public void SetTexture(Texture2D tex)
        {
            this.view = tex;
        }

        public virtual void Update() { }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(view, location, null, null, null, rotation, null, null, effect);
        }

    }
}
