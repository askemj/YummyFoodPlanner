using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Model
{
    public interface IDBConnection
    {
        public DataTable GetRecipeInfo(int recipeID);
        public DataTable GetRecipeTags(int recipeID);
        public DataTable GetIngredients(int recipeID);

        public List<SimpleRecipe> GetMenu(string searchKey);
    }
}
