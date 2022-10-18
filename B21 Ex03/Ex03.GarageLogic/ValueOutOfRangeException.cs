using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private const string m_ExceptionMsg = "{0} is out of range. Next time, please enter value between {1} to {2}";
        private readonly float r_MaxValue;
        private readonly float r_MinValue;

        public ValueOutOfRangeException(float i_Min, float i_Max, string i_NotValidData) : base(string.Format(m_ExceptionMsg, i_NotValidData, i_Min, i_Max))
        {
            r_MaxValue = i_Max;
            r_MinValue = i_Min;
        }
    }
}