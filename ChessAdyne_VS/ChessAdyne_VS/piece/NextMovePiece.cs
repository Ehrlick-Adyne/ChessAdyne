using System;
using System.Collections.Generic;
using System.Text;

namespace ChessAdyne_VS.piece
{
    class NextMovePiece : AbstractChessPiece
    {
        public NextMovePiece() : base(PieceType.NextMove) { }

        public override string getSymbol()
        {
            return " O ";
        }
    }
}
