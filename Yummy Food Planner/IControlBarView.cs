using System;
using System.Collections.Generic;
using System.Text;
using View;
using Model;
using Presenter; 

namespace View
{
    public interface IControlBarView
    {
        public event EventHandler<EventArgs> AddToMealPlanClicked;
        public event EventHandler<ShoppingListEventArgs> ShowShoppingListClicked;
        public event EventHandler<RecipeEventArgs> AddRecipeClicked;
        public event EventHandler<RecipeEventArgs> EditRecipeClicked;
    }
}
