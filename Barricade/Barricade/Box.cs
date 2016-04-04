using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barricade
{
    class Box
    {
        Line Top;
        Line Bottom;
        Line Left;
        Line Right;

        Player Player;

        public Box(Line top, Line left, Line bottom, Line right, Player player)
        {
            Top = top;
            Left = left;
            Bottom = bottom;
            Right = right;

            Player = player;
        }


    }
}
