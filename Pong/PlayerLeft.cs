using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    class PlayerLeft : Player
    {
        public PlayerLeft()
        {
            this.location = new Vector2(50, 300);
        }

        public override void Update()
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.S))
            {
                this.MoveDown();
            }
            if (state.IsKeyDown(Keys.W))
            {
                this.MoveUp();
            }
        }
    }
}
