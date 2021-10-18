using ChessLib.Piece_classes;
using System;


namespace ChessLib
{
    public class Board
    {
        public Square[,] squares;
        private bool win; 

            //initialize [8,8] array of squares with x values 1-8 and y values 1-8
        public Board()
        {
            squares = new Square[8,8];
        }

        public void SetBoard()
        {
            var board = new Board();
            //set pieces in standard positions and sets one set of pieces to black
            
                //White Pieces
            board.squares[0, 0] = new Square(0, 0, new Rook(true,1));
            board.squares[0, 1] = new Square(0, 1, new Knight(true,2));
            board.squares[0, 2] = new Square(0, 2, new Bishop(true,3));
            board.squares[0, 3] = new Square(0, 3, new King(true,4));
            board.squares[0, 4] = new Square(0, 4, new Queen(true,5));
            board.squares[0, 5] = new Square(0, 5, new Bishop(true,6));
            board.squares[0, 6] = new Square(0, 6, new Knight(true,7));
            board.squares[0, 7] = new Square(0, 7, new Rook(true,8));

            for (int i = 0; i < 8; i++)
            {
                var x = 9;
                board.squares[1, i] = new Square(1, i, new Pawn(true, x++));
            }
            //Black Pieces
            board.squares[7, 0] = new Square(7, 0, new Rook(false,17));
            board.squares[7, 1] = new Square(7, 1, new Knight(false,18));
            board.squares[7, 2] = new Square(7, 2, new Bishop(false,19));
            board.squares[7, 3] = new Square(7, 3, new King(false,20));
            board.squares[7, 4] = new Square(7, 4, new Queen(false,21));
            board.squares[7, 5] = new Square(7, 5, new Bishop(false,22));
            board.squares[7, 6] = new Square(7, 6, new Knight(false,23));
            board.squares[7, 7] = new Square(7, 7, new Rook(false,24));


            for (int i = 0; i < 8; i++)
            {
                var x = 25;
                board.squares[6, i] = new Square(6, i, new Pawn(false,x++));
            }

            //initializes empty squares
            for (int i = 2; i < 6; i++)
            {
                for (int j = 0; j <8 ; j++)
                {
                    board.squares[i, j] = new Square(i, j);
                }
            }

            Console.WriteLine("The board is set!");

        }
            
        public Square GetSquare(int x, int y)
        {
            if (squares[x,y] == null)
            {
                throw new Exception("Valid square coordinates are between x=[0...7] and y=[0...7]");
            }
            return squares[x, y];
        }

    }
}
