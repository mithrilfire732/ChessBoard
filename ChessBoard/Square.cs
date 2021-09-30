using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoard
{
    public class Square
    {
        private Piece piece;
        private int x;
        private int y;

        public Square(int x, int y, Piece piece)
        {
            this.piece = (piece);
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

        public int getX(int x)
        {
            return this.x;
        }

        public void setX(int x)
        {
            this.x = x;
        }

        public int getY(int y)
        {
            return this.y;
        }

        public void setY(int y)
        {
            this.y = y;
        }
    }
}
