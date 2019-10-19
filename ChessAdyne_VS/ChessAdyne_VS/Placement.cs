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
                allPossiblePlacements.Add(new Placement(new NextMovePiece(), new Position(newX, newY)));
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
                return this.piece.GetSymbol();
            }
        }
    }
}
