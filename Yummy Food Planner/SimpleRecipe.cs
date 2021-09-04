using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Model
{
    public class SimpleRecipe
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int PreparationTime { get; set; }
        public int TotalTime { get; set; }
        public int NumberOfServings { get; set; }
        public string RecipeType { get; set; }
        public List<string> Tags { get; set; }

        public SimpleRecipe(int id, string name, int prepTime, int totTime, int nServings, string recipeType, List<string> tags)
        {
            this.initiate(id, name, prepTime, totTime, nServings, recipeType, tags);
        }

        public SimpleRecipe(string id, IDBConnection db)
        {
            DataTable dt = db.GetRecipeInfo(id);
            //"ID", "Notes", "Number of Servings", "Preparation Time", "Total Time", "Recipe Type" })) {
            int recipeid = Convert.ToInt32(dt.Rows[0]["ID"]);
            string name = dt.Rows[0]["Name"].ToString();
            string notes = dt.Rows[0]["Notes"].ToString();
            int nServings = Convert.ToInt32(dt.Rows[0]["Number of Servings"]);
            int prepTime = Convert.ToInt32(dt.Rows[0]["Preparation Time"]);
            int totTime = Convert.ToInt32(dt.Rows[0]["Total Time"]);
            string recipeType = dt.Rows[0]["Recipe Type"].ToString();

            DataTable dt_tags = db.GetRecipeTags(id);
            List<string> tagList = new List<string>();
            for (int i = 0; i < dt_tags.Rows.Count; i++)
            {
                tagList.Add(dt_tags.Rows[i]["Tags"].ToString());
            }

            this.initiate(recipeid, name, prepTime, totTime, nServings, recipeType, tagList);
            return;
        }

        public SimpleRecipe()
        {
        }

        public void initiate(int id, string name, int prepTime, int totTime, int nServings, string recipeType, List<string> tags)
        {
            this.ID = id;
            this.Name = name;
            this.PreparationTime = prepTime;
            this.TotalTime = totTime;
            this.NumberOfServings = nServings;
            this.RecipeType = recipeType;
            this.Tags = tags;
        }
    }
}
