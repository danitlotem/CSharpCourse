using System;
using System.Text;

namespace B21_Ex01_01
{
    public class Program
    {
        public const int k_MaxValue = -127;
        public const int k_MinValue = 127;

        public static bool IsStringValid(string i_StringToCheck)
        {
            bool isStringValid = true;

            isStringValid = i_StringToCheck.Length == 7;

            for (short indexToCheckInString = 0; indexToCheckInString < i_StringToCheck.Length && isStringValid; indexToCheckInString++)
            {
                isStringValid = i_StringToCheck[indexToCheckInString] == '0' || i_StringToCheck[indexToCheckInString] == '1';
            }

            return isStringValid;
        }

        public static string GetInputFromUser()
        {
            string inputFromUser = Console.ReadLine();
            while (!IsStringValid(inputFromUser))
            {
                Console.WriteLine("Please enter 3 numbers with 7 digits (in binary presentation) and press 'ENTER':");
                inputFromUser = Console.ReadLine();
            }

            return inputFromUser;
        }

        public static short ConvertBinaryToDecimal(int i_NumInBinaryFormat)
        {
            short numInDecimalFormat = 0, coefficientToMultiply = 1, moduloResult;

            while (i_NumInBinaryFormat > 0)
            {
                moduloResult = (short)(i_NumInBinaryFormat % 10);
                i_NumInBinaryFormat /= 10;
                numInDecimalFormat += (short)(coefficientToMultiply * moduloResult);
                coefficientToMultiply *= 2;
            }

            return numInDecimalFormat;
        }

        public static void CountOnesAndZeros(string i_StringToCheck, ref short io_CountZerosInString, ref short io_CountOnesInString)
        {
            io_CountZerosInString += (short)(i_StringToCheck.Split('0').Length - 1);
            io_CountOnesInString += (short)(i_StringToCheck.Split('1').Length - 1);
        }

        public static void IsNumberIsPowerOfTwo(short i_NumberToCheck, ref short io_countNumbersOfPowerTwo)
        {
            if ((i_NumberToCheck & (i_NumberToCheck - 1)) == 0)
            {
                io_countNumbersOfPowerTwo++;
            }
        }

        public static void IsAscendingSeries(short i_NumberToCheck, ref short io_NumberOfAscendingSeries)
        {
            short moduloResToCompare, moduloResult = (short)(i_NumberToCheck % 10);
            i_NumberToCheck /= 10;
            bool isAscendingSeries = true, notEnteredWhileLoop = true;

            while (i_NumberToCheck > 0 && isAscendingSeries)
            {
                notEnteredWhileLoop = false;
                moduloResToCompare = (short)(i_NumberToCheck % 10);
                isAscendingSeries = moduloResToCompare < moduloResult;
                moduloResult = moduloResToCompare;
                i_NumberToCheck /= 10;
            }

            if ((!notEnteredWhileLoop) && isAscendingSeries)
            {
                io_NumberOfAscendingSeries++;
            }
        }

        public static void FindMaxNumber(short i_NumberToCheck, ref short i_MaxNumberValue)
        {
            i_MaxNumberValue = Math.Max(i_NumberToCheck, i_MaxNumberValue);
        }

        public static void FindMinNumber(short i_NumberToCheck, ref short i_MinNumberValue)
        {
            i_MinNumberValue = Math.Min(i_NumberToCheck, i_MinNumberValue);
        }

        public static void PrintNumbersStatistics(
            short i_MaxNumberValue,
            short i_MinNumberValue,
            short i_NumberOfAscendingSeries,
            short i_CountOfNumbersOfPowerTwo,
            short i_NumberOfOnes,
            short i_NumberOfZeros)
        {
            string msg = string.Format(
                @"The average number of zeros is {0}
The average number of ones is {1}
There are {2} numbers that is power of 2
There are {3} numbers which are an ascending series
The Maximum number is {4}
The Minimum number is {5}", i_NumberOfZeros, i_NumberOfOnes, i_CountOfNumbersOfPowerTwo, i_NumberOfAscendingSeries, 
                i_MaxNumberValue, i_MinNumberValue);
            Console.WriteLine(msg);
        }

        public static void RunProgram()
        {
            string numberInStringForm;
            short numberInDecimalForm, numberOfAscendingSeries = 0, numberOfNumberOfPowerTwo = 0, numberOfZeros = 0,
                  numberOfOnes = 0, maxNumberValue = k_MaxValue, minNumberValue = k_MinValue;
            StringBuilder decimalNumbersString = new StringBuilder("The decimal numbers are: ", 30);

            Console.WriteLine("Please enter 3 numbers with 7 digits (in binary presentation) and then press ENTER:");
            for (short inputIndex = 0; inputIndex < 3; inputIndex++)
            {
                numberInStringForm = GetInputFromUser();
                CountOnesAndZeros(numberInStringForm.ToString(), ref numberOfZeros, ref numberOfOnes);
                numberInDecimalForm = ConvertBinaryToDecimal(int.Parse(numberInStringForm));
                IsNumberIsPowerOfTwo(numberInDecimalForm, ref numberOfNumberOfPowerTwo);
                IsAscendingSeries(numberInDecimalForm, ref numberOfAscendingSeries);
                FindMaxNumber(numberInDecimalForm, ref maxNumberValue);
                FindMinNumber(numberInDecimalForm, ref minNumberValue);
                decimalNumbersString.AppendFormat(" {0}", numberInDecimalForm.ToString());
            }

            Console.WriteLine(decimalNumbersString);

            PrintNumbersStatistics(maxNumberValue, minNumberValue, numberOfAscendingSeries, numberOfNumberOfPowerTwo,
                (short)(numberOfOnes / 3), (short)(numberOfZeros / 3));
        }

        public static void Main()
        {
            RunProgram();
        }
    }
}