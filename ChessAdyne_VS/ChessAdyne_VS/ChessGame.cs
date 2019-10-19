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

            Board board = new Board();
            board.Plot();

            Placement p;

            //board.SelectPlacement (5, 2).PutPiece (new KnightPiece ());
            //board.SelectPlacement (7, 6).PutPiece (new BishopPiece ());

            p = board.SelectPlacement(4, 3);
            p.PutPiece(new KnightPiece());
            board.PlotOverlayPositions(board.NextPossiblePlacements(p));

            p = board.SelectPlacement(4, 3);
            p.PutPiece(new BishopPiece());
            board.PlotOverlayPositions(board.NextPossiblePlacements(p));
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
