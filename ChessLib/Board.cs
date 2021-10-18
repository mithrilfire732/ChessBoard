using ChessLib.Piece_classes;
using System;


namespace ChessLib
{
    public class Board
    {
        public Square[,] squares;

            //initialize [8,8] array of squares with x values 1-8 and y values 1-8
        public Board()
        {
            squares = new Square[8,8];
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
