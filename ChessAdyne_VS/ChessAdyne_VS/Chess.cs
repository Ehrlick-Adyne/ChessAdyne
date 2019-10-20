using System;
using System.Collections.Generic;
using System.Text;
using ChessAdyne_VS.validator;

namespace ChessAdyne_VS
{
    public class Chess
    {
        private Board board;

        public Chess(Board board)
        {
            this.board = board;
        }

        public List<Placement> NextPossiblePlacements(Placement currentPlacement)
        {
            Console.WriteLine($"-- Calculating Possible Next Moves for {currentPlacement.GetPiece().GetPieceType()} {currentPlacement.GetPosition()}");

            Placement[] nextPossiblePlacements = currentPlacement.NextPossiblePlacements(board.GetBoardConfig().Dimension());

            PlacementValidator[] validators = {
                new PlacementIsOnBoardValidator (board),
                new PlacementIsPieceInBetweenValidator (board)
            };

            List<Placement> validPlacements = new List<Placement>();
            foreach (Placement targetPlacement in nextPossiblePlacements)
            {
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

            return validPlacements;
        }
    }
}
