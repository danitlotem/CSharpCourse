using System;
using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public abstract class MenuItem
    {
        ////Data members
        private string m_ItemName;

        ////C'tor
        protected MenuItem(string i_ItemName)
        {
            m_ItemName = i_ItemName;
        }

        ////Property
        public string ItemName
        {
            get
            {
                return m_ItemName;
            }

            set
            {
                m_ItemName = value;
            }
        }
        ////Methods
        public virtual void Show()
        {
            Console.Clear();
            Console.Write(m_ItemName);
        }

        protected void ApplyChoice(MenuItem i_ChosenOption)
        {
            if (i_ChosenOption is SubMenuItem)
            {
                i_ChosenOption.Show();
            }
            else
            {
                (i_ChosenOption as ActionItem).Click();
            }
        }

        protected virtual MenuItem BackOrExitOption()
        {
            return new ActionItem("Back");
        }
    }
}
