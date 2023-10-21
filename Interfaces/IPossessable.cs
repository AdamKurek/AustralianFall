using AustralianFall.Classes.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AustralianFall.Interfaces
{
    internal interface IPossessable
    {
        void Tick(MovementControl.keyHeld direction = MovementControl.keyHeld.none);
    }
}
