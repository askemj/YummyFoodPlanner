using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Model
{
    public class Recipe : SimpleRecipe, IRecipe
    {
        public event EventHandler<RecipeEventArgs> RecipeUpdated;     
        public List<Ingredient> Ingredients { get; set; }

        public Recipe()
        {
            Ingredients = new List<Ingredient>();
        }

        public Recipe(string notes, List<Ingredient> ingredients, int id, string name, int prepTime, int totTime, int nServings, string recipeType, List<string> tags) : base(id, notes, name, prepTime, totTime, nServings, recipeType, tags) // til oprettelse af ny db indgang
        {
            // OBS denne constructor bruger vel parentconstructor og skal derfor ikke have en initiate med base.reference!! det er dobbeltkonfekt 
            this.initiate(ingredients, id, notes, name, prepTime, totTime, nServings, recipeType, tags);
            RaiseRecipeUpdateEvent();
        }

        new public void LoadFromDB(int recipeID, IDBConnection db) 
        {
            base.LoadFromDB(recipeID, db);

            // Add Ingredients 
            DataTable dT_ingredients = db.GetIngredients(recipeID);
            List<Ingredient> ingredientList = new List<Ingredient>();
            for (int i = 0; i < dT_ingredients.Rows.Count; i++)
            {
                int id = Convert.ToInt32(dT_ingredients.Rows[i]["ID"]);
                float quantity = float.Parse(dT_ingredients.Rows[i]["Quantity"].ToString());
                string unit = dT_ingredients.Rows[i]["Unit"].ToString();
                string name = dT_ingredients.Rows[i]["Name"].ToString();
                string role = dT_ingredients.Rows[i]["Role"].ToString();
                string superMarketSection = dT_ingredients.Rows[i]["SuperMarketSection"].ToString();
                bool isBasicItem = Convert.ToBoolean(dT_ingredients.Rows[i]["IsBasicItem"]);
                Ingredient ingredient = new Ingredient(id, quantity, unit, name, role, superMarketSection, isBasicItem);
                ingredientList.Add(ingredient);
            }
            Ingredients.AddRange(ingredientList);
            RaiseRecipeUpdateEvent(); 
        }

        private void initiate(List<Ingredient> ingredients, int id, string notes, string name, int prepTime, int totTime, int nServings, string recipeType, List<string> tags)
        {
            this.Ingredients = ingredients;
            base.initiate(id, name, notes, prepTime, totTime, nServings, recipeType, tags);
        }

        private void RaiseRecipeUpdateEvent()
        {
            RecipeUpdated(this, new RecipeEventArgs(this));
        }

        //public override string ToString()
        //{
        //    //List<string> ingredientStringList = new List<string>();
        //    //string ingredients = ""; 
        //    //if (Ingredients != null)
        //    //{
        //    //    foreach (Ingredient item in Ingredients)
        //    //    {
        //    //        ingredientStringList.Add(item.ToString());
        //    //    }
        //    //    ingredients = String.Join("\n", ingredientStringList);
        //    //}
        //    //string recipeString = this.Name + "\n" + ingredients + "\n hej hej "; 
        //    return "Name: " + this.Name;
        //}
    }

    public class RecipeEventArgs : EventArgs
    {
        public Recipe recipe { get; set; }
        public RecipeEventArgs(Recipe _recipe)
        {
            this.recipe = _recipe;
        }
    }
}
