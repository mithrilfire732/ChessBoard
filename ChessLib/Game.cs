using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public class Game
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Board board { get; set; }

        public bool Win { get; set; }


        public void InitGame()
        {
            Console.WriteLine("Enter White Player Name:");
            this.Player1.Name = Console.ReadLine();
            Player1.White = true;
            Console.WriteLine("Enter Black Player Name:");
            this.Player2.Name = Console.ReadLine();
            Player2.White = false;

        }
        
        // Move()
        
        
        public void Move(Square start, Square end)
        {
            Piece moved = start.getPiece();
            Piece captured = end.getPiece();
            end.setPiece(start.getPiece());
            start.setPiece(null);
            captured.killPiece(true);
            UpdatePieceInDict(captured);
            UpdatePieceInDict(moved);
        }

        //updateall can be used to initially generate or regenerate
        public void UpdateAllPieces()
        {
            Player1.PlayerPieces.Clear();
            Player2.PlayerPieces.Clear();
            foreach (Square s in board.squares)
            {
                Piece p = s.getPiece();
                if (p.isWhite() == Player1.White)
                {
                    Player1.PlayerPieces.Add(p.GetId(),p);
                }
                if (s.getPiece().isWhite() == Player2.White)
                {
                    Player2.PlayerPieces.Add(p.GetId(), p);
                }
                else continue;
            }
        }

        public void UpdatePieceInDict(Piece piece)
        {
            if (piece.isWhite() == true)
            {
                Player1.PlayerPieces[piece.GetId()] = piece;
            }
            if (piece.isWhite() == false)
            {
                Player2.PlayerPieces[piece.GetId()] = piece;
            }
            else { throw new Exception("Not Found"); }
        }



        //IsCheck()




    }
}
