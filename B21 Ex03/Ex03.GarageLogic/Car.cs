using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        ////Data members
        private const int k_MinNumberOfDoorsOption = 1;
        private const int k_MaxNumberOfDoorsOption = 4;
        private const int k_MinColorOption = 1;
        private const int k_MaxColorOption = 4;
        private eCarColor m_CarColor;
        private eNumberOfDoorsInCar m_NumberOfDoorsInCar;

        ////C'tor
        public Car(string i_LicenseNumber, Engine i_Engine) : base(i_LicenseNumber, 32, eNumOfWheels.Four, i_Engine)
        {
        }

        ////Properties
        public eCarColor CarColor
        {
            get
            {
                return m_CarColor;
            }

            set
            {
                m_CarColor = value;
            }
        }

        public eNumberOfDoorsInCar NumberOfDoorsInCar
        {
            get
            {
                return m_NumberOfDoorsInCar;
            }

            set
            {
                m_NumberOfDoorsInCar = value;
            }
        }

        ////Methods
        public override List<VehicleInfoQuestions> GetQuestionsList()
        {
            List<VehicleInfoQuestions> infoQuestionsForUser = new List<VehicleInfoQuestions>();
            StringBuilder numberOfDoorsMsg = new StringBuilder();
            StringBuilder carColorMsg = new StringBuilder();

            infoQuestionsForUser.AddRange(base.GetQuestionsList());
            numberOfDoorsMsg.Append("Please insert the car number of Doors");
            numberOfDoorsMsg.Append(Environment.NewLine);

            for (short i = 1; i <= Enum.GetNames(typeof(Car.eNumberOfDoorsInCar)).Length; i++)
            {
                numberOfDoorsMsg.Append(i.ToString());
                numberOfDoorsMsg.Append(" - ");
                numberOfDoorsMsg.Append(Enum.GetName(typeof(Car.eNumberOfDoorsInCar), i + 1));
                numberOfDoorsMsg.Append(Environment.NewLine);
            }

            carColorMsg.Append("Please insert the car color:");
            carColorMsg.Append(Environment.NewLine);

            for (short i = 1; i <= Enum.GetNames(typeof(Car.eCarColor)).Length; i++)
            {
                carColorMsg.Append(i.ToString());
                carColorMsg.Append(" - ");
                carColorMsg.Append(Enum.GetName(typeof(Car.eCarColor), i));
                carColorMsg.Append(Environment.NewLine);
            }

            VehicleInfoQuestions numberOfDoorsQuestion = new VehicleInfoQuestions(VehicleInfoQuestions.eTypeOfQuestion.ValueBetweenRangeQuestion, numberOfDoorsMsg.ToString(), k_MinNumberOfDoorsOption, k_MaxNumberOfDoorsOption);
            VehicleInfoQuestions carColorQuestion = new VehicleInfoQuestions(VehicleInfoQuestions.eTypeOfQuestion.ValueBetweenRangeQuestion, carColorMsg.ToString(), k_MinColorOption, k_MaxColorOption);
            infoQuestionsForUser.Add(numberOfDoorsQuestion);
            infoQuestionsForUser.Add(carColorQuestion);

            return infoQuestionsForUser;
        }

        public override void InitVehicleInfo(List<string> i_VehicleInfoToInit)
        {
            base.InitVehicleInfo(i_VehicleInfoToInit);
            int doorsCountInt = int.Parse(i_VehicleInfoToInit[4]);
            int colorInt = int.Parse(i_VehicleInfoToInit[5]);
            NumberOfDoorsInCar = (eNumberOfDoorsInCar)doorsCountInt;
            CarColor = (eCarColor)colorInt;
        }

        public override string ToString()
        {
            return string.Format(
                @"{0} 
Car color: {1}, Number of doors: {2}

", base.ToString(), CarColor.ToString(), NumberOfDoorsInCar.ToString());
        }

        ////Enums
        public enum eCarColor
        {
            Red = 1,
            White,
            Silver,
            Black
        }

        public enum eNumberOfDoorsInCar
        {
            Two = 2,
            Three,
            Four,
            Five
        }
    }
}
