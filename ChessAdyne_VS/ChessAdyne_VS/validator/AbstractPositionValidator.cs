using System;
using System.Collections.Generic;
using System.Text;

namespace ChessAdyne_VS.validator
{
    abstract class AbstractPositionValidator : PositionValidator
    {
        protected Board board;
        protected Position currentPosition;
        protected Position targetPosition;

        public AbstractPositionValidator(Board _board)
        {
            this.board = _board;
        }

        public void SetCurrentPosition(Position _p)
        {
            this.currentPosition = _p;
        }

        public void SetTargetPosition(Position _p)
        {
            this.targetPosition = _p;
        }

        protected void CheckCurrentPosition()
        {
            if (this.currentPosition == null)
            {
                throw new System.Exception("CurrentPosition cannot be null!");
            }
        }

        protected void CheckTargetPosition()
        {
            if (this.targetPosition == null)
            {
                throw new System.Exception("TargetPosition cannot be null!");
            }
        }

        abstract public bool Validate();
    }
}
