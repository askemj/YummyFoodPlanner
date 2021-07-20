using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public interface IRecipe
    {
        int ID { get; set; }
        // bool ExistsInDatabase { get; set; } ... vil ikke blive vist 
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
