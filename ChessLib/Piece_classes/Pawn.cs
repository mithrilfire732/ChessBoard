using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib.Piece_classes
{
    class Pawn : Piece
    {
        // Class method CanMove does not currently support long first moves or en passant capture

        public override string Name { get; set; } = "Pawn";
        public override bool CanMove(Square start, Square end)
        {
            var xdelta = end.getX() - start.getX();
            var ydelta = end.getY() - start.getY();
            if ((end.getPiece() == null) && xdelta==0) //no target piece and end square does not move laterally
            {
                if (isWhite())  // code runs if piece is white
                {
                    if (ydelta == 1) // checks to see if square if exactly 1 space forward
                    {
                        return true;
                    }
                    else return false;
                }

                else // code runs if piece is black
                {
                    if (ydelta == -1)
                    {
                        return true;
                    }
                    else return false;
                }
            }
            else if (end.getPiece().isWhite() != this.isWhite()) //target piece of different color
            {
                if (isWhite())
                {
                    if ((ydelta == 1) && (Math.Abs(xdelta) == 1))
                    {
                        return true;
                    }
                    else return false;
                }

                else
                {
                    if ((ydelta == -1) && (Math.Abs(xdelta) == 1))
                    {
                        return true;
                    }
                    else return false;
                }

            }
            else return false; //piece of same color
        }

        public Pawn(bool color,int id) :base(color,id){ }
    }
}
