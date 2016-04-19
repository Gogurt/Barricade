using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Barricade
{
    /// <summary>
    /// Box class for creating Box objects
    /// </summary>
    class Box
    {
        Line Top;
        Line Bottom;
        Line Left;
        Line Right;

        Player Player;

        Rectangle Rec;

        /// <summary>
        /// Box Constructor
        /// Takes four line objects and creates a box rectangle out of them
        /// </summary>
        /// <param name="top"></param>
        /// <param name="left"></param>
        /// <param name="bottom"></param>
        /// <param name="right"></param>
        /// <param name="player"></param>
        public Box(Line top, Line left, Line bottom, Line right, Player player)
        {
            Top = top;
            Left = left;
            Bottom = bottom;
            Right = right;
            Rec = new Rectangle(top.startX, top.startY, left.getTop(), bottom.getTop());

            Player = player;
        }

        /// <summary>
        /// drawBox method for drawing a filled in box on the board screen
        /// </summary>
        /// <param name="g"></param>
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
