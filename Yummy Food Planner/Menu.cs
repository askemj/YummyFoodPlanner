using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Model
{
    public class Menu : IMenu
    {
        public event EventHandler<MenuEventArgs> MenuUpdated;
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
            
            //MenuList.Clear();
            MenuList.AddRange(db.GetMenu(key)); 
            OnMenuUpdate();
            //OnMenuUpdate(new MenuEventArgs(this)); 
        }

        protected virtual void OnMenuUpdate()//MenuEventArgs e)
        {
            Console.WriteLine("Menu: RaiseMenuUpdatedEvent()-function called");
            List<string> list = new List<string>();
            list.AddRange(this.MenuList);
            MenuEventArgs menuEventArgs = new MenuEventArgs(this, list);
            MenuUpdated?.Invoke(this, menuEventArgs);//EventArgs.Empty); // , new MenuEventArgs(this)); 
        }
    } 

    public class MenuEventArgs : EventArgs
    {
        public Menu menu { get; set;}  
        public List<string> MenuList { get; set;}
        public MenuEventArgs(Menu _menu, List<string> _menuList)
        {
            this.menu = _menu;
            this.MenuList = _menuList;
        }
    }
}
