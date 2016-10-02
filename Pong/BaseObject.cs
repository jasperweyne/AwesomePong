using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
        protected Vector2 movement = Vector2.Zero;

        public Vector2 Movement
        {
            get {
                return this.movement;
            }
        }

        public BaseObject(Texture2D tex)
        {
            this.view = tex;
        }

        public virtual void Update() { }
        public virtual void Draw()
        {
            MainProcess.spriteBatch.Draw(view, location, null, null, null, rotation, null, null, effect);
        }

    }
}
