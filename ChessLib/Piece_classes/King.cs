using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    class King : Piece
    {
        public override string Name { get; set; } = "King";
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
            if (ValidTarget(end.getPiece()))
            {

                           return (xdelta <= 1)
                                && (ydelta <= 1)
                                    && (xdelta + ydelta > 0);
            }

                

                else return false;
        }

        public King (bool color,int id) : base(color, id) { }

    }
}
