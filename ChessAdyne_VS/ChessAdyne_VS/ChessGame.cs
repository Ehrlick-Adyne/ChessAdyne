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
            Chess chess = new Chess(board);
            board.Plot();

            //board.Place(new KnightPiece(), new Position(5, 2));
            //board.Place(new BishopPiece(), new Position(7, 6));

            Placement p1 = board.Place(new KnightPiece(), new Position(4, 3));          
            board.PlotOverlayPlacements(chess.NextPossiblePlacements(p1));

            Placement p2 = board.Place(new BishopPiece(), new Position(4, 3));
            board.PlotOverlayPlacements(chess.NextPossiblePlacements(p2));
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
