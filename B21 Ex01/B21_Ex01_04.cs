using System;
using System.Text;

namespace B21_Ex01_04
{
    public class Program
    {
        public static void CheckIfStringIsPalindrome(string i_StringToCheck)
        {
            if(CheckIfStringIsPalindromeRec(i_StringToCheck))
            {
                Console.WriteLine("The string is a palindrome");
            }
            else
            {
                Console.WriteLine("The String is not a palindrome");
            }
        }

        public static bool CheckIfStringIsPalindromeRec(string i_StringToCheck)
        {
            short stringLen = (short)i_StringToCheck.Length;
            bool isStringPalindrome = true;
            if (i_StringToCheck[0] != i_StringToCheck[stringLen - 1])
            {
                isStringPalindrome = false;
            }
            else if (stringLen == 2)
            {
                isStringPalindrome = true;
            }
            else
            {
                isStringPalindrome = CheckIfStringIsPalindromeRec(i_StringToCheck.Substring(1, stringLen - 2));
            }

            return isStringPalindrome;
        }

        public static void IsNumberDividedBy4(double i_NumToCheck)
        {
            bool isNumberDividedBy4 = true;

            i_NumToCheck %= 100;
            isNumberDividedBy4 = ((int)(i_NumToCheck / 10) + (i_NumToCheck % 10)) % 4 == 0;

            if(isNumberDividedBy4)
            {
                Console.WriteLine("The number is divided by 4");
            }
            else
            {
                Console.WriteLine("The number is not divided by 4");
            }
        }

        public static bool CheckIfInputIsNumber(string i_StringToCheck)
        {
            bool isInputIsNumber = true;
            short stringLength = (short)i_StringToCheck.Length;

            for (short indexToCheckInString = 0; indexToCheckInString < stringLength && isInputIsNumber; indexToCheckInString++)
            {
                isInputIsNumber = char.IsDigit(i_StringToCheck[indexToCheckInString]);
            }

            return isInputIsNumber;
        }

        public static void CountNumberOfUpperCase(string i_StringToCheck)
        {
            short countOfUpperCase = 0, stringLength = (short)i_StringToCheck.Length;
            for (short indexToCheckInString = 0; indexToCheckInString < stringLength; indexToCheckInString++)
            {
                if (char.IsUpper(i_StringToCheck[indexToCheckInString]))
                {
                    countOfUpperCase++;
                }
            }

            Console.WriteLine("The string has {0} upper-case", countOfUpperCase);
        }

        public static bool IsInputValid(string i_StrToCheck)
        {
            short stringLength = (short)i_StrToCheck.Length;
            bool isInputValid = true;

            if (stringLength == 10)
            {
                bool isDigit = char.IsDigit(i_StrToCheck[0]);
                if (isDigit)
                {
                    isInputValid = double.TryParse(i_StrToCheck, out double numParseCheck);
                }
                else
                {
                    for (short indexToCheckInString = 1; indexToCheckInString < stringLength && isInputValid; indexToCheckInString++)
                    {
                        isInputValid = (i_StrToCheck[indexToCheckInString] >= 'a' && i_StrToCheck[indexToCheckInString] <= 'z')
                                       || (i_StrToCheck[indexToCheckInString] >= 'A' && i_StrToCheck[indexToCheckInString] <= 'Z');
                    }
                }
            }
            else
            {
                isInputValid = false;
            }

            return isInputValid;
        }

        public static void RunProgram()
        {
            Console.WriteLine("Please enter a string of 10 characters (only digits or only alphabet) and then press 'ENTER'");
            string stringToAnalyze = Console.ReadLine();
            while (!IsInputValid(stringToAnalyze))
            {
                Console.WriteLine("Please enter a string of 10 characters (only digits or only alphabet) and then press 'ENTER'");
                stringToAnalyze = Console.ReadLine();
            }

            CheckIfStringIsPalindrome(stringToAnalyze);
            bool isInputNumber = CheckIfInputIsNumber(stringToAnalyze);
            if (isInputNumber)
            {
                IsNumberDividedBy4(double.Parse(stringToAnalyze));
            }
            else
            {
                CountNumberOfUpperCase(stringToAnalyze);
            }
        }

        public static void Main()
        {
            RunProgram();
        }
    }
}
