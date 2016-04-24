using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Barricade
{
    /// <summary>
    /// Line class for creating line objects
    /// </summary>
    class Line
    {
        Corner Start;
        Corner End;
        Rectangle Rec;

        Color Color;
        bool Selected;

        public int startX;
        public int startY;
        public int endX;
        public int endY;

        /// <summary>
        /// Line constructor
        /// Takes two corners and creates a rectangle between them
        /// Default color is black
        /// Line is not selected by default
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        public Line(Corner c1, Corner c2)
        {
            Start = c1;
            End = c2;
            Color = Color.White;
            startX = Start.getLocation().X;
            startY = Start.getLocation().Y;
            endX = End.getLocation().X;
            endY = End.getLocation().Y;
            if (this.Vertical)
                Rec = new Rectangle(startX, startY + 10, 10, 30);
            else
                Rec = new Rectangle(startX + 10, startY, 30, 10);
            Selected = false;
        }

        public void setColor(Color color)
        {
            Color = color;
        }

        public int getBottom()
        {
            return Rec.Bottom;
        }

        public int getTop()
        {
            return Rec.Top;
        }
        public bool isSelected()
        {
            return Selected;
        }

        public Corner getStart
        {
            get
            {
                return Start;
            }
        }

        public Corner getEnd
        {
            get
            {
                return End;
            }
        }

        public Rectangle Rectangle
        {
            get
            {
                return Rec;
            }
        }

        /// <summary>
        /// Checks if the Line rectangle is vertical
        /// </summary>
        public bool Vertical
        {
            get
            {
                return Start.getLocation().X == End.getLocation().X;
            }
        }

        /// <summary>
        /// Draws the line rectangle to the board screen
        /// </summary>
        /// <param name="g"></param>
        public void drawLine(Graphics g, SolidBrush brush)
        {
            g.FillRectangle(brush, Rec);
        }

        /// <summary>
        /// Selects the Line for if a player clicks on it
        /// </summary>
        public void Select(Color color)
        {
            Selected = true;
            this.setColor(color);
        }

        public bool Equals(Line other)
        {
            if (startX == other.startX && startY == other.startY
                && endX == other.endX && endY == other.endY)
                return true;
            else
                return false;
        }
    }
}
