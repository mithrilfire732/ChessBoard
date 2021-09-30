using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoard
{
    class King : Piece
    {
        private bool castlingDone = false;

        public King(bool white)
        {
            this.White = white;
        }

        public bool IsCastleValid()
        {
            return this.castlingDone;
        }

    }
}
