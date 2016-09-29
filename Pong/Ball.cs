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
        private Vector2 movement = new Vector2(-3, 0);

        public Ball()
        {
            this.location = new Vector2(400, 240);
        }

        public override void Update()
        {
            this.location += this.movement;
        }
    }
}
