using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public class Player
    {
        public string Name { get; set; }
        public bool White { get; set; }
        public Dictionary<int,Piece> PlayerPieces { get; set; }


    }
}
