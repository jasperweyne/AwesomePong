using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    /// <summary>
    ///  Base class for all player types
    /// </summary>
    class BasePlayer
    {
        /// <summary>
        ///  The percentage that the player has moved with respect to his axis 
        /// </summary>
        /// <remarks>
        ///  Values: 0 &lt;= moved &lt;= 1
        /// </remarks>
        private float moved;
        
        /// <summary>
        ///  Boolean whether the player moves along the x-axis or y-axis
        /// </summary>
        /// <remarks>
        ///  Values:
        ///    true:  x-axis
        ///    false: y-axis
        /// </remarks>
        private bool x_y;
        
        /// <summary>
        ///  The percentage on screen of the width of the player
        /// </summary>
        /// <remarks>
        ///  Values: 0 &lt;= width &lt;= 1
        /// </remarks>
        private const float width = 0.2f;
        
        /// <summary>
        ///  The amount of pixels on screen of the depth of the player
        /// </summary>
        /// <remarks>
        ///  Values: 0 &lt;= width &lt;= 1
        /// </remarks>
        private const int depth = 50;

        /// <summary>
        ///  The speed of the player
        /// </summary>
        private const int speed = 200;
    }
}
