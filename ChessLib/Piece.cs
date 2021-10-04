using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public abstract class Piece   //abstract class is only used as a basis for other classes
    {
        public bool Dead = false;
        public bool White = false;

        public void killPiece(bool killed)
        {
            this.Dead = killed;
        }

        public bool isDead()
        {
            return this.Dead;
        }

        public bool isWhite()
        {
            return this.White;
        }

        public void setWhite(bool White)
        {
            this.White = White;
        }
        public abstract bool CanMove(Board board, Square start, Square end);

    }
}
