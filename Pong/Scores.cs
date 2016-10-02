using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Pong
{
    class Scores: State
    {
        private SortedList<int, Color> scores = new SortedList<int, Color>();
        private bool enter = false;

        public void SetScore(Color col, int score)
        {
            scores.Add(score, col);
        }

        public override void Draw()
        {
            int top = MainProcess.graphics.GraphicsDevice.Viewport.Bounds.Center.Y - 40 * scores.Count / 2;
            int cx = MainProcess.graphics.GraphicsDevice.Viewport.Bounds.Center.X;
            int i = 1;
            float textW = MainProcess.FuckingPrettyFont.MeasureString("Press enter to return to menu.").X;
            MainProcess.spriteBatch.DrawString(MainProcess.FuckingPrettyFont, "Press enter to return to menu.", new Vector2(cx - textW / 2, top - 50), Color.White);
            foreach (KeyValuePair<int, Color> elem in this.scores) {
                string text;
                switch (i) {
                    case 1:
                        text = "1st place: " + elem.Key.ToString();
                        break;
                    case 2:
                        text = "2nd place: " + elem.Key.ToString();
                        break;
                    case 3:
                        text = "3rd place: " + elem.Key.ToString();
                        break;
                    default:
                        text = i.ToString() + "th place: " + elem.Key.ToString();
                        break;
                }
                textW = MainProcess.FuckingPrettyFont.MeasureString(text).X;
                MainProcess.spriteBatch.DrawString(MainProcess.FuckingPrettyFont, text, new Vector2(cx - textW / 2, top + 40 * i), elem.Value);
                ++i;
            }
        }

        public override void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                enter = true;
            else if (enter)
                MainProcess.State = new MainMenu();
        }
    }
}
