﻿using System;
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
            int boardDimention = board.GetDimension();
            if (targetPX < 0 || targetPX >= boardDimention || targetPY < 0 || targetPY >= boardDimention)
                return false;
            else return true;

        }
    }
}