using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        ////Data members
        private readonly eFuelType r_FuelType;

        ////C'tor
        public FuelEngine(eFuelType i_FuelType, float i_MaxEnergy) : base(i_MaxEnergy)
        {
            r_FuelType = i_FuelType;
        }

        ////Properties
        public eFuelType FuelType
        {
            get
            {
                return r_FuelType;
            }
        }
        
        ////Methods
        public override string ToString()
        {
            return string.Format(
                @"Fuel Type: {0}, Current fuel status: {1}", FuelType, CurrentEnergyStatus);
        }

        ////Enums
        public enum eFuelType
        {
            Octan95,
            Octan96,
            Octan98,
            Soler
        }
    }
}