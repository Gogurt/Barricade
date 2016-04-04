using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Barricade
{
    class GameBoard
    {
        List<List<Corner>> n_CornerRows;
        List<Move> n_Moves;
        List<Move> n_RemainingMoves;
        List<Box> n_Boxes;

        readonly int n_Rows;
        readonly int n_Columns;
        readonly int n_PossibleLines;

        public GameBoard(int rows, int columns)
        {
            n_Rows = rows;
            n_Columns = columns;

            n_CornerRows = new List<List<Corner>>(n_Rows);
            for(int i = 0; i < n_Rows; i++)
            {
                List<Corner> row = new List<Corner>(n_Columns);
                for(int col = 0; col < n_Columns; col++)
                {
                    row.Add(new Corner(new Point(col, i)));
                }
                n_CornerRows.Add(row);
            }

            n_PossibleLines = ((n_Rows - 1) * n_Columns) + ((n_Columns - 1) * n_Rows);
            n_Moves = new List<Move>(n_PossibleLines);

            n_Boxes = new List<Box>((n_Rows - 1) * (n_Columns - 1));
        }

        public void drawBoard(Graphics g)
        {
            for(int i = 0; i < n_Rows; i++)
            {
                List<Corner> row = n_CornerRows[i];
                foreach(Corner c in row)
                {
                    c.DrawDot(c.getLocation(), g);
                }
            }
        }



    }
}
