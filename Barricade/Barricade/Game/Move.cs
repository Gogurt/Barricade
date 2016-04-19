using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barricade
{
    /// <summary>
    /// Move class for creating move objects
    /// </summary>
    class Move
    {
        Line Line;
        Player Player;

        /// <summary>
        /// Move base constructor
        /// Assigns player to null
        /// </summary>
        /// <param name="line"></param>
        public Move(Line line)
            : this(line, null)
        {
        }
        
        /// <summary>
        /// Move constructor 
        /// </summary>
        /// <param name="line"></param>
        /// <param name="player"></param>
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

        public void setPlayer(Player p)
        {
            Player = p;
        }
    }
}
