using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public class Square
    {
        private Piece piece { get; set; } = null;
        private int x { get; set; }
        private int y { get; set; }

        public Square(int x, int y) { }

        public Square(int x, int y, Piece piece)
        {
            this.x = x;
            this.y = y;
        }

        public Piece getPiece()  // returns piece stored on this spot
        {
            return this.piece;
        }

        public void setPiece(Piece p)
        {
            this.piece = p;
        }

        public int getX()
        {
            return x;
        }

        public void setX(int x)
        {
            this.x = x;
        }

        public int getY()
        {
            return y;
        }

        public void setY(int y)
        {
            this.y = y;
        }

        public bool IsOccupied()
        {
            if(piece != null)
            {
                return false;
            }
            return true;
        }

        


    }
}
