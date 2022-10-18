using System;
using System.Text;
using B21_Ex01_02;

namespace B21_Ex01_03
{
    public class Program
    {
        public static void RunProgram()
        {
            bool isValidHeight = true;

            Console.WriteLine("Please enter the number of lines for the sand machine and then press 'ENTER'");
            string heightOfSandClockInStringForm = Console.ReadLine();
            isValidHeight = int.TryParse(heightOfSandClockInStringForm, out int heightOfSandClock);
            while(!isValidHeight || heightOfSandClock < 0)
            {
                Console.WriteLine("Please enter the number of lines for the sand machine and then press 'ENTER'");
                heightOfSandClockInStringForm = Console.ReadLine();
                isValidHeight = int.TryParse(heightOfSandClockInStringForm, out heightOfSandClock);
            }

            if (heightOfSandClock % 2 == 0)
            {
                heightOfSandClock++;
            }
            Console.WriteLine("----------------------------------------------------");
            B21_Ex01_02.Program.SandClock(heightOfSandClock);
        }

        public static void Main()
        {
            RunProgram();
        }
    }
}
