using System;
using System.Collections.Generic;
using System.Text;

namespace ChessAdyne_VS.validator
{
    abstract class AbstractPlaecmentValidator : PlacementValidator
    {
        protected Board board;
        protected Placement currentPlacement;
        protected Placement targetPlacement;

        public AbstractPlaecmentValidator(Board board)
        {
            this.board = board;
        }

        public void SetCurrentPlacement(Placement currentPlacement)
        {
            this.currentPlacement = currentPlacement;
        }

        public void SetTargetPlacement(Placement targetPlacement)
        {
            this.targetPlacement = targetPlacement;
        }

        protected void CheckCurrentPlacement()
        {
            if (this.currentPlacement == null)
            {
                throw new System.Exception("CurrentPlacement cannot be null!");
            }
        }

        protected void CheckTargetPlacement()
        {
            if (this.targetPlacement == null)
            {
                throw new System.Exception("TargetPlacement cannot be null!");
            }
        }

        abstract public bool Validate();
    }
}
