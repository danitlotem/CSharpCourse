using System;
using System.Collections.Generic;
using Ex04.Menus;

namespace Ex04.Menus.Test
{
    public class MenuTest
    {
        ////Data members
        private const short k_MainMenuLevel = 0;
        private const short k_SubMenuLevel = 1;
        private Interfaces.MainMenu m_InterfacesMainMenu;
        private Delegates.MainMenu m_DelegatesMainMenu;

        ////C'tor
        public MenuTest()
        {
            m_InterfacesMainMenu = new Interfaces.MainMenu(CreateInterfaceMenu(), k_MainMenuLevel);
            m_DelegatesMainMenu  = new Delegates.MainMenu(CreateDelegateMenu(), k_MainMenuLevel);
        }

        ////Property
        public Delegates.MainMenu DelegatesMainMenu
        {
            get
            {
                return m_DelegatesMainMenu;
            }

            set
            {
                m_DelegatesMainMenu = value;
            }
        }

        public Interfaces.MainMenu InterfacesMainMenu
        {
            get
            {
                return m_InterfacesMainMenu;
            }

            set
            {
                m_InterfacesMainMenu = value;
            }
        }
        
        ////Methods
        private static void AddItemsToDateAndTimeInterfaceMenu(ref List<Interfaces.MenuItem> io_DateAndTimeMenu)
        {
            io_DateAndTimeMenu.Add(new ExecuteItems(ExecuteItems.eActionType.ShowDate, "Show Date"));
            io_DateAndTimeMenu.Add(new ExecuteItems(ExecuteItems.eActionType.ShowTime, "Show Time"));
        }

        private static void AddItemsToShowVersionAndSpacesInterfaceMenu(ref List<Interfaces.MenuItem> io_VersionAndSpaceMenu)
        {
            io_VersionAndSpaceMenu.Add(new ExecuteItems(ExecuteItems.eActionType.ShowVersion, "Show Version"));
            io_VersionAndSpaceMenu.Add(new ExecuteItems(ExecuteItems.eActionType.CountNumberOfSpaces, "Count Spaces"));
        }

        private static List<Interfaces.MenuItem> CreateInterfaceMenu()
        {
            List<Interfaces.MenuItem> mainMenu = new List<Interfaces.MenuItem>();
            List<Interfaces.MenuItem> showVersionAndSpacesMenu = new List<Interfaces.MenuItem>();
            List<Interfaces.MenuItem> showDateAndTimeMenu = new List<Interfaces.MenuItem>();

            AddItemsToDateAndTimeInterfaceMenu(ref showDateAndTimeMenu);
            AddItemsToShowVersionAndSpacesInterfaceMenu(ref showVersionAndSpacesMenu);

            mainMenu.Add(new Interfaces.SubMenuItem(showVersionAndSpacesMenu, "Version and Spaces", k_SubMenuLevel));
            mainMenu.Add(new Interfaces.SubMenuItem(showDateAndTimeMenu, "Show Date/Time", k_SubMenuLevel));

            return mainMenu;
        }

        private static void AddItemsToShowVersionAndSpacesDelegateMenu(ref List<Delegates.MenuItem> io_VersionAndSpaceMenu)
        {
            Delegates.ActionItem actionItem = new Delegates.ActionItem("Show Version");
            actionItem.ActionDelegate += new Delegates.ActionItemDelegate(ExecuteItems.ShowVersion);
            io_VersionAndSpaceMenu.Add(actionItem);

            actionItem = new Delegates.ActionItem("Count Spaces");
            actionItem.ActionDelegate += new Delegates.ActionItemDelegate(ExecuteItems.CountNumberOfSpaces);
            io_VersionAndSpaceMenu.Add(actionItem);
        }

        private static void AddItemsToDateAndTimeDelegateMenu(ref List<Delegates.MenuItem> io_DateAndTimeMenu)
        {
            Delegates.ActionItem actionItem = new Delegates.ActionItem("Show Date");
            actionItem.ActionDelegate += new Delegates.ActionItemDelegate(ExecuteItems.ShowDate);
            io_DateAndTimeMenu.Add(actionItem);

            actionItem = new Delegates.ActionItem("Show Time");
            actionItem.ActionDelegate += new Delegates.ActionItemDelegate(ExecuteItems.ShowTime);
            io_DateAndTimeMenu.Add(actionItem);
        }

        private static List<Delegates.MenuItem> CreateDelegateMenu()
        {
            List<Delegates.MenuItem> mainMenu = new List<Delegates.MenuItem>();
            List<Delegates.MenuItem> showVersionAndSpacesMenu = new List<Delegates.MenuItem>();
            List<Delegates.MenuItem> showDateAndTimeMenu = new List<Delegates.MenuItem>();

            AddItemsToShowVersionAndSpacesDelegateMenu(ref showVersionAndSpacesMenu);
            AddItemsToDateAndTimeDelegateMenu(ref showDateAndTimeMenu);

            mainMenu.Add(new Delegates.SubMenuItem(showVersionAndSpacesMenu, "Version and Spaces", k_SubMenuLevel));
            mainMenu.Add(new Delegates.SubMenuItem(showDateAndTimeMenu, "Show Date/Time", k_SubMenuLevel));

            return mainMenu;
        }

        public void RunProgram()
        {
            try
            {
                RunMenus();
            }
            catch (ArgumentOutOfRangeException aoore)
            {
                Console.WriteLine(aoore.Message);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void RunMenus()
        {
            InterfacesMainMenu.Show();
            DelegatesMainMenu.Show();
        }
    }
}