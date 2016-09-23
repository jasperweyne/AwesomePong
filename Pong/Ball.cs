using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
    class Ball : BaseObject
    {
        public Ball(Texture2D tex) : base(tex)
        {
            this.location = new Vector2(400, 240);
        }

        public override void Update()
        {
            // dingen, nu nog niks
        }
    }
}
