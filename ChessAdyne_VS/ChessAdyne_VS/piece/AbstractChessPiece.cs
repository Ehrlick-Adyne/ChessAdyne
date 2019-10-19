using System;
using System.Collections.Generic;
using System.Text;

namespace ChessAdyne_VS.piece
{
    abstract class AbstractChessPiece : ChessPiece
    {
        private PieceType type;

        public AbstractChessPiece(PieceType type)
        {
            this.type = type;
        }

        public PieceType GetPieceType()
        {
            return this.type;
        }

        public virtual bool AllowSkip()
        {
            return false;
        }

        public MoveRule[] RulesOfNextMove(int boundary)
        {
            if (cachedRules.ContainsKey(boundary))
                return cachedRules[boundary];
            else
                return CreateRules(boundary);
        }

        protected virtual MoveRule[] CreateRules(int boundary)
        {
            return new MoveRule[0];
        }

        abstract public string GetSymbol();

        protected Dictionary<int, MoveRule[]> cachedRules = new Dictionary<int, MoveRule[]>();
    }
}
