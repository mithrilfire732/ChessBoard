using ChessLib.Piece_classes;
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
        public bool Check { get; set; } = false;
        public bool Win { get; set; } = false;


        public void InitGame()
        {
            Console.WriteLine("Enter White Player Name:");
            this.Player1.Name = Console.ReadLine();
            Player1.White = true;
            Console.WriteLine("Enter Black Player Name:");
            this.Player2.Name = Console.ReadLine();
            Player2.White = false;
            board = SetBoard();

        }

        public Board SetBoard()
        {
            var board = new Board();
            //set pieces in standard positions and sets one set of pieces to black

            //White Pieces
            board.squares[0, 0] = new Square(0, 0, new Rook(true, 1));
            board.squares[0, 1] = new Square(0, 1, new Knight(true, 2));
            board.squares[0, 2] = new Square(0, 2, new Bishop(true, 3));
            board.squares[0, 3] = new Square(0, 3, new King(true, 4));
            board.squares[0, 4] = new Square(0, 4, new Queen(true, 5));
            board.squares[0, 5] = new Square(0, 5, new Bishop(true, 6));
            board.squares[0, 6] = new Square(0, 6, new Knight(true, 7));
            board.squares[0, 7] = new Square(0, 7, new Rook(true, 8));

            for (int i = 0; i < 8; i++)
            {
                var x = 9;
                board.squares[1, i] = new Square(1, i, new Pawn(true, x++));
            }
            //Black Pieces
            board.squares[7, 0] = new Square(7, 0, new Rook(false, 17));
            board.squares[7, 1] = new Square(7, 1, new Knight(false, 18));
            board.squares[7, 2] = new Square(7, 2, new Bishop(false, 19));
            board.squares[7, 3] = new Square(7, 3, new King(false, 20));
            board.squares[7, 4] = new Square(7, 4, new Queen(false, 21));
            board.squares[7, 5] = new Square(7, 5, new Bishop(false, 22));
            board.squares[7, 6] = new Square(7, 6, new Knight(false, 23));
            board.squares[7, 7] = new Square(7, 7, new Rook(false, 24));


            for (int i = 0; i < 8; i++)
            {
                var x = 25;
                board.squares[6, i] = new Square(6, i, new Pawn(false, x++));
            }

            //initializes empty squares
            for (int i = 2; i < 6; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    board.squares[i, j] = new Square(i, j);
                }
            }

            foreach (Square square in board.squares)
            {
                if (square.getPiece()==null)
                {
                    continue;
                }
                else
                {
                    square.getPiece().SetSquare(square);
                }
            }

            Console.WriteLine("The board is set!");
            return board;

        }

        // Move()


        public void Move(Player player, Square start, Square end)
        {
            Piece moved = start.getPiece();
            Piece captured = end.getPiece();
                                           //// In order to decrease necessary iterations for IsCheck() and Checkmate(), 
                                           /// Pieces have Squares as properties and vice versa.
                                           /// Therefore in order to check, both must be updated and reset if check fails.
            end.setPiece(moved);
            start.setPiece(null);
            moved.SetSquare(start);
            captured.SetSquare(null);
            if (IsCheck(player))    //if illegal move, resets pieces
            {
                start.setPiece(moved);
                end.setPiece(captured);
                moved.SetSquare(start);
                captured.SetSquare(end);
                throw new Exception("Invalid move, player in check");
            }
            else
            {
                captured.killPiece(true);
                UpdatePieceInDict(captured);
                UpdatePieceInDict(moved);
            }
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



        //IsCheck() Returns Bool. Takes a player as a parameter, gets kings square,
        //Iterates through opponent Player.PlayerPieces dict and applies CanMove() to King's Square
        //Returns boolean true if any piece can move to kings square

        public bool IsCheck(Player player)
        {
            Player mover = player == Player1 ? Player1 : Player2;
            Player defender = player == Player1 ? Player2 : Player1;
            Square check_square = null;
            foreach (Piece p in mover.PlayerPieces.Values)
            {
                if (p.GetType()==typeof(King))
                {
                    check_square = p.GetSquare();
                }
            else continue;
            }

            foreach (Piece p in defender.PlayerPieces.Values)
            {
                if (p.CanMove(p.GetSquare(), check_square))
                {
                    return true;
                }
                else continue;
            }

            //foreach (Square s in board.squares)
            //{
            //    if (s.getPiece() == null || s.getPiece().isWhite() == player.White)
            //    {
            //        continue;
            //    }
            //    else if (s.getPiece().isWhite() != player.White)
            //    {
            //        if (s.getPiece().CanMove(s, check_square))
            //        {
            //            return true;
            //        }
            //        else continue;
            //    }
            //    else continue;
            //}

            return false;

        }

        // Turn() method
            //Input: Coords for Piece to move, Coords for destination
            //output: void

        public void Turn(Player player, int xw,int yw, int xb, int yb)
        {
            int[] coords = { xw, yw, xb, yb };
            Player Mover = player == Player1 ? Player1 : Player2;
            Player Defender = player == Player1 ? Player2 : Player1;
            Square start = board.GetSquare(xw, yw);
            Square end = board.GetSquare(xb, yb);
            
            foreach (int c in coords)   // checks that coordinates are valid
            {
                if (c>7||c<0)
                {
                    throw new Exception("Valid Coordinates are between 0-7");
                }
            }
            try
            {
                Move(Mover, start, end);
            }
            catch (Exception)
            {

                throw new Exception("Invalid Move!");
            }
            if (IsCheck(Defender))
            {
                Console.WriteLine("Check!");
                Console.Beep();
                Check = true;

                // inset check for mate

            }

            else Check = false;

        }

            // Checkmate currently only checks if king can natural move out of check
            // Other methods of avoiding mate must still be accounted for
            //These include: removing the defender (solved by adding pieces who CanMove() to a list, if more than one then do not check captures, if one check can captures
            // Blocking: requires development of path sense which varies by piece, harder task

        public bool Checkmate(Player player)
        {
            Player mover = player == Player1 ? Player1 : Player2;
            Player defender = player == Player1 ? Player2 : Player1;
            Piece king = null;
            List<Square> moves = new List<Square>();

            foreach (Piece p in mover.PlayerPieces.Values)
            {
                if (p.GetType() == typeof(King))
                {
                    p.GetSquare();
                }
                else continue;
            }
            foreach (Square s in board.squares)
            {
                if (king.CanMove(king.GetSquare(), s))
                {
                    moves.Add(s);
                }
                
            }
            foreach (Piece p in defender.PlayerPieces.Values)
            {
                foreach (Square square in moves)
                {
                    if (p.CanMove(p.GetSquare(), square))
                    {
                        moves.Remove(square);
                    }
                    if (!moves.Any())
                    {
                        return true;
                    }

                }

            }
            return false;

        }



    }
}
