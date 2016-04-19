using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Barricade
{
    /// <summary>
    /// GameBoard class handles setup of the game including drawing lines and corners, and checking for a completed box
    /// </summary>
    class GameBoard
    {
        public enum MoveDirection
        {
            Up,
            Down,
            Left,
            Right
        }

        List<List<Corner>> n_CornerRows;
        List<List<Corner>> n_CornerColumns;
        List<Line> lines;
        List<Move> n_Moves;
        List<Move> n_RemainingMoves;
        List<Box> n_Boxes;

        readonly int n_Rows;
        readonly int n_Columns;
        readonly int n_PossibleLines;

        /// <summary>
        /// GameBoard Constructor
        /// Creates a game board based on rows and columns 
        /// Specifies a list of corners for the board
        /// Creates empty lists for moves and boxes
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        public GameBoard(int rows, int columns)
        {
            n_Rows = rows;
            n_Columns = columns;

            n_CornerRows = new List<List<Corner>>(n_Rows);
            n_CornerColumns = new List<List<Corner>>(n_Columns);
            for(int i = 0; i < n_Rows; i++)
            {
                List<Corner> row = new List<Corner>(n_Columns);
                for(int col = 0; col < n_Columns; col++)
                {
                    row.Add(new Corner(new Point(col, i)));
                }
                n_CornerRows.Add(row);
            }

            for(int col = 0; col < n_Columns; col++)
            {
                List<Corner> column = new List<Corner>(n_Rows);
                for(int i = 0; i < n_Rows; i++)
                {
                    column.Add(new Corner(new Point(i, col)));
                }
                n_CornerColumns.Add(column);
            }

            n_PossibleLines = ((n_Rows - 1) * n_Columns) + ((n_Columns - 1) * n_Rows);
            n_Moves = new List<Move>(n_PossibleLines);
            lines = new List<Line>(n_PossibleLines);

            n_Boxes = new List<Box>((n_Rows - 1) * (n_Columns - 1));
        }

        /// <summary>
        /// returns remaining number of moves
        /// </summary>
        public int MovesRemaining
        {
            get
            {
                return n_PossibleLines - n_Moves.Count;
            }
        }

        /// <summary>
        /// returns a list of moves that can still be made
        /// </summary>
        public List<Move> AvailableMoves
        {
            get
            {
                return n_RemainingMoves;
            }
        }

        /// <summary>
        /// returns a list of moves that have been made
        /// </summary>
        public List<Move> Moves
        {
            get
            {
                return n_Moves;
            }
        }

        /// <summary>
        /// Takes a move by a player and adds it to the moves list and removes it from available moves
        /// Checks if the move made a box using other functions
        /// Gives players points if they made a box
        /// </summary>
        /// <param name="move"></param>
        /// <param name="p"></param>
        public void MakeMove(Move move, Player p)
        {
            List<Box> results = SpeculateMove(move, p);
            foreach(Move m in AvailableMoves)
            {
                if(move.getLine.Equals(m.getLine))
                {
                    m.setPlayer(p);
                    AvailableMoves.Remove(m);
                    Moves.Add(m);
                    break;
                }
            }

            if(results.Count > 0)
            {
                foreach(Box b in results)
                {
                    n_Boxes.Add(b);
                }

                p.AddScore(results.Count);
            }
        }

        /// <summary>
        /// Fills the list of remaining moves with move objects
        /// </summary>
        void PopulateAvailableMoves()
        {
            n_RemainingMoves = new List<Move>(n_PossibleLines);
            foreach(Line l in lines)
            {
                Move m = new Move(l);
                n_RemainingMoves.Add(m);
            }
        }

        /// <summary>
        /// Draws the corners onto the board screen
        /// </summary>
        /// <param name="g"></param>
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

        /// <summary>
        /// Adds lines both vertically and horizontally based on the two lists of corners to the list of lines
        /// </summary>
        public void addLines()
        {
            for (int i = 0; i < n_Rows; i++)
            {
                List<Corner> row = n_CornerRows[i];
                for (int j = 0; j < row.Count - 1; j++)
                {
                    Line line = new Line(row[j], row[j + 1]);
                    lines.Add(line);
                }
            }

            for(int i = 0; i < n_Columns; i++)
            {
                List<Corner> col = n_CornerColumns[i];
                for(int j = 0; j < col.Count - 1; j++)
                {
                    Line line = new Line(col[j], col[j + 1]);
                    lines.Add(line);
                }
            }
        }

        /// <summary>
        /// Goes through the list of lines and draws each to the board screen
        /// </summary>
        /// <param name="g"></param>
        public void drawLines(Graphics g)
        {
            foreach(Line l in lines)
            {
                l.drawLine(g);
            }
        }

        /// <summary>
        /// Checks if each line in a box is selected
        /// </summary>
        /// <param name="upper"></param>
        /// <param name="lower"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>true if they are selected, false otherwise</returns>
        public bool MakesBox(Line upper, Line lower, Line left, Line right)
        {
            bool makesBox = false;

            if (upper.isSelected() && lower.isSelected() && left.isSelected() && right.isSelected())
                makesBox = true;

            return makesBox;
        }

        /// <summary>
        /// Takes the line from a move and checks any adjacent boxes lines
        /// If these lines make a box, a box object is created and assigned to the player that made the move
        /// </summary>
        /// <param name="move"></param>
        /// <param name="direction"></param>
        /// <returns>A box object</returns>
        Box CreateBox(Move move, MoveDirection direction)
        {
            Line upper = null, lower = null, left = null, right = null;

            switch(direction)
            {
                case MoveDirection.Up:
                    {
                        if (!(move.getLine as Line).Vertical)
                        {
                            upper = move.getLine;
                            foreach(Line l in lines)
                            {
                                if (l.startX == upper.startX)
                                    left = l;
                                if (l.startX == upper.endX)
                                    right = l;
                                if ((l.startX + 1) == upper.startX)
                                    lower = l;
                            }
                            
                        }
                    }
                    break;
                case MoveDirection.Down:
                    {
                        if(!(move.getLine as Line).Vertical)
                        {
                            lower = move.getLine;
                            foreach(Line l in lines)
                            {
                                if (l.endX == lower.startX)
                                    left = l;
                                if (l.endX == lower.endX)
                                    right = l;
                                if (l.startX == (lower.startX + 1))
                                    upper = l;
                            }
                        }
                    }
                    break;
                case MoveDirection.Left:
                    {
                        if((move.getLine as Line).Vertical)
                        {
                            left = move.getLine;
                            foreach(Line l in lines)
                            {
                                if (l.startX == left.startX)
                                    upper = l;
                                if (l.startX == left.endX)
                                    lower = l;
                                if (l.startX == (left.startX + 1))
                                    right = l;
                            }
                        }
                    }
                    break;
                case MoveDirection.Right:
                    {
                        if((move.getLine as Line).Vertical)
                        {
                            right = move.getLine;
                            foreach(Line l in lines)
                            {
                                if (l.endX == right.startX)
                                    upper = l;
                                if (l.endX == right.endX)
                                    lower = l;
                                if ((l.startX + 1) == right.startX)
                                    left = l;
                            }
                        }
                    }
                    break;
                default:
                    throw new ArgumentException("Direction must be one of Up, Down, Left, Right");
            }

            Box box = null;

            if(upper != null && lower != null && left != null && right != null)
            {
                if (MakesBox(upper, lower, left, right))
                    box = new Box(upper, left, lower, right, move.getPlayer);
            }

            return box;
        }

        /// <summary>
        /// Checks if a box is null, and adds it to a list if not
        /// </summary>
        /// <param name="list"></param>
        /// <param name="b"></param>
        static void AddIfNotNull(List<Box> list, Box b)
        {
            if (b != null)
            {
                list.Add(b);
            }
        }

        /// <summary>
        /// Uses CreateBox and AddIfNotNull to specify a list of boxes a player has created with a move
        /// </summary>
        /// <param name="move"></param>
        /// <param name="player"></param>
        /// <returns>A list of boxes a player created with a move</returns>
        public List<Box> SpeculateMove(Move move, Player player)
        {
            List<Box> results = new List<Box>();

            AddIfNotNull(results, CreateBox(move, MoveDirection.Up));
            AddIfNotNull(results, CreateBox(move, MoveDirection.Down));
            AddIfNotNull(results, CreateBox(move, MoveDirection.Left));
            AddIfNotNull(results, CreateBox(move, MoveDirection.Right));

            return results;
        }

    }
}
