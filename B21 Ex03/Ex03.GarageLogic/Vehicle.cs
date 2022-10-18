using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        ////data members
        private readonly string r_VehicleLicenseNumber;
        private readonly List<Wheel> r_VehicleWheels;
        private string m_VehicleModel;
        private float m_VehicleEnergyLevel;
        private Engine m_VehicleEngine;

        ////methods
        public Vehicle(string i_LicenseNumber, float i_MaxAirPressure, eNumOfWheels i_NumberOfWheels, Engine i_Engine)
        {
            r_VehicleLicenseNumber = i_LicenseNumber;
            m_VehicleEngine = i_Engine;
            r_VehicleWheels = new List<Wheel>();
            InitListOfWheels((short)i_NumberOfWheels, i_MaxAirPressure);
        }

        ////property
        public string VehicleModel
        {
            get
            {
                return m_VehicleModel;
            }

            set
            {
                m_VehicleModel = value;
            }
        }

        public string VehicleLicenseNumber
        {
            get
            {
                return r_VehicleLicenseNumber;
            }
        }

        public float VehicleEnergyLevel
        {
            get
            {
                return m_VehicleEnergyLevel;
            }

            set
            {
                m_VehicleEnergyLevel = value;
            }
        }

        public List<Wheel> VehicleWheels
        {
            get
            {
                return r_VehicleWheels;
            }
        }

        public Engine VehicleEngine
        {
            get
            {
                return m_VehicleEngine;
            }

            set
            {
                m_VehicleEngine = value;
            }
        }

        public void InflateAirOnWheels()
        {
            foreach (Wheel wheel in VehicleWheels)
            {
                wheel.FillAirPressure(wheel.MaxAirPressure - wheel.CurrentAirPressure);
            }
        }

        public void UpdateEnergyLevel(float i_AmountToAdd)
        {
            VehicleEngine.IncreaseEnergyInVehicle(i_AmountToAdd);
            VehicleEnergyLevel = (i_AmountToAdd / VehicleEngine.MaxEnergy) * 100;
        }

        public void InitListOfWheels(short i_NumberOfWheels, float i_MaxAirPressure)
        {
            for (short i = 0; i < (short)i_NumberOfWheels; i++)
            {
                r_VehicleWheels.Add(new Wheel(i_MaxAirPressure));
            }
        }

        public virtual List<VehicleInfoQuestions> GetQuestionsList()
        {
            List<VehicleInfoQuestions> infoQuestionsForUser = new List<VehicleInfoQuestions>();

            VehicleInfoQuestions modelQuestion = new VehicleInfoQuestions(
                VehicleInfoQuestions.eTypeOfQuestion.StringQuestion,
                "Please insert the vehicle model: ");
            infoQuestionsForUser.Add(modelQuestion);
            infoQuestionsForUser.AddRange(VehicleEngine.GetEngineInfoQuestionsList());
            infoQuestionsForUser.AddRange(VehicleWheels[0].GetWheelsInfoQuestionsList());

            return infoQuestionsForUser;
        }

        public virtual void InitVehicleInfo(List<string> i_VehicleInfoToInit)
        {
            VehicleModel = i_VehicleInfoToInit[0];
            VehicleEngine.CurrentEnergyStatus = float.Parse(i_VehicleInfoToInit[1]);
            InitAllVehicleWheels(i_VehicleInfoToInit[2], i_VehicleInfoToInit[3]);
            VehicleEnergyLevel = (VehicleEngine.CurrentEnergyStatus / VehicleEngine.MaxEnergy) * 100;
        }

        public void InitAllVehicleWheels(string i_AirPressureInfo, string i_ManufactureInfo)
        {
            foreach (Wheel wheel in VehicleWheels)
            {
                wheel.CurrentAirPressure = float.Parse(i_AirPressureInfo);
                wheel.ManufacturerName = i_ManufactureInfo;
            }
        }

        public override string ToString()
        {
            return string.Format(
                @"License number: {0}, Model: {1}, Energy level: {2:0.00}%
Wheels information: Number of wheels: {3}, {4}
Engine information: {5}",
                VehicleLicenseNumber,
                VehicleModel,
                VehicleEnergyLevel,
                VehicleWheels.Count.ToString(),
                VehicleWheels[0].ToString(),
                VehicleEngine.ToString());
        }

        ////Enums
        public enum eNumOfWheels
        {
            Two = 2,
            Four = 4,
            Sixteen = 16
        }
    }
}
