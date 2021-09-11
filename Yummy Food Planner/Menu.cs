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

        public void Search(string key, IDBConnection db)
        {
            // search for keyword 
            Console.WriteLine("Menu: Search()-function called");
            
            MenuList.Clear();
            MenuList.AddRange(db.GetMenu(key)); 
            OnMenuUpdate();
            //OnMenuUpdate(new MenuEventArgs(this)); 
        }

        protected virtual void OnMenuUpdate()//MenuEventArgs e)
        {
            Console.WriteLine("Menu: RaiseMenuUpdatedEvent()-function called");
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
