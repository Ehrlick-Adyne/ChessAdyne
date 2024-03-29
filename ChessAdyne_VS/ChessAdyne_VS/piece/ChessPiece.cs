﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ChessAdyne_VS.piece
{
    public interface ChessPiece
    {
        PieceType GetPieceType();
        MoveRule[] RulesOfNextMove(int boundary);
        bool AllowSkip();
        string GetSymbol();
    }
}
