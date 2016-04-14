using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Barricade
{
    class Box
    {
        Line Top;
        Line Bottom;
        Line Left;
        Line Right;

        Player Player;

        Rectangle Rec;

        public Box(Line top, Line left, Line bottom, Line right, Player player)
        {
            Top = top;
            Left = left;
            Bottom = bottom;
            Right = right;
            Rec = new Rectangle(top.startX, top.startY, left.getTop(), bottom.getTop());

            Player = player;
        }

        public void drawBox(Graphics g)
        {
            SolidBrush playerBrush = new SolidBrush(Player.getColor);
            g.FillRectangle(playerBrush, Rec);
        }

        public Line getTop
        {
            get { return Top; }
        }

        public Line getBottom
        {
            get { return Bottom; }
        }

        public Line getLeft
        {
            get { return Left; }
        }

        public Line getRight
        {
            get { return Right; }
        }


    }
}
