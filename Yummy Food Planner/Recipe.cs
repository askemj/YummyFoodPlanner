using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Recipe : SimpleRecipe, IRecipe
    {
        public event EventHandler<EventArgs> RecipeUpdated;   
        //public bool ExistsInDatabase { get; set; }      
        public List<Ingredient> Ingredients { get; set; }

        public Recipe(string id, IDBConnection db) : base(id, db)
        {   
            // skab database fkt til ingredienser 
            //this.initiate(existsInDB, notes, ingredients, id, name, prepTime, totTime, nServings, recipeType, tags);
        }

        public Recipe(string recipeName)
        {
            //implementer database fkt.
            //derpå 
            //this.initiate(existsInDB, notes, ingredients, id, name, prepTime, totTime, nServings, recipeType, tags);
        }

        public Recipe(string notes, List<Ingredient> ingredients, int id, string name, int prepTime, int totTime, int nServings, string recipeType, List<string> tags) : base(id, notes, name, prepTime, totTime, nServings, recipeType, tags) // til oprettelse af ny db indgang
        {
            this.initiate(notes, ingredients, id, name, prepTime, totTime, nServings, recipeType, tags);
        }

        private void initiate(string notes, List<Ingredient> ingredients, int id, string name, int prepTime, int totTime, int nServings, string recipeType, List<string> tags)
        {
            //this.ExistsInDatabase = existsInDB;
            this.Ingredients = ingredients;
            base.initiate(id, name, notes, prepTime, totTime, nServings, recipeType, tags);
        }
    }
}
