using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Menu : IMenu
    {
        public event EventHandler<EventArgs> MenuUpdated;
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
            MenuUpdated?.Invoke(this, new EventArgs());
        }
    }
}
