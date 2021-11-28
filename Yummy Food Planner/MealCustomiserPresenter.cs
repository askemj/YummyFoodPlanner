using System;
using System.Collections.Generic;
using System.Text;
using Model;
using View;

namespace Presenter
{
    class MealCustomiserPresenter // : IMealCustomiserPresenter
    {
        private IShoppingList shoppingList { get; set; }
        private IRecipe recipe { get; set; }
        private IControlBarPresenter controlBarPresenter { get; set; }
        private IMealCustomiserView view { get; set; }

        public MealCustomiserPresenter(IMealCustomiserView _view, IControlBarPresenter _controlBarPresenter, IShoppingList _shoppingList)
        {
            this.view = _view;
            this.shoppingList = _shoppingList;
            this.controlBarPresenter = _controlBarPresenter;
            SubscribeToEvents(); 
        }

        public void SubscribeToEvents()
        {
            controlBarPresenter.RecipeToMealRequested += OnRecipeToMealRequested; 
        }

        public void CustomiseMeal(Recipe recipe)
        {

        }

        public void OnRecipeToMealRequested(object sender, RecipeEventArgs e)
        {
            LoadRecipe(e.recipe);
        }

        private void LoadRecipe(IRecipe recipe)
        {
            if (recipe != null)
            {
                this.view.LoadRecipe(this.recipe);
            }
        }
    }
}
