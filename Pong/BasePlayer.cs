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
        float moved;
        
        /*
         * Whether the player moves along the x-axis or y-axis
         * 
         * @value:
         * true:  x-axis
         * false: y-axis
         */
        bool x_y;

        /*
         * The percentage on screen of the width of the player
         * 
         * @value 0 <= width <= 1
         */ 
        float width;

        /*
         * The amount of pixels on screen of the depth of the player
         * 
         * @value 0 < depth 
         */
        float depth;

    }
}
