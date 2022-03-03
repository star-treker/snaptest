using SnapDomain;
using System;
using System.Threading;

namespace SnapGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine("Snap!");

            Console.WriteLine("2 Players");

            Console.WriteLine("Player 1 = If Snap Press Q");
            Console.WriteLine("Player 2 = If Snap Press P");

            Console.WriteLine("Starting...");
            Console.WriteLine();

            var game = new GamePlay()
            {
                RenderCards = (collection) =>
                {
                    foreach (var card in collection)
                    {
                        Console.Write("{0} ", card);
                    }
                    Console.WriteLine();
                },
                RenderSnap = (winner) =>
                {
                    Console.WriteLine("Player {0} - SNAP", winner);
                    Console.WriteLine("Stacks to Player {0}", winner);
                    Console.WriteLine();
                },
                GetWinner = () =>
                {
                    // Flush keyboard buffer
                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey();
                    }
                    // Get the next key...
                    var keyInfo = Console.ReadKey();
                    Console.WriteLine();
                    if (keyInfo.Key == ConsoleKey.Q) return 1;
                    if (keyInfo.Key == ConsoleKey.P) return 2;
                    return 0;
                },
                TurnDelay = () =>
                {
                    Thread.Sleep(1000);
                }
            };

            var gameWinner = game.PlayGame();

            if (gameWinner > 0)
            {
                Console.WriteLine("GAME WINNER - Well Done Player {0}", gameWinner);
            }
            else
            {
                Console.WriteLine("GAME DRAWN");
            }
            Console.ReadKey();
        }
    }
}
