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
        private bool isDummy = false;

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
            Console.WriteLine($"-- Put a {p.GetPieceType().ToString()} at {this.position})");
            this.piece = p;
        }

        public Placement[] NextPossiblePlacements(int boundary)
        {
            MoveRule[] rules = piece.RulesOfNextMove(boundary);

            List<Placement> allPossiblePlacements = new List<Placement>();
            foreach(MoveRule rule in rules)
            { 
                int newX = position.GetX() + rule.GetXStep();
                int newY = position.GetY() + rule.GetYStep();
                Placement p = new Placement(this.piece, new Position(newX, newY));
                allPossiblePlacements.Add(p);
            }

            return allPossiblePlacements.ToArray();
        }

        public override String ToString()
        {
            if (IsEmpty())
            {
                return position.GetSymbol();
            }
            else 
            {
                if (isDummy)
                    return " O ";
                else 
                    return this.piece.GetSymbol();
            }
        }

        public void MakeItDummy()
        {
            this.isDummy = true;
        }
    }
}
