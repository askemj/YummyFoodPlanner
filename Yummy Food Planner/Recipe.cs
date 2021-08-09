using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Recipe : SimpleRecipe, IRecipe
    {
        public event EventHandler<EventArgs> RecipeUpdated;   
        public bool ExistsInDatabase { get; set; }
        public string Notes { get; set; }
        public List<Ingredient> Ingredients { get; set; }

        public Recipe(int id) 
        {
            //implementer database fkt.
            //derpå 
            //this.initiate(existsInDB, notes, ingredients, id, name, prepTime, totTime, nServings, recipeType, tags);
        }

        public Recipe(bool existsInDB, string notes, List<Ingredient> ingredients, int id, string name, int prepTime, int totTime, int nServings, string recipeType, List<string> tags) : base(id, name, prepTime, totTime, nServings, recipeType, tags) // til oprettelse af ny db indgang
        {
            this.initiate(existsInDB, notes, ingredients, id, name, prepTime, totTime, nServings, recipeType, tags);
        }

        public void initiate(bool existsInDB, string notes, List<Ingredient> ingredients, int id, string name, int prepTime, int totTime, int nServings, string recipeType, List<string> tags)
        {
            this.ExistsInDatabase = existsInDB;
            this.Notes = notes;
            this.Ingredients = ingredients;
            base.initiate(id, name, prepTime, totTime, nServings, recipeType, tags);
        }
    }
}
