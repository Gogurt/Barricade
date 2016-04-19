using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Barricade
{
    /// <summary>
    /// Corner class for creating corner objects
    /// </summary>
    class Corner
    {
        Point Location;

        /// <summary>
        /// Corner constructor
        /// Assigns a location for the point
        /// </summary>
        /// <param name="location"></param>
        public Corner(Point location)
        {
            Location = location;
        }

        /// <summary>
        /// DrawDot method used for drawing the corner object onto the board screen
        /// </summary>
        /// <param name="p"></param>
        /// <param name="g"></param>
        public void DrawDot(Point p, Graphics g)
        {
            p.Offset(-1, -1);
            g.DrawRectangle(Pens.Black, new Rectangle(p, new Size(5, 5)));
            
        }

        public Point getLocation()
        {
            return Location;
        }
    }
}
