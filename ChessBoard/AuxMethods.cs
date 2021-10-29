using ChessLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoard
{
    public class AuxMethods
    {
        public List<string> affirm { get; set; } = new List<string>  {"y", "Y" };
        public void InitGame(Game game)
        {

            Console.WriteLine("Enter White Player Name:");
            game.Player1.Name = Console.ReadLine();
            Console.WriteLine("Enter Black Player Name:");
            game.Player2.Name = Console.ReadLine();
            game.board = game.SetBoard();
            game.UpdateAllPieces();
        }

        public List<int> InputCoords(Player player, Game game)
        {
            Player mover = player == game.Player1 ? game.Player1 : game.Player2;
            Player defender = player == game.Player1 ? game.Player2 : game.Player1;
            Console.WriteLine($"{mover.Name}, Enter coordinates of piece to move:");
            char[] numerals = new char[] {'0','1','2', '3', '4', '5', '6', '7' };
            var sinput = Console.ReadLine();
            List<int> coords = new List<int>();

            try
            {
                foreach (char s in sinput)
                {
                    if (numerals.Contains(s))
                    {
                        int n = s & 0x0f;
                        coords.Add(n);
                    }
                }
                if (!coords.Count().Equals(2))
                {
                    throw new Exception("Please enter a valid coordinate pair in the format x,y where x and y are between 0 and 7");
                }

            }
            catch (Exception)
            {

                throw;
            }


            Console.WriteLine($"Enter coordinates of destination:");
            var output = Console.ReadLine();
            try
            {
                foreach (char s in output)
                {
                    if (numerals.Contains(s))
                    {
                        int n = s & 0x0f;
                        coords.Add(n);
                    }
                }
                if (!coords.Count().Equals(4))
                {
                    throw new Exception("Please enter a valid coordinate pair in the format x,y where x and y are between 0 and 7");
                }

            }
            catch (Exception)
            {

                throw;
            }
            return coords;
        }

        public void Turn(Game game, Player player)
        {
            bool confirm = false;
            while (!confirm)
            {

                var m = false;
                var o = new List<int>();
                while (!m)
                {

                    o = InputCoords(player, game);
                    if (game.board.GetSquare(o[0], o[1]).getPiece() == null)
                    {
                        throw new Exception("There is no piece here to move");
                    }
                    else
                    {
                        Console.Write($"{game.board.GetSquare(o[0], o[1]).getPiece().Name} on {o[0]},{o[1]} moves to {o[2]},{o[3]}");
                        m = true;
                    }
                }

                if (game.board.GetSquare(o[2], o[3]).getPiece() != null)
                {
                    Console.WriteLine($"and captures {game.board.GetSquare(o[2], o[3]).getPiece().Name} ");
                }

                else
                {
                    Console.WriteLine();
                }

                Console.WriteLine("Enter [y] to confirm, any other key to redo:");
                var response = Console.ReadLine();
                
                if (affirm.Contains(response))
                {
                    try
                    {
                    game.MoveShell(player, o[0], o[1], o[2], o[3]);

                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                    confirm = true;
                }
                else continue;
            }
            //add check for checkmate <- checkmate is now checked for in MoveShell
        }



    }
}
