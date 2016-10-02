﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace Pong
{
    class MainMenu: State
    {
        List<PlayerDef> players = new List<PlayerDef>() {
            new PlayerDef(PlayerType.Playable, 0, Player.ScreenLocation.Left, KeySet.set1),
            new PlayerDef(PlayerType.AI, 1, Player.ScreenLocation.Right, KeySet.set2),
            new PlayerDef(PlayerType.None, 2, Player.ScreenLocation.Top, KeySet.set3),
            new PlayerDef(PlayerType.None, 3, Player.ScreenLocation.Bottom, KeySet.set4),
        };

        struct KeySet
        {
            public Keys up;
            public Keys down;
            public Keys left;
            public Keys right;
            public static KeySet set1 = new KeySet(Keys.W, Keys.S, Keys.A, Keys.D);
            public static KeySet set2 = new KeySet(Keys.Up, Keys.Down, Keys.Left, Keys.Right);
            public static KeySet set3 = new KeySet(Keys.G, Keys.B, Keys.V, Keys.N);
            public static KeySet set4 = new KeySet(Keys.D9, Keys.O, Keys.I, Keys.P);

            public KeySet(Keys up, Keys down, Keys left, Keys right)
            {
                this.up = up;
                this.down = down;
                this.left = left;
                this.right = right;
            }
        }

        struct PlayerDef
        {
            public static Color[] colors = new Color[] {
                Color.Yellow,
                Color.Blue,
                Color.White,
                Color.Green,
                Color.Orange,
                Color.Black,
                Color.Cyan,
                Color.Purple
            };
            public PlayerType type;
            public int color;
            public Player.ScreenLocation loc;
            public KeySet keys;

            public PlayerDef(PlayerType type, int colId, Player.ScreenLocation loc, KeySet keys)
            {
                this.type = type;
                this.color = colId % colors.Count();
                this.loc = loc;
                this.keys = keys;
            } 
        }
        private enum PlayerType
        {
            None,
            Playable,
            AI
        }

        private void nextColor(PlayerDef p)
        {
            while (players.Any(player => player.color == ++p.color));
        }

        private void prevColor(PlayerDef p)
        {
            while (players.Any(player => player.color == --p.color));
        }

        public override void Update()
        {

            if (Keyboard.GetState().IsKeyDown(Keys.Enter)) {
                MainProcess.State = new GameState();
                foreach (PlayerDef def in players.Where(player => player.type != PlayerType.None)) {
                    if (def.type == PlayerType.Playable)
                        if (def.loc == Player.ScreenLocation.Left || def.loc == Player.ScreenLocation.Right)
                            MainProcess.GState.Elems.Add(new PlayablePlayer(MainProcess.PlayerTex, def.keys.down, def.keys.up, def.loc, PlayerDef.colors[def.color]));
                        else
                            MainProcess.GState.Elems.Add(new PlayablePlayer(MainProcess.PlayerTex, def.keys.right, def.keys.left, def.loc, PlayerDef.colors[def.color]));
                    else
                        MainProcess.GState.Elems.Add(new AIPlayer(MainProcess.PlayerTex, def.loc, PlayerDef.colors[def.color]));
                }
                MainProcess.GState.Elems.Add(new Ball(MainProcess.BallTex));
                MainProcess.GState.Load();
            }
        }
        public override void Draw()
        {
            Vector2 pos = new Vector2(MainProcess.graphics.GraphicsDevice.Viewport.Width / 2 - MainProcess.TitleTex.Width / 2, 25 - MainProcess.TitleTex.Height / 2);
            MainProcess.spriteBatch.Draw(MainProcess.TitleTex, pos, Color.White);
            MainProcess.spriteBatch.DrawString(MainProcess.FuckingPrettyFont, "Press enter to start", new Vector2(260, MainProcess.graphics.GraphicsDevice.Viewport.Height / 2 + 30), Color.White);
        }
    }
}
