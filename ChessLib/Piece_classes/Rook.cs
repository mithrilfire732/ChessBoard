using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    class Rook : Piece
    {
        public override bool CanMove(Square start, Square end)
        {
            if ((start.getX() - end.getX() == 0) && Math.Abs(start.getY() - end.getY()) > 0)
            {
                // insert check that every square between start and end is empty
                return true;
            }
            else if ((start.getY() - end.getY() == 0) && Math.Abs(start.getX() - end.getX()) > 0)
            {
                // insert check that every square between start and end is empty
                return true;
            }
            else
            {
                return false;
            }
        }
            public Rook(bool color):base(color){ }
    }
}
