using System;
using System.Collections.Generic;
using System.Threading;
using Ex04.Menus;

namespace Ex04.Menus.Test
{
    public class ExecuteItems : Interfaces.ActionItem
    {
        ////Data members
        private readonly eActionType r_ActionType;

        ////C'tor
        public ExecuteItems(eActionType i_ActionType, string i_ItemName) : base(i_ItemName)
        {
            r_ActionType = i_ActionType;
        }

        ////Property
        public eActionType ActionType
        {
            get
            {
                return r_ActionType;
            }
        }

        ////Methods
        public static void CountNumberOfSpaces()
        {
            int spaceCounter = 0;

            Console.WriteLine("{0}Please enter a sentence: ", Environment.NewLine);
            Console.Write("Answer: ");
            string sentenceToCheck = Console.ReadLine();

            foreach (char letter in sentenceToCheck)
            {
                if (letter == ' ')
                {
                    spaceCounter++;
                }
            }

            string spaceCounterMsg = string.Format(@"
In the sentence: {0}
There are {1} spaces", sentenceToCheck, spaceCounter);
            Console.WriteLine(spaceCounterMsg);
        }

        public static void ShowTime()
        {
            string showTimeMsg = string.Format(@"
{0}", DateTime.Now.TimeOfDay.ToString());
            Console.WriteLine(showTimeMsg);
        }

        public static void ShowVersion()
        {
            Console.WriteLine("{0}Version: 21.1.4.8930", Environment.NewLine);
        }

        public static void ShowDate()
        {
            string showDateMsg = string.Format(@"
{0}", DateTime.Now.ToShortDateString());
            Console.WriteLine(showDateMsg);
        }

        public override void Click()
        {
            Show();
            switch (ActionType)
            {
                case eActionType.ShowVersion:
                    ShowVersion();
                    break;
                case eActionType.CountNumberOfSpaces:
                    CountNumberOfSpaces();
                    break;
                case eActionType.ShowDate:
                    ShowDate();
                    break;
                case eActionType.ShowTime:
                    ShowTime();
                    break;
            }

            Thread.Sleep(2000);
        }

        public enum eActionType
        {
            ShowVersion = 1,
            CountNumberOfSpaces,
            ShowDate,
            ShowTime
        }
    }
}
