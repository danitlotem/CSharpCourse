using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_IsDrivingDangerousMaterials;
        private float m_MaxCarryingWeight;

        public Truck(string i_LicenseNumber, Engine i_TruckEngine)
            : base(i_LicenseNumber, 26, eNumOfWheels.Sixteen, i_TruckEngine)
        {
        }

        public bool IsDrivingDangerousMaterials
        {
            get
            {
                return m_IsDrivingDangerousMaterials;
            }

            set
            {
                if(value != false && value != true)
                {
                    throw new FormatException("Not valid input for is driving dangerous materials");
                }
                else
                {
                    m_IsDrivingDangerousMaterials = value;
                }
            }
        }

        public float MaxCarryingWeight
        {
            get
            {
                return m_MaxCarryingWeight;
            }

            set
            {
                m_MaxCarryingWeight = value;
            }
        }

        public override List<VehicleInfoQuestions> GetQuestionsList()
        {
            List<VehicleInfoQuestions> infoQuestionsForUser = new List<VehicleInfoQuestions>();

            infoQuestionsForUser.AddRange(base.GetQuestionsList());
            string dangerousMaterialMsg = string.Format("Is the truck driving dangerous materials? (y - yes / n - no )");
            string CarryingWeightMsg = string.Format("Please insert the truck carrying Weight: ");
            VehicleInfoQuestions dangerousMaterialMsgQuestion = new VehicleInfoQuestions(
                VehicleInfoQuestions.eTypeOfQuestion.BooleanQuestion, dangerousMaterialMsg);
            VehicleInfoQuestions CarryingWeightMsgQuestion = new VehicleInfoQuestions(VehicleInfoQuestions.eTypeOfQuestion.StringQuestion,
                CarryingWeightMsg);

            infoQuestionsForUser.Add(dangerousMaterialMsgQuestion);
            infoQuestionsForUser.Add(CarryingWeightMsgQuestion);

            return infoQuestionsForUser;
        }

        public override void InitVehicleInfo(List<string> i_VehicleInfoToInit)
        {
            base.InitVehicleInfo(i_VehicleInfoToInit);
            IsDrivingDangerousMaterials = (i_VehicleInfoToInit[4] == "y") ? true : false;
            MaxCarryingWeight = float.Parse(i_VehicleInfoToInit[5]);
        }

        public override string ToString()
        {
            return string.Format(
                @"{0} 
Is truck driving dangerous materials: {1} , Carrying weight: {2}

",
                base.ToString(),
                IsDrivingDangerousMaterials.ToString(),
                MaxCarryingWeight.ToString());
        }
    }
}
