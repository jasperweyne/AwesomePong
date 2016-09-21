using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    class PlayerRight : BasePlayer
    {
        public PlayerRight()
        {
            this.location = new Vector2(450, 300);
        }

        public override void Update()
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Down))
            {
                this.location.Y += 5;
            }
            if (state.IsKeyDown(Keys.Up))
            {
                this.location.Y -= 5;
            }
        }
    }
}
