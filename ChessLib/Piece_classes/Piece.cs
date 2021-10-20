using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public abstract class Piece   //abstract class is only used as a basis for other classes
    {
        public abstract string Name { get; set; }
        readonly int Id;
        private bool Dead { get; set; } = false;
        private bool White { get; set; }
        private Square Square { get; set; }

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

        public Square GetSquare()
        {
            return this.Square;
        }

        public void SetSquare(Square Square)
        {
            this.Square = Square;
        }

            // ValidTarget() checks if the piece passed in is null or differemt than this piece, returns true
            // Do not call outside of individual piece methods as it WILL mess with pawn move rules
        public bool ValidTarget(Piece piece)
        {
            if (piece==null)
            {
                return true;
            }
            else if (this.isWhite() != piece.isWhite())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Piece(bool color,int id) {
            White = color;
            Id = id;
        }

    }
}
