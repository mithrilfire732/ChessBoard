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
        public Player Win { get; set; }


        public Board SetBoard()
        {
            var board = new Board();
            //set pieces in standard positions and sets one set of pieces to black

            //White Pieces
            board.squares[0, 0] = new Square(0, 0, new Rook(true, 1));
            board.squares[1, 0] = new Square(1, 0, new Knight(true, 2));
            board.squares[2, 0] = new Square(2, 0, new Bishop(true, 3));
            board.squares[3, 0] = new Square(3, 0, new King(true, 4));
            board.squares[4, 0] = new Square(4, 0, new Queen(true, 5));
            board.squares[5, 0] = new Square(5, 0, new Bishop(true, 6));
            board.squares[6, 0] = new Square(6, 0, new Knight(true, 7));
            board.squares[7, 0] = new Square(7, 0, new Rook(true, 8));

            var x = 9;
            for (int i = 0; i < 8; i++)
            {
                board.squares[i,1] = new Square(i, 1, new Pawn(true, x++));
            }
            //Black Pieces
            board.squares[0, 7] = new Square(0, 7, new Rook(false, 17));
            board.squares[1, 7] = new Square(1, 7, new Knight(false, 18));
            board.squares[2, 7] = new Square(2, 7, new Bishop(false, 19));
            board.squares[3, 7] = new Square(3, 7, new King(false, 20));
            board.squares[4, 7] = new Square(4, 7, new Queen(false, 21));
            board.squares[5, 7] = new Square(5, 7, new Bishop(false, 22));
            board.squares[6, 7] = new Square(6, 7, new Knight(false, 23));
            board.squares[7, 7] = new Square(7, 7, new Rook(false, 24));


            var l = 25;
            for (int i = 0; i < 8; i++)
            {
                board.squares[i, 6] = new Square(i, 6, new Pawn(false, l++));
            }

            //initializes empty squares
            for (int i = 2; i < 6; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    board.squares[j, i] = new Square(j,i);
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
            return board;

        }

        // Move()
        // Turn() method
            //Input: Coords for Piece to move, Coords for destination
            //output: void

        public void Turn(Player player, int xw,int yw, int xb, int yb)
        {
            int[] coords = { xw, yw, xb, yb };
            Player mover = player == Player1 ? Player1 : Player2;
            Player defender = player == Player1 ? Player2 : Player1;
            Square start = board.GetSquare(xw, yw);
            Square end = board.GetSquare(xb, yb);
            
            foreach (int c in coords)   // checks that coordinates are valid
            {
                if (c>7||c<0)
                {
                    throw new Exception("Valid Coordinates are between 0-7");
                }
            }
            
            
            Move(mover, start, end);
            

            if (IsCheck(mover))
            {
                if (Checkmate(mover))
                {
                    Win = mover;
                }
                else
                {
                    Console.WriteLine("Check!");
                    Console.Beep();
                    Check = true;
                }

                // inset check for mate

            }

            else Check = false;

        }

        public void Move(Player player, Square start, Square end)
        {
            Player mover  = player == Player1 ? Player1 : Player2;
            Player defender = player == Player1 ? Player2 : Player1;
            Piece moved = start.getPiece();
            Piece captured = end.getPiece();
            bool capture = captured != null;
            //// In order to decrease necessary iterations for IsCheck() and Checkmate(), 
            /// Pieces have Squares as properties and vice versa.
            /// Therefore in order to check, both must be updated and reset if check fails.
            if (moved.CanMove(start,end)&& !Obstructed(moved.InTheWay(start,end)))
            {

                end.setPiece(moved);
                start.setPiece(null);
                moved.SetSquare(end); //should be set to end
                if (capture)
                {
                    captured.SetSquare(null);
                }
                if (IsCheck(defender))    //if illegal move, resets pieces
                {
                    start.setPiece(moved);
                    end.setPiece(captured);
                    moved.SetSquare(start);
                    if (capture) { captured.SetSquare(end); }
                    throw new Exception("Invalid move, player in check");
                }
                else
                {
                    if (capture) // if capture, updates captured piece to be dead and have null square
                    {
                        captured.killPiece(true);
                        UpdatePieceInDict(captured);
                    }
                    UpdatePieceInDict(moved);
                }
            }
            else { throw new Exception("Invalid move"); }
            
        }

        private bool Obstructed(List<int[]> tests)
        {
            if(tests == null)
            {
                return false;
            }
            else
            {

                foreach (int[] xy in tests)
                {
                    var square = board.GetSquare(xy[0], xy[1]);
                    if (square.getPiece() != null)
                    {
                        return true;
                    }
                    else continue;
                }
                return false;
            }

        }


        //updateall can be used to initially generate or regenerate
        public void UpdateAllPieces()
        {
            Player1.PlayerPieces.Clear();
            Player2.PlayerPieces.Clear();
            foreach (Square s in board.squares)
            {
                if (s.getPiece() == null)
                {
                    continue;
                }
                else
                { Piece p = s.getPiece();
                    if (p.isWhite() == Player1.White)
                    {
                        Player1.PlayerPieces.Add(p.GetId(), p);
                    }
                    if (s.getPiece().isWhite() == Player2.White)
                    {
                        Player2.PlayerPieces.Add(p.GetId(), p);
                    }
                }
            }
        }

        public void UpdatePieceInDict(Piece piece)
        {
            if (piece.isWhite() == true)
            {
                Player1.PlayerPieces[piece.GetId()] = piece;
            }
            else if (piece.isWhite() == false)
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
            foreach (Piece p in defender.PlayerPieces.Values)
            {
                if (p.GetType() == typeof(King))
                {
                    check_square = p.GetSquare();
                    break;
                }
                else continue;
            }

            foreach (Piece p in mover.PlayerPieces.Values.Where(o=>o.isDead()==false) )
            {
                Square start = new Square() { }; //not sure if this is needed
                start = p.GetSquare();
                if (p.CanMove(start, check_square)&&!Obstructed(p.InTheWay(start,check_square)))
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
                    king = p;
                    break;
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


        public Game()
        {
            Player1 = new Player() { White = true, PlayerPieces = new Dictionary<int, Piece>() };
            Player2 = new Player() { White = false, PlayerPieces = new Dictionary<int, Piece>() };
        }



    }
}
