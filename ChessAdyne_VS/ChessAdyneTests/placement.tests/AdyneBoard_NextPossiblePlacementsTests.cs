using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using ChessAdyne_VS;
using ChessAdyne_VS.piece;

namespace ChessAdyneTests.placement.tests
{
    [TestClass]
    public class AdyneBoard_NextPossiblePlacementsTests
    {
        Board _adyneBoard;
        Chess _chess;

        [TestInitialize]
        public void Initialize()
        {
            _adyneBoard = new Board(new AdyneBoardConfig());
            _chess = new Chess(_adyneBoard);
        }

        [TestMethod]
        public void KnightsResult_ShouldMatchExpectedResult_IfBeingPlacedAt_4_3_OnAnEmptyAdyneBoard()
        {
            Placement p = _adyneBoard.Place(new KnightPiece(), new Position(4, 3));
            Position[] expectedPositions =
            {
                new Position(5, 5),
                new Position(5, 1),
                new Position(6, 4),
                new Position(6, 2),
                new Position(3, 5),
                new Position(3, 1),
                new Position(2, 4),
                new Position(2, 2)
            };
            List<Position> results = new List<Position>();
            foreach(Placement plc in _chess.NextPossiblePlacements(p))
            {
                results.Add(plc.GetPosition());
            }
            CollectionAssert.AreEqual(expectedPositions, results);            
        }

        [TestMethod]
        public void BishopResult_ShouldMatchExpectedResult_IfBeingPlacedAt_4_3_OnAnEmptyAdyneBoard()
        {
            Placement p = _adyneBoard.Place(new BishopPiece(), new Position(4, 3));
            Position[] expectedPositions =
            {
                new Position(5, 4),
                new Position(5, 2),
                new Position(3, 4),
                new Position(3, 2),
                new Position(6, 5),
                new Position(6, 1),
                new Position(2, 5),
                new Position(2, 1),
                new Position(7, 6),
                new Position(1, 6),
                new Position(8, 7)
            };
            List<Position> results = new List<Position>();
            foreach (Placement plc in _chess.NextPossiblePlacements(p))
            {
                results.Add(plc.GetPosition());
            }
            CollectionAssert.AreEqual(expectedPositions, results);
        }
    }
}
