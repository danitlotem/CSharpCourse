using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly float r_MaxAirPressure;
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;

        public Wheel(float i_MaxAirPressure)
        {
            r_MaxAirPressure = i_MaxAirPressure;
        }

        public float MaxAirPressure
        {
            get { return r_MaxAirPressure; }
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }

            set
            {
                if (value > r_MaxAirPressure)
                {
                    throw new ArgumentException("Not valid air pressure");
                }
                else
                {
                    m_CurrentAirPressure = value;
                }
            }
        }

        public string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;
            }

            set
            {
                m_ManufacturerName = value;
            }
        }

        public void FillAirPressure(float i_AirPressureToFill)
        {
            m_CurrentAirPressure += i_AirPressureToFill;
        }

        public virtual List<VehicleInfoQuestions> GetWheelsInfoQuestionsList()
        {
            List<VehicleInfoQuestions> infoQuestionsForUser = new List<VehicleInfoQuestions>();

            string airPressureMsg = string.Format("Please insert the current air pressure between 0 to {0}", MaxAirPressure);
            VehicleInfoQuestions airPressureQuestion = new VehicleInfoQuestions(VehicleInfoQuestions.eTypeOfQuestion.ValueBetweenRangeQuestion, airPressureMsg, 0, MaxAirPressure);
            string manufactureMsg = string.Format("Please insert the wheel manufacture name: ");
            VehicleInfoQuestions wheelManufactureQuestion = new VehicleInfoQuestions(VehicleInfoQuestions.eTypeOfQuestion.StringQuestion, manufactureMsg);
            infoQuestionsForUser.Add(airPressureQuestion);
            infoQuestionsForUser.Add(wheelManufactureQuestion);

            return infoQuestionsForUser;
        }

        public override string ToString()
        {
            return string.Format(
                @"Manufacture: {0}, Maximum Air Pressure: {1}, Current Air Pressure: {2}",
                ManufacturerName,
                MaxAirPressure,
                CurrentAirPressure);
        }
    }
}
