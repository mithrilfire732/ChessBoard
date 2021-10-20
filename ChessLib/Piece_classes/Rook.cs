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
                
                
                //if ((start.getX() - end.getX() == 0) && Math.Abs(start.getY() - end.getY()) > 0)
                //{
                //    // insert check that every square between start and end is empty
                //    return true;
                //}
                //else if ((start.getY() - end.getY() == 0) && Math.Abs(start.getX() - end.getX()) > 0)
                //{
                //    // insert check that every square between start and end is empty
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}
            }
            else
            {
                return false;
            }
        }
            public Rook(bool color,int id):base(color,id){ }
    }
}
