using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public class Square
    {
        private Piece piece;
        private int x;
        private int y;

        public Square(int x, int y, Piece piece)
        {
            this.piece = null;
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
