using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public interface IShoppingList
    {
        List<Recipe> ListOfRecipes { get; set; }
        List<Ingredient> GetReducedListOfGroceries();
        void AddToList(Recipe recipe);
        void DisplayShoppingList();

    }
}
