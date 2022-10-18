using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        ////C'tor
        public ElectricEngine(float i_MaxEnergy)
            : base(i_MaxEnergy)
        {
        }

        ////Methods
        public override string ToString()
        {
            return string.Format(@"Current battery status: {0}", CurrentEnergyStatus);
        }
    }
}