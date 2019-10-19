using System;
using System.Collections.Generic;
using System.Text;

namespace ChessAdyne_VS.validator
{
    class PlacementIsOnBoardValidator : AbstractPlaecmentValidator
    {
        public PlacementIsOnBoardValidator(Board board) : base(board) { }

        public override bool Validate()
        {
            CheckTargetPlacement();

            int targetPX = targetPlacement.GetPosition().GetX();
            int targetPY = targetPlacement.GetPosition().GetY();
            BoardConfig config = board.GetBoardConfig();
            if (targetPX < config.LowerBound() || targetPX >= config.UpperBound() || targetPY < config.LowerBound() || targetPY >= config.UpperBound())
                return false;
            else return true;

        }
    }
}
