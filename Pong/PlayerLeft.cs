using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    class PlayerLeft : BasePlayer
    {
        public PlayerLeft()
        {
            this.location = new Vector2(50, 300);
        }

        public override void Update()
        {
            KeyboardState state = Keyboard.GetState(50);
            if (state.IsKeyDown(Keys.S))
            {
                this.location.Y += 5;
            }
            if (state.IsKeyDown(Keys.W))
            {
                this.location.Y -= 5;
            }
        }
    }
}
