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

        public void drawLines(Graphics g)
        {
            foreach(Line l in lines)
            {
                l.drawLine(g);
            }
        }

        public bool MakesBox(Line upper, Line lower, Line left, Line right)
        {
            bool makesBox = false;

            if (upper.isSelected() && lower.isSelected() && left.isSelected() && right.isSelected())
                makesBox = true;

            return makesBox;
        }

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

    }
}
