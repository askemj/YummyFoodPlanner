using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Menu : IMenu
    {
        public event EventHandler<MenuEventArgs> MenuUpdated;
        public List<string> MenuList { get; set; }
        public Menu()
        {

        }

        public void Update()
        {
            // update menu 
        }

        public void Search(string key)
        {
            // search for keyword 
            MenuList.Clear(); 
            MenuList.Add("Boller I Karry");
        }

        public void RaiseMenuUpdatedEvent()
        {
            MenuUpdated?.Invoke(this, new MenuEventArgs(this));
        }
    }

    public class MenuEventArgs : EventArgs
    {
        public Menu menu { get; set;}   

        public MenuEventArgs(Menu _menu)
        {
            this.menu = _menu;  
        }
    }
}
