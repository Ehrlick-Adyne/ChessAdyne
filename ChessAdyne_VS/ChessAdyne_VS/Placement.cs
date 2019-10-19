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

        public Placement(ChessPiece piece, Position position)
        {
            this.piece = piece;
            this.position = position;
        }

        public Placement(Placement placement)
        {
            this.piece = placement.piece;
            this.position = placement.position;
        }

        public ChessPiece GetPiece()
        {
            return this.piece;
        }

        public string GetPieceName()
        {
            if (IsEmpty())
                return "NextMove";
            else
                return this.piece.GetPieceType().ToString();
        }

        public Position GetPosition()
        {
            return this.position;
        }

        public bool IsEmpty()
        {
            return this.piece == null;
        }

        public Placement[] NextPossiblePlacements(int boundary)
        {
            MoveRule[] rules = piece.RulesOfNextMove(boundary);

            List<Placement> allPossiblePlacements = new List<Placement>();
            foreach(MoveRule rule in rules)
            { 
                int newX = position.GetX() + rule.GetXStep();
                int newY = position.GetY() + rule.GetYStep();
                Placement p = new Placement(null, new Position(newX, newY));
                allPossiblePlacements.Add(p);
            }

            return allPossiblePlacements.ToArray();
        }

        public override String ToString()
        {
            return $"{GetPieceName()} at {GetPosition()}";
        }

        public String GetSymbol()
        {
            if (IsEmpty())
                return " O ";
            else
                return this.piece.GetSymbol();
        }
    }
}
