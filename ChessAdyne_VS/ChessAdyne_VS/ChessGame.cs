using System;
using ChessAdyne_VS.piece;

namespace ChessAdyne_VS
{
    class ChessGame
    {
        static void Main(string[] args)
        {
            PrintLegned();

            Console.WriteLine("-- Preparing Empty ChessBoard");

            Board board = new Board();
            board.Plot();

            Position selectedPos;

            //board.SelectPosition (5, 2).PutPiece (new KnightPiece ());
            //board.SelectPosition (7, 6).PutPiece (new BishopPiece ());

            selectedPos = board.SelectPosition(4, 3);
            selectedPos.PutPiece(new KnightPiece());
            board.PlotOverlayPositions(board.NextPossiblePositions(selectedPos));

            selectedPos = board.SelectPosition(4, 3);
            selectedPos.PutPiece(new BishopPiece());
            board.PlotOverlayPositions(board.NextPossiblePositions(selectedPos));
        }

        private static void PrintLegned()
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
