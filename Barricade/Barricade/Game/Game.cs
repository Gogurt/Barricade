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

        /// <summary>
        /// Game Constructor
        /// Instantiates the gameboard and a list of players
        /// </summary>
        /// <param name="players"></param>
        /// <param name="board"></param>
        public Game(Player[] players, GameBoard board)
        {
            Gameboard = board;
            Players = new List<Player>(players.Length);
            foreach(Player p in players)
            {
                Players.Add(p);
            }
        }

        /// <summary>
        /// returns player whose move it is
        /// </summary>
        private Player CurrentPlayer
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
        private Player NextPlayer()
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
            Gameboard.drawBoard(g);
            Gameboard.addLines();
            Gameboard.drawLines(g);

            int playerMovesRemaining = movesPerTurn;
            while(Gameboard.MovesRemaining > 0)
            {
                Move move = null;
                while(true)
                {
                    //Handle player line click event
                    break;
                }

                playerMovesRemaining--;

                //Handle box creation equals extra move

                //Handle update to gameboard

                if(playerMovesRemaining == 0)
                {
                    NextPlayer();
                    playerMovesRemaining = movesPerTurn;
                }
            }
        }
    }
}
