using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Model
{
    public class ShoppingList : IShoppingList
    {
        public List<Recipe> ListOfRecipes { get; set;}

        public ShoppingList()
        {
            ListOfRecipes = new List<Recipe>();
        }

        public List<Ingredient> GetReducedListOfGroceries()
        {
            List<Ingredient> recipeList = new List<Ingredient>();
            return recipeList;
        }

        public void AddToList(Recipe recipe)
        {
            this.ListOfRecipes.Add(recipe);
        }
        public void DisplayShoppingList()
        {
            MessageBox.Show("...not yet implemented...");
        }

    }

    public class ShoppingListEventArgs : EventArgs
    {
        public ShoppingList ShoppingList { get; set; } 
        public ShoppingListEventArgs(ShoppingList shoppingList)
        {
            this.ShoppingList = shoppingList;
        }
    }
}
