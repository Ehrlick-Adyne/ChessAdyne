using System;
using System.Collections.Generic;
using System.Text;
using ChessAdyne_VS.piece;

namespace ChessAdyne_VS
{
    public class Placement
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

        public Placement[] NextPossiblePlacements(int boundary)
        {
            MoveRule[] rules = piece.RulesOfNextMove(boundary);

            List<Placement> allPossiblePlacement = new List<Placement>();
            foreach(MoveRule rule in rules)
            { 
                int newX = position.GetX() + rule.GetXStep();
                int newY = position.GetY() + rule.GetYStep();
                allPossiblePlacement.Add(new NextMovePlacement(new Position(newX, newY)));
            }

            return allPossiblePlacement.ToArray();
        }

        public override String ToString()
        {
            return $"{GetPieceName()} at {GetPosition()}";
        }

        public virtual String GetSymbol()
        {
            return this.piece.GetSymbol();
        }

        public virtual String GetPieceName()
        {
           return this.piece.GetPieceType().ToString();
        }
    }

    class NextMovePlacement : Placement
    {
        private static readonly ChessPiece emptyPiece = null;
        public NextMovePlacement(Position position) : base(emptyPiece, position) { }

        public override string GetSymbol()
        {
            return " O ";
        }

        public override string GetPieceName()
        {
            return "NextMove";
        }
    }
}
