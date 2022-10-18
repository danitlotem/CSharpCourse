using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu : SubMenuItem
    {
        ////C'tor
        public MainMenu(List<MenuItem> i_MenuOptions, short i_LevelMenu) : base(i_MenuOptions, "Interfaces Main menu", i_LevelMenu)
        {
        }
        
        ////Method
        public override MenuItem BackOrExitOption()
        {
            return new ActionItem("Exit");
        }
    }
}