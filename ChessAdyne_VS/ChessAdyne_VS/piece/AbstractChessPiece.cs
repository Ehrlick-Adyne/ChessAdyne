using System;
using System.Collections.Generic;
using System.Text;

namespace ChessAdyne_VS.piece
{
    abstract class AbstractChessPiece : ChessPiece
    {
        private PieceType type;

        public AbstractChessPiece(PieceType _type)
        {
            this.type = _type;
        }

        public PieceType GetPieceType()
        {
            return this.type;
        }

        public virtual bool AllowSkip()
        {
            return false;
        }

        public virtual MoveRule[] RulesOfNextMove(int boundary)
        {
            return new MoveRule[0];
        }

        abstract public string GetSymbol();
    }
}
