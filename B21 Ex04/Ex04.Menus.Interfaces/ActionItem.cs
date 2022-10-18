using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class ActionItem : MenuItem, IExecuteItems
    {
        ////C'tor
        public ActionItem(string i_ItemName) : base(i_ItemName)
        {
        }

        ////Methods
        public virtual void Click()
        {
            Show();
        }
    }
}