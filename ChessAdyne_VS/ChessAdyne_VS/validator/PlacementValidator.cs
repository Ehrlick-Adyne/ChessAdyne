using System;
using System.Collections.Generic;
using System.Text;

namespace ChessAdyne_VS.validator
{
    interface PlacementValidator
    {
        bool Validate();
        void SetCurrentPlacement(Placement p);
        void SetTargetPlacement(Placement p);
    }
}
