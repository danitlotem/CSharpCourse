using System;
using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public class MainMenu : SubMenuItem
    {
        ////C'tor
        public MainMenu(List<MenuItem> i_MenuOptions, short i_LevelMenu) : base(i_MenuOptions, "Delegates Main menu", i_LevelMenu)
        {
        }

        ////Methods
        protected override MenuItem BackOrExitOption()
        {
            return new ActionItem("Exit");
        }
    }
}
