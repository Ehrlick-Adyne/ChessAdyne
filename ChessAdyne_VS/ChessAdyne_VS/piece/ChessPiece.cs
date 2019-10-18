using System;
using System.Collections.Generic;
using System.Text;

namespace ChessAdyne_VS.piece
{
    interface ChessPiece
    {
        PieceType getPieceType();
        MoveRule[] rulesOfNextMove(int boundary);
        bool allowSkip();
        string getSymbol();
    }
}
