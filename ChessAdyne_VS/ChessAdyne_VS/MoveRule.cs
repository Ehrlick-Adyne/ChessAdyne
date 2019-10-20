using System;
using System.Collections.Generic;
using System.Text;

namespace ChessAdyne_VS
{
    public class MoveRule
    {
        private int xStep;
        private int yStep;

        public MoveRule(int _xStep, int _yStep)
        {
            this.xStep = _xStep;
            this.yStep = _yStep;
        }

        public int GetXStep()
        {
            return xStep;
        }

        public int GetYStep()
        {
            return yStep;
        }

        public override string ToString()
        {
            return $"MoveRule: x[{xStep}] y[{yStep}]";
        }
    }
}
