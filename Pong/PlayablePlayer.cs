using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    class PlayablePlayer: Player
    {
        private Keys down;
        private Keys up;

        public PlayablePlayer(Keys down, Keys up, Vector2 loc) : base(loc)
        {
            this.down = down;
            this.up = up;
        }

        public override void Update()
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(this.down))
            {
                this.MoveDown();
            }
            if (state.IsKeyDown(this.up))
            {
                this.MoveUp();
            }
            UpdateBounds();
        }
    }
}
