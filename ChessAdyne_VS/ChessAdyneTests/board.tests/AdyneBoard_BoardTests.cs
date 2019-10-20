using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessAdyne_VS;

namespace ChessAdyneTests
{
    [TestClass]
    public class AdyneBoard_BoardTests
    {
        Board _adyneBoard;

        [TestInitialize]
        public void Initialize()
        {
            _adyneBoard = new Board(new AdyneBoardConfig());
        }

        [TestMethod]
        public void AdyneBoard_ShouldHaveBottomLeftCell_At_1_1()
        {
            var (realX, realY) = (0, 0);
            Assert.AreEqual(new Position(1, 1), _adyneBoard.RealCoordinateToPosition(realX, realY));
        }

        [TestMethod]
        public void AdyneBoard_ShouldHaveBottomRightCell_At_1_8()
        {
            var (realX, realY) = (0, 7);
            Assert.AreEqual(new Position(1, 8), _adyneBoard.RealCoordinateToPosition(realX, realY));
        }

        [TestMethod]
        public void AdyneBoard_ShouldHaveTopLeftCell_At_8_1()
        {
            var (realX, realY) = (7, 0);
            Assert.AreEqual(new Position(8, 1), _adyneBoard.RealCoordinateToPosition(realX, realY));
        }

        [TestMethod]
        public void AdyneBoard_ShouldHaveTopRightCell_At_8_8()
        {
            var (realX, realY) = (7, 7);
            Assert.AreEqual(new Position(8, 8), _adyneBoard.RealCoordinateToPosition(realX, realY));
        }
    }
}
