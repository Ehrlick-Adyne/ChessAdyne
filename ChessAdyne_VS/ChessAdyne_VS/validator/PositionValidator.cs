using System;
using System.Collections.Generic;
using System.Text;

namespace ChessAdyne_VS.validator
{
    interface PositionValidator
    {
        bool Validate();
        void SetCurrentPosition(Position _p);
        void SetTargetPosition(Position _p);
    }
}
