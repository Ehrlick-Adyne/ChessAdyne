using System;
using System.Collections.Generic;
using System.Text;
using ChessAdyne_VS.validator;

namespace ChessAdyne_VS
{
    class Board
    {
        private Position[,] positions;
        private int dimension;

        public Board() : this(8) { }

        public Board(int d)
        {
            this.dimension = d;
            this.positions = new Position[this.dimension, this.dimension];
            for (int x = 0; x < this.dimension; x++)
            {
                for (int y = 0; y < this.dimension; y++)
                {
                    this.positions[x, y] = new Position(null, x, y);
                }
            }
        }

        public Board(Board board) : this(board.dimension)
        {
            for (int x = 0; x < this.dimension; x++)
            {
                for (int y = 0; y < this.dimension; y++)
                {
                    this.positions[x, y] = new Position(board.positions[x, y].GetPiece(), x, y);
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
                    Console.Write($" + {this.positions[x, y]}");
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

        public void PlotOverlayPositions(Position[] overlayPositions)
        {
            Board tmpBoard = new Board(this);
            foreach (Position p in overlayPositions)
            {
                tmpBoard.SelectPosition(p.GetDisplayX(), p.GetDisplayY()).PutPiece(p.GetPiece());
            }
            tmpBoard.Plot();
        }

        public int GetDimension()
        {
            return this.dimension;
        }

        public Position SelectPosition(int displayX, int displayY)
        {
            int[] xy = TranslateXY(displayX, displayY);
            return positions[xy[0], xy[1]];
        }

        public Position[] NextPossiblePositions(Position p)
        {
            Console.WriteLine($"-- Plot Possible Next Moves for {p.GetPiece().GetPieceType().ToString()} ({p.GetDisplayX()} , {p.GetDisplayY()})");
            return ValidPositions(p);
        }

        private Position[] ValidPositions(Position currentPos)
        {
            Position[] ps = currentPos.NextPossiblePositions(this.dimension);

            PositionValidator[] validators = {
                new PositionIsOnBoardValidator (this),
                new PositionIsPieceInBetweenValidator (this)
            };

            List<Position> validPs = new List<Position>();
            for (int i = 0; i < ps.Length; i++)
            {
                Position targetPos = ps[i];

                Boolean validResult = true;
                foreach (PositionValidator validator in validators)
                {
                    validator.SetCurrentPosition(currentPos);
                    validator.SetTargetPosition(targetPos);
                    if (!validator.Validate())
                    {
                        validResult = false;
                        break;
                    }
                }

                if (validResult)
                    validPs.Add(targetPos);
            }

            return validPs.ToArray();
        }

        private int[] TranslateXY(int displayX, int displayY)
        {
            int x = displayX - 1;
            int y = displayY - 1;

            PositionValidator validator = new PositionIsOnBoardValidator(this);
            validator.SetTargetPosition(new Position(null, x, y));

            if (!validator.Validate())
                throw new SystemException($"Invalid X/Y: {displayX}/{displayY}");

            int[] r = { x, y };
            return r;
        }
    }
}
