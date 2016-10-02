using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    class PlayablePlayer: Player
    {
        private Keys down;
        private Keys up;

        public PlayablePlayer(GameState state, Texture2D tex, Keys down, Keys up, ScreenLocation scrLoc) : base(state, tex, scrLoc)
        {
            this.down = down;
            this.up = up;
        }

        public override void Update()
        {
            this.movement = Vector2.Zero;
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(this.down))
            {
                this.MoveDown();
            }
            if (state.IsKeyDown(this.up))
            {
                this.MoveUp();
            }
            this.location += this.movement;
            UpdateBounds();
        }
    }
}
