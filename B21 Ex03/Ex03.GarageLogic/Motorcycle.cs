using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private const int k_MinLicenseTypeOption = 1;
        private const int k_MaxLicenseTypeOption = 4;
        private int m_EngineVolume;
        private eLicenseType m_LicenseType;

        public Motorcycle(string i_LicenseNumber, Engine i_EngineType) : base(i_LicenseNumber, 30, eNumOfWheels.Two, i_EngineType)
        {
        }

        public int EngineVolume
        {
            get
            {
                return m_EngineVolume;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Engine volume must be positive");
                }
                else
                {
                    m_EngineVolume = value;
                }
            }
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }

            set
            {
                if ((int)value < k_MinLicenseTypeOption || (int)value > k_MaxLicenseTypeOption)
                {
                    throw new ValueOutOfRangeException(k_MinLicenseTypeOption, k_MaxLicenseTypeOption, "License type");
                }
                else
                {
                    m_LicenseType = value;
                }
            }
        }

        public override List<VehicleInfoQuestions> GetQuestionsList()
        {
            List<VehicleInfoQuestions> infoQuestionsForUser = new List<VehicleInfoQuestions>();
            StringBuilder licenseTypeMsg = new StringBuilder();

            infoQuestionsForUser.AddRange(base.GetQuestionsList());
            licenseTypeMsg.Append("Please insert motorcycle license type:");
            licenseTypeMsg.Append(Environment.NewLine);

            for (short i = 1; i <= Enum.GetNames(typeof(Motorcycle.eLicenseType)).Length; i++)
            {
                licenseTypeMsg.Append(i.ToString());
                licenseTypeMsg.Append(" - ");
                licenseTypeMsg.Append(Enum.GetName(typeof(Motorcycle.eLicenseType), i));
                licenseTypeMsg.Append(Environment.NewLine);
            }

            string engineVolumeMsg = string.Format("Please insert the motorcycle engine volume: ");
            VehicleInfoQuestions licenseTypeQuestion = new VehicleInfoQuestions(VehicleInfoQuestions.eTypeOfQuestion.ValueBetweenRangeQuestion, licenseTypeMsg.ToString(), k_MinLicenseTypeOption, k_MaxLicenseTypeOption);
            VehicleInfoQuestions engineVolumeQuestion = new VehicleInfoQuestions(VehicleInfoQuestions.eTypeOfQuestion.ValueBetweenRangeQuestion, engineVolumeMsg);
            infoQuestionsForUser.Add(licenseTypeQuestion);
            infoQuestionsForUser.Add(engineVolumeQuestion);

            return infoQuestionsForUser;
        }

        public override void InitVehicleInfo(List<string> i_VehicleInfoToInit)
        {
            base.InitVehicleInfo(i_VehicleInfoToInit);
            int licenseTypeInt = int.Parse(i_VehicleInfoToInit[4]);
            EngineVolume = int.Parse(i_VehicleInfoToInit[5]);
            LicenseType = (eLicenseType)licenseTypeInt;
        }

        public override string ToString()
        {
            return string.Format(
                @"{0} 
License type: {1} , Engine volume: {2}

", base.ToString(), LicenseType.ToString(), EngineVolume.ToString());
        }

        public enum eLicenseType
        {
            A = 1,
            A1,
            AA,
            B
        }
    }
}
