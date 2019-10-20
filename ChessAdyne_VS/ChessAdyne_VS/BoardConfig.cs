using System;
using System.Collections.Generic;
using System.Text;

namespace ChessAdyne_VS
{
    public interface BoardConfig
    {
        int BoardIndexOffset();
        int Dimension();
        int LowerBound();
        int UpperBound();
    }
    abstract public class AbstractBoardConfig : BoardConfig
    {
        public static int DefaultBoardIndexOffSet = 0;
        public static int DefaultDimension = 8;

        private int boardIndexOffset;
        private int dimension;

        public AbstractBoardConfig() : this(AbstractBoardConfig.DefaultBoardIndexOffSet, AbstractBoardConfig.DefaultDimension) { }

        public AbstractBoardConfig(int boardIndexOffset, int dimension)
        {
            this.boardIndexOffset = boardIndexOffset;
            this.dimension = dimension;
        }

        public virtual int BoardIndexOffset()
        {
            return boardIndexOffset;
        }

        public virtual int Dimension()
        {
            return dimension;
        }

        public virtual int LowerBound()
        {
            return boardIndexOffset;
        }

        public virtual int UpperBound()
        {
            return dimension + boardIndexOffset;
        }
    }

    public class DefaultBoardConfig : AbstractBoardConfig { } 

    public class AdyneBoardConfig : AbstractBoardConfig
    {
        private static int AdyneBoardIndexOffset = 1;
        public AdyneBoardConfig() : base(AdyneBoardIndexOffset, AbstractBoardConfig.DefaultDimension) { }
    }
}
