using Model;
using System;
using System.Collections.Generic;
using System.Text;
using View;
using System.Windows.Forms;

namespace Presenter
{
    class ControlBarPresenter : IControlBarPresenter
    {
        IControlBarView view;
        IRecipe recipe;
        IShoppingList shoppingList;
        public event EventHandler<RecipeEventArgs> RecipeToMealRequested; 
        //IMealCustomiserPresenter mealCustomiserPresenter;
        public ControlBarPresenter(IControlBarView _view, IRecipe _recipe, IShoppingList _shoppingList)
        {
            this.view = _view;
            this.recipe = _recipe;
            this.shoppingList = _shoppingList;
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            this.view.AddToMealPlanClicked += OnAddToMealPlanClicked; 
        }

        private void OnAddToMealPlanClicked(object sender, EventArgs e)
        {
            if (this.recipe.Name != null)
            {
                RecipeToMealRequested(this, new RecipeEventArgs(this.recipe));
            }
            else
            {
                MessageBox.Show("No recipe is selected ...");
            }            
        }
    }
}
