﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    class Queen : Piece
    {
        public override bool CanMove(Square start, Square end)
        {
            if (Math.Abs(start.getX() - end.getX()) == Math.Abs(start.getY() - end.getY()))
            {
                // insert check that every square between start and end is empty
                return true;
            }
            else if ((start.getX() - end.getX() == 0) && Math.Abs(start.getY() - end.getY()) > 0)
            {
                // insert check that every square between start and end is empty
                return true;
            }
            else if ((start.getY() - end.getY() == 0) && Math.Abs(start.getX() - end.getX()) > 0)
            {
                // insert check that every square between start and end is empty
                return true;
            }
            else return false;
        }
        public Queen(bool color,int id) : base(color,id) { }
    }
}
