using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Barricade
{
    class Corner
    {
        Point Location;

        public Corner(Point location)
        {
            Location = location;
        }

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
