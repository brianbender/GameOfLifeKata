using System;

namespace GameOfLife
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var game = new Board(1, 1, ".");
            Console.WriteLine(game.GetNextGeneration());
        }
    }
}
