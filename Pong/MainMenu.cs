using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace Pong
{
    class MainMenu: State
    {
        List<PlayerDef> players = new List<PlayerDef>() {
            new PlayerDef(1, 0, Player.ScreenLocation.Left, KeySet.set1),
            new PlayerDef(2, 1, Player.ScreenLocation.Right, KeySet.set2),
            new PlayerDef(0, 2, Player.ScreenLocation.Top, KeySet.set3),
            new PlayerDef(0, 3, Player.ScreenLocation.Bottom, KeySet.set4),
        };
        class KeyManager
        {
            public bool wasUp = false;
            public bool wasDown = false;
            public bool wasLeft = false;
            public bool wasRight = false;
        }

        struct KeySet
        {
            public KeyManager m;
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
                m = new KeyManager();
            }
        }

        class PlayerDef
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
            public int type;
            public int color;
            public Player.ScreenLocation loc;
            public KeySet keys;

            public PlayerDef(int type, int colId, Player.ScreenLocation loc, KeySet keys)
            {
                this.type = type;
                this.color = colId % colors.Count();
                this.loc = loc;
                this.keys = keys;
            } 
        }

        private void nextColor(PlayerDef p)
        {
            p.color = (p.color + 1) % PlayerDef.colors.Count();
            //while (players.Any(player => player.color == p.color)) {
                //p.color = (p.color + 1) % PlayerDef.colors.Count();
            //}
        }

        private void prevColor(PlayerDef p)
        {
            p.color = (p.color - 1) % PlayerDef.colors.Count();
            //while (players.Any(player => player.color == p.color)) {
                //p.color = (p.color - 1) % PlayerDef.colors.Count();
            //}
        }

        public override void Update()
        {
            KeyboardState state = Keyboard.GetState();
            foreach (PlayerDef def in players) {
                if (state.IsKeyDown(def.keys.left)) {
                    def.keys.m.wasLeft = true;
                } else if (def.keys.m.wasLeft) {
                    prevColor(def);
                    def.keys.m.wasLeft = false;
                }
                if (state.IsKeyDown(def.keys.right)) {
                    def.keys.m.wasRight = true;
                } else if (def.keys.m.wasRight) {
                    nextColor(def);
                    def.keys.m.wasRight = false;
                }
                if (state.IsKeyDown(def.keys.up)) {
                    def.keys.m.wasUp = true;
                } else if (def.keys.m.wasUp) {
                    def.type = (def.type - 1) % 3;
                    def.keys.m.wasUp = false;
                }
                if (state.IsKeyDown(def.keys.down)) {
                    def.keys.m.wasDown = true;
                } else if (def.keys.m.wasDown) {
                    def.type = (def.type + 1) % 3;
                    def.keys.m.wasDown = false;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Enter)) {
                MainProcess.State = new GameState();
                foreach (PlayerDef def in players.Where(player => player.type != 0)) {
                    if (def.type == 1)
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
            MainProcess.spriteBatch.DrawString(MainProcess.FuckingPrettyFont, "Press enter to start", new Vector2(260, MainProcess.graphics.GraphicsDevice.Viewport.Bounds.Bottom - 50), Color.White);
            int i = 0;
            int top = MainProcess.graphics.GraphicsDevice.Viewport.Bounds.Center.Y - 40 * players.Count / 2;
            int cx = MainProcess.graphics.GraphicsDevice.Viewport.Bounds.Center.X;
            foreach (PlayerDef def in players) {
                string text = "Player (" + def.keys.up.ToString() + def.keys.left.ToString() + def.keys.down.ToString() + def.keys.right.ToString() + "): ";
                switch (def.type) {
                    case 2:
                        text += "AI ";
                        break;
                    case 1:
                        text += "Player ";
                        break;
                    case 0:
                        text += "Disabled ";
                        break;
                }
                switch (def.loc) {
                    case Player.ScreenLocation.Top:
                        text += ">Top";
                        break;
                    case Player.ScreenLocation.Bottom:
                        text += ">Bottom";
                        break;
                    case Player.ScreenLocation.Left:
                        text += ">Left";
                        break;
                    case Player.ScreenLocation.Right:
                        text += ">Right";
                        break;
                }
                float textW = MainProcess.FuckingPrettyFont.MeasureString(text).X;
                MainProcess.spriteBatch.DrawString(MainProcess.FuckingPrettyFont, text, new Vector2(cx - textW / 2, top + 40 * i), PlayerDef.colors[def.color]);
                ++i;
            }
        }
    }
}
