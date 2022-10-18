using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class SubMenuItem : MenuItem
    {
        ////Data members
        private List<MenuItem> m_SubMenu;
        private short m_MenuLevel;

        ////C'tor
        public SubMenuItem(List<MenuItem> i_MenuOptions, string i_ItemName, short i_MenuLevel) : base(i_ItemName)
        {
            m_MenuLevel = i_MenuLevel;
            m_SubMenu = i_MenuOptions;
            m_SubMenu.Insert(0, BackOrExitOption());
        }

        ////Property
        public List<MenuItem> SubMenu
        {
            get
            {
                return m_SubMenu;
            }

            set
            {
                m_SubMenu = value;
            }
        }

        public short MenuLevel
        {
            get
            {
                return m_MenuLevel;
            }

            set
            {
                m_MenuLevel = value;
            }
        }

        ////Methods
        public override void Show()
        {
            short userChoice = -1;

            while (userChoice != 0)
            {
                base.Show();
                Console.WriteLine(" (Menu level - {0})", MenuLevel);
                PrintMenu();
                userChoice = GetUserChoiceNumber();
                ApplyChoice(SubMenu[userChoice]);
            }
        }

        private void PrintMenu()
        {
            for (short i = 0; i < SubMenu.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i.ToString(), SubMenu[i].ItemName);
            }
        }

        public short GetUserChoiceNumber()
        {
            short userChoice;
            short maxChoiceInList = (short)(SubMenu.Count - 1);

            Console.WriteLine("{0}Please enter an option between 0 - {1}", Environment.NewLine, maxChoiceInList);
            Console.Write("Answer: ");
            string userChoiceStr = Console.ReadLine();

            while (!short.TryParse(userChoiceStr, out userChoice) || userChoice < 0 || userChoice > maxChoiceInList)
            {
                Console.WriteLine("Your Choice is not valid. Please enter an option between 0 - {0}", maxChoiceInList);
                Console.Write("Answer: ");
                userChoiceStr = Console.ReadLine();
            }

            return userChoice;
        }
    }
}
