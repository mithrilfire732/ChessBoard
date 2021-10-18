using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public abstract class Piece   //abstract class is only used as a basis for other classes
    {
        readonly int Id;
        private bool Dead { get; set; } = false;
        private bool White { get; set; }

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

        public int GetId()
        {
            return this.Id;
        }
        public abstract bool CanMove(Square start, Square end);

        public Piece(bool color,int id) {
            White = color;
            Id = id;
        }

    }
}
