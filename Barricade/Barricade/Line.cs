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

        int startX;
        int startY;
        int endX;
        int endY;

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
