using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Net.Sockets;

namespace Barricade
{
    /// <summary>
    /// Player class for creating player objects
    /// </summary>
    class Player
    {
        string Name;
        Color Color;
        int Score;

        //Net Info
        Socket playerSocket;

        /// <summary>
        /// Player constructor 
        /// Players have names, a color, and a score
        /// </summary>
        /// <param name="name"></param>
        /// <param name="color"></param>
        /// <param name="score"></param>
        public Player(string name, Color color, Socket playerSocket)
        {
            Name = name;
            Color = color;
            Score = 0;

            this.playerSocket = playerSocket;
        }

        public string getName
        {
            get { return Name; }
        }

        public System.Drawing.Color getColor
        {
            get { return Color; }
        }

        public int getScore
        {
            get
            {
                return Score;
            }
        }

        /// <summary>
        /// Adds a specified score to a player's score count
        /// </summary>
        /// <param name="score"></param>
        /// <returns>updated score</returns>
        public int AddScore(int score)
        {
            return (Score += score);
        }
    }
}
