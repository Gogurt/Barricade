using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barricade.Game_Logic
{
    class Game
    {
        public Game()
        {
            //Constructor

        }

        public List<List<String>> hostUpdateBoard(String d, int x, int y)
        {
            //Takes a direction and x and y coordinates in and updates the board.
            List<List<String>> board = new List<List<String>>();

            return board;
        }

        public List<List<String>> clientUpdateBoard(String d, int x, int y)
        {
            //Takes a direction and x and y coordinates in and updates the board.
            List<List<String>> updatedBoard = new List<List<String>>();

            return updatedBoard;
        }

        public String writeBoard()
        {
            //Creates a string version of the board.
            String board = "";

            return board;
        }

        public List<List<String>> readBoard(String board)
        {
            //Takes in a string version of the board and updates the board array
            List<List<String>> newBoard = new List<List<String>>();

            return newBoard;
        }

        public void hostBroadcastBoard()
        {
            //Sends out the string from the writeBoard() function to the clients.

        }
    }
}
