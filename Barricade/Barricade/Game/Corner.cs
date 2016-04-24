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
            SolidBrush brush = new SolidBrush(Color.Black);
            g.FillRectangle(brush, new Rectangle(p, new Size(10, 10)));
        }

        public Point getLocation()
        {
            return Location;
        }

        public Point LowerRight
        {
            get
            {
                return new Point(Location.X + 9, Location.Y + 9);
            }
        }

        public Point LowerLeft
        {
            get
            {
                return new Point(Location.X, Location.Y + 9);
            }
        }

        public Point UpperRight
        {
            get
            {
                return new Point(Location.X + 9, Location.Y);
            }
        }

        public bool Equals(Corner other)
        {
            return Location == (other.Location);
        }
    }
}
