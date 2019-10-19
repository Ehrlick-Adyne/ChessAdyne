using System;
using System.Collections.Generic;
using System.Text;
using ChessAdyne_VS.piece;

namespace ChessAdyne_VS
{
    struct Position
    {
        private int x;
        private int y;
        private PositionColor color;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.color = CurrentPositionColor(x, y);
        }

        public int GetX()
        {
            return this.x;
        }

        public int GetY()
        {
            return this.y;
        }

        static private PositionColor CurrentPositionColor(int x, int y)
        {
            if ((x + y) % 2 == 0) return PositionColor.Black;
            else return PositionColor.White;
        }

        public override string ToString()
        {
            return $"({x}, {y})";
        }

        public String GetSymbol()
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
