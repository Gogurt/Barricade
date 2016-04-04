using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Barricade
{
    class Player
    {
        string Name;
        Color Color;
        int Score;

        protected Player(string name, Color color, int score)
        {
            Name = name;
            Color = color;
            Score = score;
        }

        public string getName
        {
            get { return Name; }
        }

        public System.Drawing.Color getColor
        {
            get { return Color; }
        }

        public int AddScore(int score)
        {
            return (Score += score);
        }
    }
}
