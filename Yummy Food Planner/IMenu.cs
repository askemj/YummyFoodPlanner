using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public interface IMenu
    {
        public List<SimpleRecipe> MenuList { get; set; }

        public void Update();
        public void Search(string key, IDBConnection dbConnection);

    }
}
