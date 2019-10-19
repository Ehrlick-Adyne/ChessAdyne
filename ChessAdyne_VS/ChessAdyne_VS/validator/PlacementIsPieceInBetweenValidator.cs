using System;
using System.Collections.Generic;
using System.Text;
using ChessAdyne_VS.piece;

namespace ChessAdyne_VS.validator
{
    class PlacementIsPieceInBetweenValidator : AbstractPlaecmentValidator
    {
        public PlacementIsPieceInBetweenValidator(Board board) : base(board) { }

        public override bool Validate()
        {
            CheckTargetPlacement();
            CheckCurrentPlacement();

            if (currentPlacement.GetPiece().AllowSkip())
                return true;
            else
                return !IsPieceInBetween();
        }

        private bool IsPieceInBetween()
        {
            int cX = currentPlacement.GetPosition().GetX();
            int cY = currentPlacement.GetPosition().GetY();
            int tX = targetPlacement.GetPosition().GetX();
            int tY = targetPlacement.GetPosition().GetY();

            int iX = tX - cX;
            int iY = tY - cY;

            int increX = 0;
            int increY = 0;
            List<Placement> placements = new List<Placement>();
            if (System.Math.Abs(iX) == System.Math.Abs(iY))
            {
                // diagnostic
                for (int i = 1; i < System.Math.Abs(iX); i++)
                {
                    if (iX > 0) increX = i;
                    else increX = -i;
                    if (iY > 0) increY = i;
                    else increY = -i;
                    placements.Add(board.SelectPlacement(new Position(cX + increX, cY + increY)));
                }
            }
            else if (iX == 0)
            {
                // vertical
                for (int i = 1; i < System.Math.Abs(iY); i++)
                {
                    if (iY > 0) increY = i;
                    else increY = -i;
                    placements.Add(board.SelectPlacement(new Position(cX + increX, cY + increY)));
                }
            }
            else if (iY == 0)
            {
                // horizontal
                for (int i = 1; i < System.Math.Abs(iX); i++)
                {
                    if (iX > 0) increX = i;
                    else increX = -i;
                    placements.Add(board.SelectPlacement(new Position(cX + increX, cY + increY)));
                }
            }
            else
            {
                return false;
            }

            foreach (Placement p in placements)
            {
                if (!p.IsEmpty())
                    return true;
            }

            return false;
        }
    }
}
