using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presenter
{
    public interface IControlBarPresenter
    {
        public event EventHandler<RecipeEventArgs> RecipeToMealRequested;
    }
}
