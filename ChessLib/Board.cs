using System;


namespace ChessLib
{
    public class Board
    {
        private Square[,] squares;
        private bool win; 

        public Board()
        {
            squares = new Square[8,8];
        }

        public void SetBoard()
        {
            //initialize [8,8] array of squares with x values 1-8 and y values 1-8
            squares[0,0]=new Square(0,0,new Rook(true))
            //set pieces in standard positions and sets one set of pieces to black
        }
    }
}
