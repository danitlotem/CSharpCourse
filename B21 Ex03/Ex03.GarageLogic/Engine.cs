using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        ////Data members
        private float m_MaxEnergy;
        private float m_CurrentEnergyStatus;

        ////C'tor
        public Engine(float i_MaxEnergy)
        {
            m_MaxEnergy = i_MaxEnergy;
        }

        ////Properties
        public float MaxEnergy
        {
            get
            {
                return m_MaxEnergy;
            }

            set
            {
                m_MaxEnergy = value;
            }
        }

        public float CurrentEnergyStatus
        {
            get
            {
                return m_CurrentEnergyStatus;
            }

            set
            {
                if (value > 0 && value <= MaxEnergy)
                {
                    m_CurrentEnergyStatus = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(0, MaxEnergy, "Energy level");
                }
            }
        }

        ////Methods
        public void IncreaseEnergyInVehicle(float i_EnergyAmountToAdd)
        {
            CurrentEnergyStatus += i_EnergyAmountToAdd;
        }

        public virtual List<VehicleInfoQuestions> GetEngineInfoQuestionsList()
        {
            List<VehicleInfoQuestions> infoQuestionsForUser = new List<VehicleInfoQuestions>();

            string energyStatusMsg = string.Format("Please insert the energy status from 0 to {0}", MaxEnergy);
            VehicleInfoQuestions energyStatusQuestion = new VehicleInfoQuestions(VehicleInfoQuestions.eTypeOfQuestion.ValueBetweenRangeQuestion, energyStatusMsg, 0, MaxEnergy);
            infoQuestionsForUser.Add(energyStatusQuestion);

            return infoQuestionsForUser;
        }

        public override string ToString()
        {
            return string.Format("Current Energy Level: {0}", CurrentEnergyStatus / MaxEnergy * 100);
        }
    }
}