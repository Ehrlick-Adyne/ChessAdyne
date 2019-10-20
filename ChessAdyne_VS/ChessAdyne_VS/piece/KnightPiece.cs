using System;
using System.Collections.Generic;
using System.Text;

namespace ChessAdyne_VS.piece
{
    public class KnightPiece : AbstractChessPiece
    {
        public KnightPiece() : base(PieceType.Knight) { }
        
        protected override MoveRule[] CreateRules(int boundary)
        { 
            cachedRules.Add(boundary, KnightPiece.rules);
            return KnightPiece.rules;
        }

        private static MoveRule[] rules =
            {
                new MoveRule(1, 2),
                new MoveRule(1, -2),
                new MoveRule(2, 1),
                new MoveRule(2, -1),
                new MoveRule(-1, 2),
                new MoveRule(-1, -2),
                new MoveRule(-2, 1),
                new MoveRule(-2, -1)
            };

        public override bool AllowSkip()
        {
            return true;
        }

        public override string GetSymbol()
        {
            return " K ";
        }

    }
}
