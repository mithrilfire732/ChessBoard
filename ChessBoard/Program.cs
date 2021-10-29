using ChessLib;
using System;
using System.Collections.Generic;

namespace ChessBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            AuxMethods ctrl = new AuxMethods() { };

            Console.WriteLine("Welcome to Chess.NET!");
            string begin = "n";
            while (!ctrl.affirm.Contains(begin))
            {
                Console.WriteLine("Enter [Y/y] to begin:");
                begin = Console.ReadLine();
            }
            Game game = new Game() { };
            ctrl.InitGame(game);
            Player player = game.Player1;


            while (game.Win==null)
            {
                try
                {
                    ctrl.Turn(game, player);
                    player = player == game.Player1 ? game.Player2 : game.Player1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if (game.Win != null)
                    {
                        break;
                    }



            }
            Console.WriteLine($"{game.Win.Name} wins!");
        }
    }
}
