﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

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
