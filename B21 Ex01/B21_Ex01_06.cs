using System;
using System.Text;

namespace B21_Ex01_06
{
    public class Program
    {
        private const char k_FromLetterToNumber = '0';

        public static bool IsNumberValid(string i_StrToCheck)
        {
            bool isNumberValid = true;
            short strLength = (short)i_StrToCheck.Length;

            isNumberValid = strLength == 6;

            for (short indexToCheckInString = 0; indexToCheckInString < strLength && isNumberValid; indexToCheckInString++)
            {
                isNumberValid = char.IsDigit(i_StrToCheck[indexToCheckInString]);
            }

            return isNumberValid;
        }

        public static short FindMaxDigitInNumber(string i_NumInStringForm)
        {
            char digitToCompare, maxDigit = k_FromLetterToNumber;
            
            for (short indexToCheckInString = 0; indexToCheckInString < i_NumInStringForm.Length; indexToCheckInString++)
            {
                digitToCompare = i_NumInStringForm[indexToCheckInString];

                if (digitToCompare > maxDigit)
                {
                    maxDigit = digitToCompare;
                }
            }

            return (short)(maxDigit - k_FromLetterToNumber);
        }

        public static short FindMinDigitInNumber(string i_NumInStringForm)
        {
            char digitToCompare, minDigit = '9';
            
            for (short indexToCheckInString = 0; indexToCheckInString < i_NumInStringForm.Length; indexToCheckInString++)
            {
                digitToCompare = i_NumInStringForm[indexToCheckInString];
                if (digitToCompare < minDigit)
                {
                    minDigit = digitToCompare;
                }
            }

            return (short)(minDigit - k_FromLetterToNumber);
        }

        public static short CountDigitsDividedBy3(int i_NumberToCheck)
        {
            short digitToCheck, countDigitsDividedBy3 = 0;

            while (i_NumberToCheck > 0)
            {
                digitToCheck = (short)(i_NumberToCheck % 10);
                if (digitToCheck % 3 == 0)
                {
                    countDigitsDividedBy3++;
                }

                i_NumberToCheck /= 10;
            }

            return countDigitsDividedBy3;
        }

        public static short CountDigitsBiggerThanDigit(int i_NumberToCheck, short i_DigitToCompare)
        {
            short moduloRes, countDigitsBiggerThanDigit = 0;

            while (i_NumberToCheck > 0)
            {
                moduloRes = (short)(i_NumberToCheck % 10);
                if (moduloRes > i_DigitToCompare)
                {
                    countDigitsBiggerThanDigit++;
                }

                i_NumberToCheck /= 10;
            }

            return countDigitsBiggerThanDigit;
        }

        public static void PrintStatisticsOfNumber(int i_Num, short i_MaxDigit, short i_MinDigit,
                                                   short i_NumOfDigitsDividedBy3, 
                                                   short i_NumOfDigitsBiggerThanDigit)
        {
            string msg = string.Format(
                @"The statistics of {0} are:
The biggest digit is {1}
The smallest digit is {2}
The number of digits that can divided by 3 is {3}
The number of digits that greater than the units digit is {4}",
                i_Num,
                i_MaxDigit,
                i_MinDigit,
                i_NumOfDigitsDividedBy3,
                i_NumOfDigitsBiggerThanDigit);
            Console.WriteLine(msg);
        }

        public static void RunProgram()
        {
            Console.WriteLine("Please enter a 6 digit number and then press 'ENTER' ");
            string numInStringForm = Console.ReadLine();
            while (!IsNumberValid(numInStringForm))
            {
                Console.WriteLine("Please enter a 6 digit number and then press 'ENTER' ");
                numInStringForm = Console.ReadLine();
            }

            int numberToAnalyze = int.Parse(numInStringForm);
            short maxDigit = FindMaxDigitInNumber(numInStringForm);
            short minDigit = FindMinDigitInNumber(numInStringForm);
            short numOfDigitsDividedBy3 = CountDigitsDividedBy3(numberToAnalyze);
            short numOfDigitsBiggerThanUnitsDigit = CountDigitsBiggerThanDigit(numberToAnalyze, (short)(numberToAnalyze % 10));
            PrintStatisticsOfNumber(numberToAnalyze, maxDigit, minDigit, numOfDigitsDividedBy3, numOfDigitsBiggerThanUnitsDigit);
        }

        public static void Main()
        {
            RunProgram();
        }
    }
}
