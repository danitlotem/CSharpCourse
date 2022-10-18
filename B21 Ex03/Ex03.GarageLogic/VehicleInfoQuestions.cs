using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleInfoQuestions
    {
        private readonly eTypeOfQuestion r_QuestionType;
        private string m_Question;
        private float? m_MinValueOption;
        private float? m_MaxValueOption;

        public VehicleInfoQuestions(eTypeOfQuestion i_TypeOfQuestion, string i_Question)
        {
            r_QuestionType = i_TypeOfQuestion;
            m_Question = i_Question;
        }

        public VehicleInfoQuestions(eTypeOfQuestion i_TypeOfQuestion, string i_Question, float i_MinValue, float i_MaxValue)
        {
            r_QuestionType = i_TypeOfQuestion;
            m_Question = i_Question;
            MinValue = i_MinValue;
            MaxValue = i_MaxValue;
        }

        public float MaxValue
        {
            get
            {
                if (m_MaxValueOption.HasValue)
                {
                    return m_MaxValueOption.Value;
                }
                else
                {
                    throw new Exception("Argument is not initialized");
                }
            }

            set
            {
                m_MaxValueOption = value;
            }
        }

        public float MinValue
        {
            get
            {
                if (m_MinValueOption.HasValue)
                {
                    return m_MinValueOption.Value;
                }
                else
                {
                    throw new Exception("Argument is not initialized");
                }
            }

            set
            {
                m_MinValueOption = value;
            }
        }

        public eTypeOfQuestion TypeOfQuestion
        {
            get
            {
                return r_QuestionType;
            }
        }

        public string Question
        {
            get
            {
                return m_Question;
            }

            set
            {
                m_Question = value;
            }
        }

        public enum eTypeOfQuestion
        {
            BooleanQuestion,
            StringQuestion,
            ValueBetweenRangeQuestion
        }

        public bool CheckAnswerValidation(string i_Answer)
        {
            bool isUserAnswerValid;

            switch (this.TypeOfQuestion)
            {
                case VehicleInfoQuestions.eTypeOfQuestion.BooleanQuestion:
                    isUserAnswerValid = (i_Answer == "y" || i_Answer == "n") ? true : false;
                    break;
                case VehicleInfoQuestions.eTypeOfQuestion.StringQuestion:
                    isUserAnswerValid = (i_Answer.Length == 0) ? false : true;
                    break;
                case VehicleInfoQuestions.eTypeOfQuestion.ValueBetweenRangeQuestion:
                    float answerFloatFormat = float.Parse(i_Answer);
                    isUserAnswerValid = (answerFloatFormat < MinValue || answerFloatFormat > MaxValue) ? false : true;
                    break;
                default:
                    isUserAnswerValid = false;
                    break;
            }

            return isUserAnswerValid;
        }
    }
}
