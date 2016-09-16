using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    class BasePlayer
    {
        /*
         * The percentage that the player moved around the screen on his axis 
         * 
         * @value: 0 <= moved <= 1
         */
        private float moved;
        
        /*
         * Whether the player moves along the x-axis or y-axis
         * 
         * @value:
         * true:  x-axis
         * false: y-axis
         */
        private bool x_y;

        /*
         * The percentage on screen of the width of the player
         * 
         * @value 0 <= width <= 1
         */ 
        private const float width = 0.2f;

        /*
         * The amount of pixels on screen of the depth of the player
         * 
         * @value 0 < depth 
         */
        private const int depth = 50;

        /*
         * The speed of the player
         * 
         * @value dunno yet?
         */
        private const int speed = 200;
    }
}
