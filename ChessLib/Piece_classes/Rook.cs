using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    class Rook : Piece
    {
        public override string Name { get; set; } = "Rook";
        public override bool CanMove(Square start, Square end)
        {
            var xdelta = Math.Abs(start.getX() - end.getX());
            var ydelta = Math.Abs(start.getY() - end.getY());
            if (ValidTarget(end.getPiece()))
            {
                return xdelta * ydelta == 0 && xdelta + ydelta != 0;
            }

            else return false;
        }
            public Rook(bool color,int id):base(color,id){ }
    }
}
