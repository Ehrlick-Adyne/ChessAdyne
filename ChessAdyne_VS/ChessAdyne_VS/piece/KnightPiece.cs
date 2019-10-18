using System;
using System.Collections.Generic;
using System.Text;

namespace ChessAdyne_VS.piece
{
    class KnightPiece : AbstractChessPiece
    {
        public KnightPiece() : base(PieceType.Knight) { }
        public override MoveRule[] RulesOfNextMove(int boundary)
        {
            MoveRule[] rules = {
                new MoveRule(1, 2),
                new MoveRule(1, -2),
                new MoveRule(2, 1),
                new MoveRule(2, -1),
                new MoveRule(-1, 2),
                new MoveRule(-1, -2),
                new MoveRule(-2, 1),
                new MoveRule(-2, -1)
            };

            return rules;
        }

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
