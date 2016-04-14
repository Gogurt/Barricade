using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Barricade
{
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

        public Line(Corner c1, Corner c2)
        {
            Start = c1;
            End = c2;
            Color = Color.Black;
            startX = Start.getLocation().X;
            startY = Start.getLocation().Y;
            endX = End.getLocation().X;
            endY = End.getLocation().Y;
            Rec = new Rectangle(startX, startY, endX - startX, endY - startY);
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

        public bool Vertical
        {
            get
            {
                return Start.getLocation().X == End.getLocation().X;
            }
        }

        public void drawLine(Graphics g)
        {
            g.DrawRectangle(Pens.Black, Rec);
        }

        public void Select()
        {
            Selected = true;
        }
    }
}
