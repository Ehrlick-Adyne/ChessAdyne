using System;
using System.Collections.Generic;
using System.Text;
using ChessAdyne_VS.piece;

namespace ChessAdyne_VS
{
    class Position
    {
        private int x;
        private int y;
        private PositionColor color;

        public Position(int _x, int _y)
        {
            this.x = _x;
            this.y = _y;
            this.color = CurrentPositionColor(_x, _y);
        }

        public int GetX()
        {
            return this.x;
        }

        public int GetY()
        {
            return this.y;
        }

        public int GetDisplayX()
        {
            return this.x + 1;
        }

        public int GetDisplayY()
        {
            return this.y + 1;
        }

        private PositionColor CurrentPositionColor(int x_, int y_)
        {
            if (((x_ + 1) + (y_ + 1)) % 2 == 0) return PositionColor.Black;
            else return PositionColor.White;
        }

        public override String ToString()
        {
            switch (color)
            {
                case PositionColor.White:
                    return "| |";
                case PositionColor.Black:
                    return "[ ]";
                default:
                    throw new SystemException($"Unexpected PositionColor: {color}");
            }
        }
    }
}
