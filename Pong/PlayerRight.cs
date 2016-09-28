using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    class PlayerRight : Player
    {
        public PlayerRight()
        {
            this.location = new Vector2(750, 50);
        }

        public override void Update()
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Down))
            {
                this.MoveDown();
            }
            if (state.IsKeyDown(Keys.Up))
            {
                this.MoveUp();
            }
        }
    }
}
