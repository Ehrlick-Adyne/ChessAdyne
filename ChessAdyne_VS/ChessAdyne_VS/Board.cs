using System;
using System.Collections.Generic;
using System.Text;
using ChessAdyne_VS.validator;

namespace ChessAdyne_VS
{
    class Board
    {
        private Placement[,] placements;
        private int dimension = 8;

        public Board() : this(8) { }

        public Board(int dimension)
        {
            this.dimension = dimension;
            this.placements = new Placement[dimension, dimension];
            for (int x = 0; x < dimension; x++)
            {
                for (int y = 0; y < dimension; y++)
                {
                    this.placements[x, y] = new Placement(null, new Position(x, y));
                }
            }
        }

        public Board(Board board) : this(board.dimension)
        {
            for (int x = 0; x < this.dimension; x++)
            {
                for (int y = 0; y < this.dimension; y++)
                {
                    this.placements[x, y] = new Placement(board.placements[x, y]);
                }
            }
        }

        public void Plot()
        {
            for (int x = this.dimension - 1; x >= 0; x--)
            {
                Console.Write(x + 1);
                for (int y = 0; y < this.dimension; y++)
                {
                    Console.Write($" + {this.placements[x, y]}");
                }
                Console.WriteLine("\n");
            }
            Console.Write(" ");
            for (int y = 0; y < this.dimension; y++)
            {
                Console.Write($" +  {y + 1} ");
            }
            Console.WriteLine("\n");
        }

        public void PlotOverlayPositions(Placement[] overlayPlacements)
        {
            Board tmpBoard = new Board(this);
            foreach (Placement p in overlayPlacements)
            {
                Position pos = p.GetPosition();
                tmpBoard.SelectPlacement(pos.GetDisplayX(), pos.GetDisplayY()).PutPiece(p.GetPiece());
            }
            tmpBoard.Plot();
        }

        public int GetDimension()
        {
            return this.dimension;
        }

        public Placement SelectPlacement(int displayX, int displayY)
        {
            int[] xy = TranslateXY(displayX, displayY);
            return placements[xy[0], xy[1]];
        }

        public Placement[] NextPossiblePlacements(Placement p)
        {
            Console.WriteLine($"-- Plot Possible Next Moves for {p.GetPiece().GetPieceType().ToString()} ({p.GetPosition().GetDisplayX()} , {p.GetPosition().GetDisplayY()})");
            return ValidPlacement(p);
        }

        private Placement[] ValidPlacement(Placement p)
        {
            Placement[] nextPossiblePlacements = p.NextPossiblePlacements(this.dimension);

            PlacementValidator[] validators = {
                new PlacementIsOnBoardValidator (this),
                new PlacementIsPieceInBetweenValidator (this)
            };

            List<Placement> validPlacements = new List<Placement>();
            foreach(Placement targetP in nextPossiblePlacements) {
                Boolean validResult = true;
                foreach (PlacementValidator validator in validators)
                {
                    validator.SetCurrentPlacement(p);
                    validator.SetTargetPlacement(targetP);
                    if (!validator.Validate())
                    {
                        validResult = false;
                        break;
                    }
                }
                if (validResult)
                    validPlacements.Add(targetP);
            }

            return validPlacements.ToArray();
        }

        private int[] TranslateXY(int displayX, int displayY)
        {
            int x = displayX - 1;
            int y = displayY - 1;

            PlacementValidator validator = new PlacementIsOnBoardValidator(this);
            validator.SetTargetPlacement(new Placement(null, new Position(x, y)));

            if (!validator.Validate())
                throw new SystemException($"Invalid X/Y: {displayX}/{displayY}");

            int[] r = { x, y };
            return r;
        }
    }
}
