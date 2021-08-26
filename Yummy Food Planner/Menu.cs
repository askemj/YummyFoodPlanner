using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Model
{
    public class Menu : IMenu
    {
        public event EventHandler<EventArgs> MenuUpdated;
        public List<string> MenuList { get; set; }
        public Menu()
        {
            MenuList = new List<string>();
        }

        public void Update()
        {
            // update menu 
        }

        public void Search(string key)
        {
            // search for keyword 
            Console.WriteLine("Menu: Search()-function called");
            MenuList.Clear(); 
            MenuList.Add("Boller I Karry");
            OnMenuUpdate();
            //OnMenuUpdate(new MenuEventArgs(this));
        }

        protected virtual void OnMenuUpdate()//MenuEventArgs e)
        {
            //EventHandler eventHandler = this.MenuUpdated;
            Console.WriteLine("Menu: RaiseMenuUpdatedEvent()-function called");
            //MenuUpdated(this, new MenuEventArgs(this));
            if (MenuUpdated == null )
            {
                MessageBox.Show("Eventhandler \"MenuUpdated\" is null!");
            }
            if (MenuUpdated != null)
            {
                MessageBox.Show("Eventhandler \"MenuUpdated\" is NOT null!");
            }
            //eventHandler?.Invoke(this, e);
            MenuUpdated?.Invoke(this, EventArgs.Empty); // , new MenuEventArgs(this)); 
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
