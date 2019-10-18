using System;
using System.Collections.Generic;
using System.Text;

namespace ChessAdyne_VS.validator
{
    interface PositionValidator
    {
        bool validate();
        void setCurrentPosition(Position _p);
        void setTargetPosition(Position _p);
    }
}
