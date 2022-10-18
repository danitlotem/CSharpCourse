using System;
using System.Collections.Generic;
using System.Threading;

namespace Ex04.Menus.Delegates
{
    public delegate void ActionItemDelegate();

    public class ActionItem : MenuItem
    {
        public event ActionItemDelegate ActionDelegate;

        ////C'tor
        public ActionItem(string i_ItemName) : base(i_ItemName)
        {
        }

        ////Methods
        public virtual void Click()
        {
            Show();
            if(ActionDelegate != null)
            {
                ActionDelegate.Invoke();
            }
            
            Thread.Sleep(2000);
        }
    }
}
