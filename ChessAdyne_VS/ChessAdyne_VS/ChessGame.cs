using System;
using ChessAdyne_VS.piece;

namespace ChessAdyne_VS
{
    class ChessGame
    {
        static void Main(string[] args)
        {
            PrintLegend();

            Console.WriteLine("-- Preparing Empty ChessBoard");

            Board board = new Board(new AdyneBoardConfig());
            board.Plot();

            //board.AddPlacement(new Placement(new KnightPiece(), new Position(5, 2)));
            //board.AddPlacement(new Placement(new BishopPiece(), new Position(7, 6)));

            Placement p1 = new Placement(new KnightPiece(), new Position(4, 3));
            board.AddPlacement(p1);
            board.PlotOverlayPlacements(board.NextPossiblePlacements(p1));

            Placement p2 = new Placement(new BishopPiece(), new Position(4, 3));
            board.AddPlacement(p2);
            board.PlotOverlayPlacements(board.NextPossiblePlacements(p2));
        }

        private static void PrintLegend()
        {
            Console.WriteLine("---- Legends ----");
            Console.WriteLine("[ ] : Black Empty Position");
            Console.WriteLine("| | : White Empty Position");
            Console.WriteLine(" K  : Knight");
            Console.WriteLine(" B  : Bishop");
            Console.WriteLine(" O  : Next Possible Move");
            Console.WriteLine("-----------------");
            Console.WriteLine();
        }
    }
}
