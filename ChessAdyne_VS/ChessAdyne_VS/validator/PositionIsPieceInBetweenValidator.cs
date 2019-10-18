using System;
using System.Collections.Generic;
using System.Text;
using ChessAdyne_VS.piece;

namespace ChessAdyne_VS.validator
{
    class PositionIsPieceInBetweenValidator : AbstractPositionValidator
    {
        public PositionIsPieceInBetweenValidator(Board board) : base(board) { }

        public override bool Validate()
        {
            CheckTargetPosition();
            CheckCurrentPosition();

            if (currentPosition.GetPiece().AllowSkip())
                return true;
            else
                return !IsPieceInBetween();
        }

        private bool IsPieceInBetween()
        {
            int cX = currentPosition.GetX() + 1;
            int cY = currentPosition.GetY() + 1;
            int tX = targetPosition.GetX() + 1;
            int tY = targetPosition.GetY() + 1;

            int iX = tX - cX;
            int iY = tY - cY;

            int increX = 0;
            int increY = 0;
            List<Position> ps = new List<Position>();
            if (System.Math.Abs(iX) == System.Math.Abs(iY))
            {
                // diagnostic
                for (int i = 1; i < System.Math.Abs(iX); i++)
                {
                    if (iX > 0) increX = i;
                    else increX = -i;
                    if (iY > 0) increY = i;
                    else increY = -i;
                    ps.Add(board.SelectPosition(cX + increX, cY + increY));
                }
            }
            else if (iX == 0)
            {
                // vertical
                for (int i = 1; i < System.Math.Abs(iY); i++)
                {
                    if (iY > 0) increY = i;
                    else increY = -i;
                    ps.Add(board.SelectPosition(cX + increX, cY + increY));
                }
            }
            else if (iY == 0)
            {
                // horizontal
                for (int i = 1; i < System.Math.Abs(iX); i++)
                {
                    if (iX > 0) increX = i;
                    else increX = -i;
                    ps.Add(board.SelectPosition(cX + increX, cY + increY));
                }
            }
            else
            {
                return false;
            }

            foreach (Position p in ps)
            {
                if (!p.IsEmpty())
                {
                    switch (p.GetPiece().GetPieceType())
                    {
                        case PieceType.NextMove:
                            continue;
                        default:
                            return true;
                    }
                }

            }

            return false;
        }
    }
}
