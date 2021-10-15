using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    class King : Piece
    {
        private bool castlingDone = false;

        public bool IsCastleValid()
        {
            if (this.castlingDone)
            {
                return false;
            }
            // needs code to check if castle path is clear and would not travel through check
            // wait until code for testing for check is developed
            else return true;
        }
        public void SetCastlingDone(bool CastlingDone)
        {
            this.castlingDone = CastlingDone;
        }
        public override bool CanMove(Square start, Square end)
        {
            var xdelta = Math.Abs(start.getX() - end.getX());
            var ydelta = Math.Abs(start.getY() - end.getY());
            if (
                           (xdelta <= 1)
                                && (ydelta <= 1)
                                    && (xdelta + ydelta > 0))
            {
                if (end.getPiece().isWhite() == this.isWhite())  // checks if the piece on the destination square is the same color as this piece
                {
                    return false;
                }

                else return true;
            }
            else return false;
        }
        public King (bool color) : base(color) { }

    }
}
