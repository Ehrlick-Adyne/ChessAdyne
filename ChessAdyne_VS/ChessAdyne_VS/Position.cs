using System;
using System.Collections.Generic;
using System.Text;
using ChessAdyne_VS.piece;

namespace ChessAdyne_VS
{
    class Position
    {
        private int x;
        private int y;
        private PositionColor color;
        private ChessPiece piece;

        public Position(ChessPiece _piece, int _x, int _y)
        {
            this.piece = _piece;
            this.x = _x;
            this.y = _y;
            this.color = CurrentPositionColor(_x, _y);
        }

        public int GetX()
        {
            return this.x;
        }

        public int GetY()
        {
            return this.y;
        }

        public int GetDisplayX()
        {
            return this.x + 1;
        }

        public int GetDisplayY()
        {
            return this.y + 1;
        }

        public ChessPiece GetPiece()
        {
            return this.piece;
        }

        private PositionColor CurrentPositionColor(int x_, int y_)
        {
            if (((x_ + 1) + (y_ + 1)) % 2 == 0) return PositionColor.Black;
            else return PositionColor.White;
        }

        public bool IsEmpty()
        {
            if (piece == null) return true;
            else return false;
        }

        public void PutPiece(ChessPiece piece)
        {
            Console.WriteLine($"-- Put a {piece.GetPieceType().ToString()} at ({GetDisplayX()} , {GetDisplayY()})");
            this.piece = piece;
        }

        public override String ToString()
        {
            if (IsEmpty())
            {
                switch (color)
                {
                    case PositionColor.White:
                        return "| |";
                    case PositionColor.Black:
                        return "[ ]";
                    default:
                        throw new SystemException($"Unexpected PositionColor: {color}");
                }
            }
            else
            {
                return this.GetPiece().GetSymbol();
            }
        }

        public Position[] NextPossiblePositions(int boundary)
        {
            MoveRule[] rules = piece.RulesOfNextMove(boundary);

            // Generate possible Positions
            Position[] pps = new Position[rules.Length];
            for (int i = 0; i < rules.Length; i++)
            {
                MoveRule rule = rules[i];
                int newX = this.x + rule.GetXStep();
                int newY = this.y + rule.GetYStep();
                pps[i] = new Position(new NextMovePiece(), newX, newY);
            }

            return pps;
        }

    }
}
