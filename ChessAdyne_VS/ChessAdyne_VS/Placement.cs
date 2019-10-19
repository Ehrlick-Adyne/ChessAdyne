using System;
using System.Collections.Generic;
using System.Text;
using ChessAdyne_VS.piece;

namespace ChessAdyne_VS
{
    class Placement
    {
        private ChessPiece piece;
        private Position position;

        public Placement(ChessPiece _piece, Position _position)
        {
            this.piece = _piece;
            this.position = _position;
        }

        public Placement(Placement _placement)
        {
            this.piece = _placement.piece;
            this.position = _placement.position;
        }

        public ChessPiece GetPiece()
        {
            return this.piece;
        }

        public Position GetPosition()
        {
            return this.position;
        }

        public bool IsEmpty()
        {
            if (piece == null) return true;
            else return false;
        }

        public void PutPiece(ChessPiece p)
        {
            Console.WriteLine($"-- Put a {p.GetPieceType().ToString()} at ({position.GetDisplayX()} , {position.GetDisplayY()})");
            this.piece = p;
        }

        public Placement[] NextPossiblePlacements(int boundary)
        {
            MoveRule[] rules = piece.RulesOfNextMove(boundary);

            // Generate possible Placements
            Placement[] pps = new Placement[rules.Length];
            for (int i = 0; i < rules.Length; i++)
            {
                MoveRule rule = rules[i];
                int newX = position.GetX() + rule.GetXStep();
                int newY = position.GetY() + rule.GetYStep();
                pps[i] = new Placement(new NextMovePiece(), new Position(newX, newY));
            }

            return pps;
        }

        public override String ToString()
        {
            if (IsEmpty())
            {
                return position.ToString();
            }
            else 
            {
                return this.piece.GetSymbol();
            }
        }
    }
}
