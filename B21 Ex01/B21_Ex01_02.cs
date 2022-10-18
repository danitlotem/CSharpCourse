using System;
using System.Text;

namespace B21_Ex01_02
{
    public class Program
    {
        public static void SandClockRec(int i_NumOfSpacesInEachSideOfRow, int i_NumOfAsterisksToPrint)
        {
            string stringOfSpacesToPrint = new string(' ', i_NumOfSpacesInEachSideOfRow);
            string stringOfAsterisksToPrint = new string('*', i_NumOfAsterisksToPrint);
            string fullStringToPrint = string.Format(
                "{0}{1}{2}",
                stringOfSpacesToPrint,
                stringOfAsterisksToPrint,
                stringOfSpacesToPrint);
            Console.WriteLine(fullStringToPrint);
            if(i_NumOfAsterisksToPrint == 1)
            {
                return;
            }
                
            SandClockRec(i_NumOfSpacesInEachSideOfRow + 1, i_NumOfAsterisksToPrint - 2);
            Console.WriteLine(fullStringToPrint);
        }

        public static void SandClock(int i_HeightOfSandClock)
        {
            int numOfSpacesInEachSideOfRow = 0;
            SandClockRec(numOfSpacesInEachSideOfRow, i_HeightOfSandClock);
        }

        public static void Main()
        {
            SandClock(5);
        }
    }
}