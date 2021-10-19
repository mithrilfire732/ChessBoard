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
            foreach (char s in sinput)
            {
                if (numerals.Contains(s))
                {
                    int n = s & 0x0f;
                    coords.Add(n);
                }
            }
            Console.WriteLine($"Enter coordinates of destination:");
            var output = Console.ReadLine();
            foreach (char s in output)
            {
                if (numerals.Contains(s))
                {
                    int n = s & 0x0f;
                    coords.Add(n);
                }
            }
            return coords;
        }


    }
}
