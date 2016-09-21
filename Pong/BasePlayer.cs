using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Pong
{
    /// <summary>
    ///  Base class for all player types
    /// </summary>
    abstract class BasePlayer
    {
        protected Vector2 location;

        public abstract void Update();
    }
}
