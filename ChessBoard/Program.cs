using ChessLib;
using System;
using System.Collections.Generic;

namespace ChessBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> affirm = new List<string>{ "y", "Y" };
            Console.WriteLine("Welcome to Chess.NET!");
            string begin = "n";
            while (!affirm.Contains(begin))
            {
                Console.WriteLine("Enter [Y/y] to begin:");
                begin = Console.ReadLine();
            }
            Game game = new Game() { };



            AuxMethods ctrl = new AuxMethods() { };
            ctrl.InitGame(game);
            while (game.Win==null)
            {
               bool confirm = false;
                while(!confirm)
                {

                    var m = false;
                    var o = new List<int>();
                    while (!m)
                    {

                        o = ctrl.InputCoords(game.Player1, game);
                        if(game.board.GetSquare(o[0], o[1]).getPiece() == null)
                        {
                            Console.WriteLine("There is no piece here to move");
                            continue;

                        }
                        else
                        {
                            Console.WriteLine($"There is a {game.board.GetSquare(o[0], o[1]).getPiece().Name} on {o[0]},{o[1]}");
                            m = true;
                        }
                    }
                    
                    if(game.board.GetSquare(o[2], o[3]).getPiece()==null)
                    {
                        Console.WriteLine("The destination is unoccupied");
                    }
                    else 
                    {
                        Console.WriteLine($"and there is {game.board.GetSquare(o[2], o[3]).getPiece().Name} on {o[2]},{o[3]}");
                    }
                Console.WriteLine("Enter [y] to confirm, any other key to redo:");
                    var response = Console.ReadLine();
                    if (affirm.Contains(response))
                    {
                        game.Turn(game.Player1, o[0], o[1], o[2], o[3]);
                        confirm = true;
                    }
                    else continue;
                }
                confirm = false;

                while (!confirm)
                {
                    var m = false;
                    var o = new List<int>();

                    while (!m)
                    {
                        o = ctrl.InputCoords(game.Player2, game);
                        if (game.board.GetSquare(o[0], o[1]).getPiece() == null)
                        {
                            Console.WriteLine("There is no piece here to move");
                            continue;

                        }
                        else
                        {
                            Console.WriteLine($"There is a {game.board.GetSquare(o[0], o[1]).getPiece().Name} on {o[0]},{o[1]}");
                            m = true;
                        }
                    }
                    if (game.board.GetSquare(o[2], o[3]).getPiece() == null)
                        {
                        Console.WriteLine("The destination is unoccupied");
                        }
                    else
                        {
                        Console.WriteLine($"and there is {game.board.GetSquare(o[2], o[3]).getPiece()} on {o[2]},{o[3]}");
                        }
                    Console.WriteLine("Enter [y] to confirm, any other key to redo:");
                    var response = Console.ReadLine();
                    if (affirm.Contains(response))
                    {
                        game.Turn(game.Player2, o[0], o[1], o[2], o[3]);
                        confirm = true;
                    }
                    else continue;
                }
                confirm = false;
            }
        }
    }
}
