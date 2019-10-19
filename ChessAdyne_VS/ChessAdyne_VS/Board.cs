using System;
using System.Collections.Generic;
using System.Text;
using ChessAdyne_VS.validator;

namespace ChessAdyne_VS
{
    class Board
    {
        private Dictionary<String, Placement> placements;
        private int dimension = 8;

        public Board() : this(8) { }

        public Board(int dimension)
        {
            this.dimension = dimension;
            this.placements = new Dictionary<String, Placement>();
            for (int x = 1; x <= dimension; x++)
            {
                for (int y = 1; y <= dimension; y++)
                {
                    Position p = new Position(x, y);
                    this.placements.Add(p.ToString(), new Placement(null, p));
                }
            }
        }

        public Board(Board board) : this(board.dimension)
        {
            this.placements = new Dictionary<String, Placement>();
            for (int x = 1; x <= this.dimension; x++)
            {
                for (int y = 1; y <= this.dimension; y++)
                {
                    String key = new Position(x, y).ToString();
                    this.placements.Add(key, new Placement(board.placements[key]));
                }
            }
        }

        public void Plot()
        {
            for (int x = this.dimension; x > 0; x--)
            {
                Console.Write(x);
                for (int y = 1; y <= this.dimension; y++)
                {
                    Console.Write($" + {this.placements[new Position(x, y).ToString()]}");
                }
                Console.WriteLine("\n");
            }
            Console.Write(" ");
            for (int y = 1; y <= this.dimension; y++)
            {
                Console.Write($" +  {y} ");
            }
            Console.WriteLine("\n");
        }

        public void PlotOverlayPlacements(Placement[] overlayPlacements)
        {
            Board tmpBoard = new Board(this);
            foreach (Placement p in overlayPlacements)
            {
                Placement tmpPlacement = tmpBoard.SelectPlacement(p.GetPosition());
                tmpPlacement.MakeItDummy();
                tmpPlacement.PutPiece(p.GetPiece());
            }
            tmpBoard.Plot();
        }

        public int GetDimension()
        {
            return this.dimension;
        }

        public Placement SelectPlacement(Position p)
        {
            string key = p.ToString();
            if(this.placements.ContainsKey(key))
            {
                return this.placements[key];
            } else
            {
                throw new SystemException($"!!! Invalid Position Specified: {p} !!!");
            }
        }

        public Placement[] NextPossiblePlacements(Placement currentPlacement)
        {
            Console.WriteLine($"-- Plot Possible Next Moves for {currentPlacement.GetPiece().GetPieceType()} {currentPlacement.GetPosition()}");
            return ValidPlacement(currentPlacement);
        }

        private Placement[] ValidPlacement(Placement currentPlacement)
        {
            Placement[] nextPossiblePlacements = currentPlacement.NextPossiblePlacements(this.dimension);

            PlacementValidator[] validators = {
                new PlacementIsOnBoardValidator (this),
                new PlacementIsPieceInBetweenValidator (this)
            };

            List<Placement> validPlacements = new List<Placement>();
            foreach(Placement targetPlacement in nextPossiblePlacements) {
                Boolean validResult = true;
                foreach (PlacementValidator validator in validators)
                {
                    validator.SetCurrentPlacement(currentPlacement);
                    validator.SetTargetPlacement(targetPlacement);
                    if (!validator.Validate())
                    {
                        validResult = false;
                        break;
                    }
                }
                if (validResult)
                    validPlacements.Add(targetPlacement);
            }

            return validPlacements.ToArray();
        }
    }
}
