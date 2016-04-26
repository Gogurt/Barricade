using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Barricade.Game
{
    /// <summary>
    /// Game class handles all the game logic including the gameboard, players, and moves
    /// </summary>
    class Game
    {
        List<Player> Players;
        GameBoard Gameboard;

        int currentPlayer = 0;
        int movesPerTurn = 1;

        SolidBrush brush;

        /// <summary>
        /// Game Constructor
        /// Instantiates the gameboard and a list of players
        /// </summary>
        /// <param name="players"></param>
        /// <param name="board"></param>
        public Game(List<Player> players, GameBoard board)
        {
            Gameboard = board;
            Players = new List<Player>(players.Count);
            foreach(Player p in players)
            {
                Players.Add(p);
            }
        }

        /// <summary>
        /// returns player whose move it is
        /// </summary>
        public Player CurrentPlayer
        {
            get
            {
                return Players[currentPlayer];
            }
        }

        /// <summary>
        /// returns the next player whose move it is
        /// </summary>
        /// <returns></returns>
        public Player NextPlayer()
        {
            currentPlayer++;
            if(currentPlayer >= Players.Count)
            {
                currentPlayer = 0;
            }

            return CurrentPlayer;
        }

        /// <summary>
        /// Start function
        /// Handles the game functionality when the game begins including player turn loops and endgame scenario
        /// </summary>
        /// <param name="g"></param>
        public void Start(Graphics g)
        {
            brush = new SolidBrush(Color.White);

            Gameboard.drawBoard(g);
            Gameboard.addLines();
            Gameboard.drawLines(g, brush);

            int playerMovesRemaining = movesPerTurn;

            while (Gameboard.MovesRemaining > 0)
            {
                Move move = null;
                int moveScore;
                while (true)
                {
                    
                    move = getNextMove();
                    if (move != null)
                    {
                        brush = new SolidBrush(Color.DarkGray);
                        move.getLine.drawLine(g, brush);
                        break;
                    }

                }

                moveScore = Gameboard.MakeMove(move, CurrentPlayer);
                playerMovesRemaining--;

                if(moveScore == 1)
                {
                    brush = null;
                    Gameboard.drawBoxes(g, brush);
                    playerMovesRemaining++;
                }

                if (playerMovesRemaining == 0)
                {
                    NextPlayer();
                    playerMovesRemaining = movesPerTurn;
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (Player p in Players)
            {
                sb.AppendFormat("{0}: {1}\n", p.getName, p.getScore);
            }

            System.Windows.Forms.MessageBox.Show(sb.ToString());
        }

        Move getNextMove()
        {
            Move move = null;

            foreach(Move m in Gameboard.AvailableMoves)
            {
                if(m.getLine.isSelected())
                {
                    move = m;
                    break;
                }
            }

            return move;
        }
    }
}
