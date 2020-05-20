using System;
using System.Collections.Generic;
using System.Text;
using Shooter.Core.Abstractions;

namespace Shooter.Core.Implementations.Transport
{
    public class Jumpjet
    {
        public IPilot Pilot { get; set; }

        public void Fly()
        {
            Pilot.Fly();
        }

        public void ThrowBombs()
        {
            Pilot.ThrowBombs();
        }
    }
}