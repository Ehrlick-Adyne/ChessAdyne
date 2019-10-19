using System;
using System.Collections.Generic;
using System.Text;
using ChessAdyne_VS.validator;

namespace ChessAdyne_VS
{
    class Board
    {
        private List<Placement> placements;
        private readonly List<Position> positions = new List<Position>();
        private BoardConfig config;

        public Board() : this(new DefaultBoardConfig()) { }

        public Board(BoardConfig config)
        {
            this.config = config;
            this.placements = new List<Placement>();

            int loopStart = config.LowerBound();
            int loopEnd = config.UpperBound();
            for (int x = loopStart; x < loopEnd; x++)
            {
                for (int y = loopStart; y < loopEnd; y++)
                {
                    positions.Add(new Position(x, y));
                }
            }
        }

        public Board(Board board) : this(board.config)
        {
            this.placements = new List<Placement>(board.GetPlacements());
        }

        public List<Placement> GetPlacements()
        {
            return this.placements;
        }

        public void AddPlacement(Placement placement)
        {
            PlacementValidator validator = new PlacementIsOnBoardValidator(this);
            validator.SetTargetPlacement(placement);
            if (!validator.Validate())
                throw new SystemException($"{placement} is not on the board");

            Console.WriteLine($"-- Put a {placement}");
            this.placements.Add(placement);
        }

        public BoardConfig GetBoardConfig()
        {
            return this.config;
        }

        public void Plot()
        {
            int dimension = config.Dimension();
            int boardIndexOffset = config.BoardIndexOffset();

            string[,] allSymbols = new string[dimension, dimension];
            foreach(Position pos in this.positions)
            {
                allSymbols[pos.GetX() - boardIndexOffset, pos.GetY() - boardIndexOffset] = pos.GetSymbol();
            }
            foreach(Placement plc in this.placements)
            {
                Position pos = plc.GetPosition();
                allSymbols[pos.GetX() - boardIndexOffset, pos.GetY() - boardIndexOffset] = plc.GetSymbol();
            }

            int loopStart = config.LowerBound();
            int loopEnd = config.UpperBound();
            for (int x = loopEnd - 1; x > loopStart - 1; x--)
            {
                Console.Write(x);
                for (int y = loopStart; y < loopEnd; y++)
                {
                    Console.Write($" + {allSymbols[x - boardIndexOffset, y - boardIndexOffset]}");
                }
                Console.WriteLine("\n");
            }
            Console.Write(" ");
            for (int y = loopStart; y < loopEnd; y++)
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
                tmpBoard.AddPlacement(p);
            }
            tmpBoard.Plot();
        }

        public Placement[] NextPossiblePlacements(Placement currentPlacement)
        {
            Console.WriteLine($"-- Plot Possible Next Moves for {currentPlacement.GetPiece().GetPieceType()} {currentPlacement.GetPosition()}");
            return ValidPlacement(currentPlacement);
        }

        private Placement[] ValidPlacement(Placement currentPlacement)
        {
            Placement[] nextPossiblePlacements = currentPlacement.NextPossiblePlacements(config.Dimension());

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
