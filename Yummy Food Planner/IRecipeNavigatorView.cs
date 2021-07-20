﻿using System;
using System.Collections.Generic;
using System.Text;
using Model; 

namespace Yummy_Food_Planner
{
    interface IRecipeNavigatorView
    {
        List<SimpleRecipe> ListOfRecipes { get; set; }
        event EventHandler RecipeSelected;
        event EventHandler SearchFieldChanged; 
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