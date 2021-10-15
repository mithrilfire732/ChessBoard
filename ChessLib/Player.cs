using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public class Player
    {
        protected bool White { get; set; }
        protected List<Piece> PlayerPieces { get; set; }
    }
}
