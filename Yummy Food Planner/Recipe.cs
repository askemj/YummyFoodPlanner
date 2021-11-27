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
            // måske jeg skal bruges til at kunne lave objekt hvorfra man kan abonnere på recipeUpdated events fra INDEN man updater sit objekt
        }

        public Recipe(string recipeName)
        {
            //implementer database fkt.
            //derpå 
            //this.initiate(existsInDB, notes, ingredients, id, name, prepTime, totTime, nServings, recipeType, tags);
        }

        new public void LoadFromDB(int recipeID, IDBConnection db) 
        {
            //// general recipe info 
            //DataTable dt = db.GetRecipeInfo(recipeID);
            //int recipeid = Convert.ToInt32(dt.Rows[0]["ret_id"]);
            //string recipeName = dt.Rows[0]["ret_navn"].ToString();
            //string notes = dt.Rows[0]["noter"].ToString();
            //int nServings = Convert.ToInt32(dt.Rows[0]["antal_portioner"]);
            //int prepTime = Convert.ToInt32(dt.Rows[0]["tilberedningstid_tid"]);
            //int totTime = Convert.ToInt32(dt.Rows[0]["arbejdstid_tid"]);
            //string recipeType = dt.Rows[0]["opskriftstype_tekst"].ToString();

            //// Tags 
            //DataTable dt_tags = db.GetRecipeTags(recipeID);
            //List<string> tagList = new List<string>();
            //for (int i = 0; i < dt_tags.Rows.Count; i++)
            //{
            //    tagList.Add(dt_tags.Rows[i]["tag_tekst"].ToString());
            //}

            base.LoadFromDB(recipeID, db);

            // Ingredients 
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
                Ingredient Ingredient = new Ingredient(id, quantity, unit, name, role, superMarketSection, isBasicItem);
                ingredientList.Add(Ingredient);
            }
        }

        public Recipe(string notes, List<Ingredient> ingredients, int id, string name, int prepTime, int totTime, int nServings, string recipeType, List<string> tags) : base(id, notes, name, prepTime, totTime, nServings, recipeType, tags) // til oprettelse af ny db indgang
        {
            this.initiate(ingredients, id, notes, name, prepTime, totTime, nServings, recipeType, tags);
        }

        private void initiate(List<Ingredient> ingredients, int id, string notes, string name, int prepTime, int totTime, int nServings, string recipeType, List<string> tags)
        {
            
            this.Ingredients = ingredients;
            base.initiate(id, name, notes, prepTime, totTime, nServings, recipeType, tags);
        }

        public override string ToString()
        {
            List<string> ingredientStringList = new List<string>(); 
            foreach (Ingredient item in Ingredients)
            {
                ingredientStringList.Add(item.ToString());
            }
            string ingredients = String.Join("\n", ingredientStringList);
            string recipeString = this.Name + "\n" + ingredients;
            return recipeString;
        }
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
