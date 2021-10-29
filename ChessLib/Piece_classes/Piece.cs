using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public abstract class Piece   //abstract class is only used as a basis for other classes
    {
        public abstract string Name { get; set; }
        readonly int Id;
        private bool Dead { get; set; } = false;
        private bool White { get; set; }
        private Square Square { get; set; }

        public void killPiece(bool killed)
        {
            this.Dead = killed;
        }

        public bool isDead()
        {
            return this.Dead;
        }

        public bool isWhite()
        {
            return this.White;
        }

        public void setWhite(bool White)
        {
            this.White = White;
        }

        public int GetId()
        {
            return this.Id;
        }
        public abstract bool CanMove(Square start, Square end);

        public Square GetSquare()
        {
            return this.Square;
        }

        public void SetSquare(Square Square)
        {
            this.Square = Square;
        }

            // ValidTarget() checks if the piece passed in is null or differemt than this piece, returns true
            // Do not call outside of individual piece methods as it WILL mess with pawn move rules
        public bool ValidTarget(Piece piece)
        {
            if (piece==null)
            {
                return true;
            }
            else if (this.isWhite() != piece.isWhite())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //TODO rename to better reflect output
        // Gathers a collection of x,y for squares that need checked in the Game class for a piece to determine if a move is obstructed, override in Knight, King, and Pawn classes.
        public virtual List<int[]> InTheWay(Square start, Square end)
        {
            var x1 = start.getX();
            var y1 = start.getY();
            var x2 = end.getX();
            var y2 = end.getY();
            var xdelta = x2 - x1;
            var ydelta = y2 - y1;
            int[] inc = new int[2];
            List<int[]> testsq = new List<int[]>();
            switch (xdelta)
            {
                case > 0:
                    inc[0] = 1;
                    break;
                case < 0:
                    inc[0] = -1;
                    break;
                default:
                    inc[0] = 0;
                    break;
            }
            switch (ydelta)
            {
                case > 0:
                    inc[1] = 1;
                    break;
                case < 0:
                    inc[1] = -1;
                    break;
                default:
                    inc[1] = 0;
                    break;
            }
            for (int[] i = { x1 + inc[0], y1 + inc[1]}; (i[0] != x2 ) && (i[1] != y2); i = i.Zip(inc, (x, y) => x + y).ToArray())
            {
                testsq.Add(i);
            }
            return testsq;

        }

        public Piece(bool color,int id) {
            White = color;
            Id = id;
        }

    }
}
