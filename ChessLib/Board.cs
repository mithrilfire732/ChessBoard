using System;


namespace ChessLib
{
    public class Board
    {
        private Square[,] squares;
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
            board.squares[0, 0] = new Square(0, 0, new Rook(true));
            board.squares[0, 1] = new Square(0, 1, new Knight(true));
            board.squares[0, 2] = new Square(0, 2, new Bishop(true));
            board.squares[0, 3] = new Square(0, 3, new King(true));
            board.squares[0, 4] = new Square(0, 4, new Queen(true));
            board.squares[0, 5] = new Square(0, 5, new Bishop(true));
            board.squares[0, 6] = new Square(0, 6, new Knight(true));
            board.squares[0, 7] = new Square(0, 7, new Rook(true));

            for (int i = 0; i < 8; i++)
            {
                board.squares[1, i] = new Square(1, i, Pawn(true));
            }
            //Black Pieces
            board.squares[7, 0] = new Square(7, 0, new Rook(false));
            board.squares[7, 1] = new Square(7, 1, new Knight(false));
            board.squares[7, 2] = new Square(7, 2, new Bishop(false));
            board.squares[7, 3] = new Square(7, 3, new King(false));
            board.squares[7, 4] = new Square(7, 4, new Queen(false));
            board.squares[7, 5] = new Square(7, 5, new Bishop(false));
            board.squares[7, 6] = new Square(7, 6, new Knight(false));
            board.squares[7, 7] = new Square(7, 7, new Rook(false));


            for (int i = 0; i < 8; i++)
            {
                board.squares[6, i] = new Square(6, i, Pawn(false));
            }

            //initializes empty squares
            for (int i = 2; i < 6; i++)
            {
                for (int j = 0; j <8 ; j++)
                {
                    board.squares[i, j] = new Square(i, j);
                }
            }
        }
    }
}
