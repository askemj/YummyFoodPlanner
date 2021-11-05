using System;
using System.Collections.Generic;
using Model;
using View; 

namespace Presenter
{
    public class RecipeNavigatorPresenter
    {
        private readonly IRecipeNavigatorView view;
        private IRecipe recipe;
        private IMenu menu;
        private IDBConnection dbConnection;

        public RecipeNavigatorPresenter(IRecipeNavigatorView _view, IMenu _menu, IDBConnection dbCon)
        {
            this.view = _view;
            this.menu = _menu;
            this.recipe = null;
            this.dbConnection = dbCon;
        }
        public void PickRecipe()
        {

        }


        public void SearchForRecipe()
        {
            Console.WriteLine("RecipeNavigatorPresenter: SearchForRecipe()-function called");
            string key = this.view.SearchField;
            Console.WriteLine("... with key " + key);
            menu.Search(key, dbConnection);
        }

        public void DisplayRecipe(string recipeName)
        {
            // display recipe 
            //find recipe i menu 
            // når vi skifter til ægte recipes i menu så brug RecipeSelector()
            //generer displaytekst
            //set displaytekst
        }

        private Recipe RecipeSelector(string recipeName)
        {
            Recipe recipe = new Recipe("1");
            //menu.MenuList.Find(recipeName); 
            //menu.MenuList.Find(i => i.RecipeName == recipeName);
            return recipe;
        }
    }
}
