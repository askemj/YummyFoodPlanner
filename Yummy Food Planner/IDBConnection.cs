using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Model
{
    public interface IDBConnection
    {
        public DataTable GetRecipeInfo(string recipeID);
        public DataTable GetRecipeTags(string recipeID);
        public DataTable GetIngredients(string recipeID);

        public List<SimpleRecipe> GetMenu(string searchKey);
    }
}
