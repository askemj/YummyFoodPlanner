using System;
using System.Collections.Generic;
using System.Text;
using Model; 

namespace View
{
    public interface IRecipeNavigatorView
    {
        List<string> ListOfRecipes { get; set; }
        string SearchField { get;}

        string Name { get; set; }
        string Notes { get; set; }
        int PreparationTime { get; set; }
        int TotalTime { get; set; }
        int NumberOfServings { get; set; }
        string RecipeType { get; set; }
        List<string> Tags { get; set; }
        List<Ingredient> Ingredients { get; set; }

    }
}
