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

        public RecipeNavigatorPresenter(IRecipeNavigatorView _view, IMenu _menu)
        {
            this.view = _view;
            this.menu = _menu;
            this.recipe = null;
        }
        public void PickRecipe()
        {

        }

        public void SearchForRecipe(string key)
        {
            menu.Search(key);
        }
    }
}
