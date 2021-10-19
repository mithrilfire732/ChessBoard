using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    class Knight : Piece
    {
        public override string Name { get; set; } = "Knight";
        public override bool CanMove(Square start, Square end)
        {
            // we can't move the piece to a spot that has
            // a piece of the same colour
            if (end.getPiece().isWhite() == this.isWhite())
            {
                return false;
            }

            int x = Math.Abs(start.getX() - end.getX());
            int y = Math.Abs(start.getY() - end.getY());
            return x * y == 2;
        }
        public Knight(bool color,int id) : base(color,id) { }
    }
}
