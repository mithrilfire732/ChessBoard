using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public class Bishop : Piece
    {
        public override string Name { get; set; } = "Bishop";
        public override bool CanMove(Square start, Square end)
        {
            var xdelta = Math.Abs(start.getX() - end.getX());
            var ydelta = Math.Abs(start.getY() - end.getY());
            if (ValidTarget(end.getPiece()))
            {

                return xdelta == ydelta;
                    // insert check that every square between start and end is empty

            } 
            else return false;

        }
        public Bishop(bool color, int id) : base(color, id) { }
    }
}
