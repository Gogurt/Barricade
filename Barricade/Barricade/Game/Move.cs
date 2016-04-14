using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barricade
{
    class Move
    {
        Line Line;
        Player Player;

        public Move(Line line, Player player)
        {
            Line = line;
            Player = player;
        }

        public Line getLine
        {
            get { return Line; }
        }

        public Player getPlayer
        {
            get { return Player; }
        }
    }
}
