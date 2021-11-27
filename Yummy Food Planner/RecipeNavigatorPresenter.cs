using System;
using System.Collections.Generic;
using Model;
using View; 

namespace Presenter
{
    public class RecipeNavigatorPresenter
    {
        private readonly IRecipeNavigatorView view;
        private readonly IRecipe recipe;
        private IMenu menu;
        private IDBConnection dbConnection;

        public RecipeNavigatorPresenter(IRecipeNavigatorView _view, IMenu _menu, IRecipe _recipe, IDBConnection dbCon)
        {
            this.view = _view;
            this.menu = _menu;
            this.recipe = new Recipe();
            this.dbConnection = dbCon;
            SubscribeToEvents(); 
        }

        private void SubscribeToEvents()
        {
            // from view
            this.view.RecipeSelectionChanged += OnRecipeViewSelectionChange;

            //from model 
            this.recipe.RecipeUpdated += OnRecipeUpdate;
        }

        private void OnRecipeViewSelectionChange(object sender, RecipeViewEventArgs e)
        {
            this.recipe.LoadFromDB(e.Recipe.ID, dbConnection);
        }

        private void OnRecipeUpdate(object sender, RecipeEventArgs e)
        {
            view.DisplayRecipe(this.recipe);
        }

        public void SearchForRecipe()
        {
            Console.WriteLine("RecipeNavigatorPresenter: SearchForRecipe()-function called");
            string key = this.view.SearchField;
            Console.WriteLine("... with key " + key);
            menu.Search(key, dbConnection);
        }

        public void FindRecipe(int id)
        {

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
            Recipe recipe = new Recipe();
            //menu.MenuList.Find(recipeName); 
            //menu.MenuList.Find(i => i.RecipeName == recipeName);
            return recipe;
        }
    }
}
