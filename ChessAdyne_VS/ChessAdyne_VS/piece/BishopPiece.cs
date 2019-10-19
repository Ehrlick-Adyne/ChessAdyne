using System;
using System.Collections.Generic;
using System.Text;

namespace ChessAdyne_VS.piece
{
    class BishopPiece : AbstractChessPiece
    {
        public BishopPiece() : base(PieceType.Bishop) { }

        public override MoveRule[] RulesOfNextMove(int boundary)
        {
            int possibleDirections = 4;
            int maxNumOfCases = possibleDirections * (boundary - 1);
            MoveRule[] rules = new MoveRule[maxNumOfCases];

            for (int i = 0; i < boundary - 1; i++)
            {
                int m = i + 1;
                rules[i * possibleDirections] = new MoveRule(m, m);
                rules[i * possibleDirections + 1] = new MoveRule(m, -m);
                rules[i * possibleDirections + 2] = new MoveRule(-m, m);
                rules[i * possibleDirections + 3] = new MoveRule(-m, -m);
            }
            return rules;
        }

        public override string GetSymbol()
        {
            return " B ";
        }
    }
}
