using System;
using System.Collections.Generic;
using System.Text;

namespace ChessAdyne_VS.validator
{
    class PositionIsOnBoardValidator : AbstractPositionValidator
    {
        public PositionIsOnBoardValidator(Board board) : base(board) { }

        public override bool Validate()
        {
            CheckTargetPosition();

            int targetPX = targetPosition.GetX();
            int targetPY = targetPosition.GetY();
            int boardDimention = board.GetDimension();
            if (targetPX < 0 || targetPX >= boardDimention || targetPY < 0 || targetPY >= boardDimention)
                return false;
            else return true;

        }
    }
}
