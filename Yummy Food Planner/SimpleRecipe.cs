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
        public string Notes { get; set; }
        public int PreparationTime { get; set; }
        public int TotalTime { get; set; }
        public int NumberOfServings { get; set; }
        public string RecipeType { get; set; }
        public List<string> Tags { get; set; }

        public SimpleRecipe(int id, string name, string notes, int prepTime, int totTime, int nServings, string recipeType, List<string> tags)
        {
            this.initiate(id, name, notes, prepTime, totTime, nServings, recipeType, tags);
        }

        public SimpleRecipe(int id, IDBConnection db)
        {
            DataTable dt = db.GetRecipeInfo(id);

            int recipeid = Convert.ToInt32(dt.Rows[0]["ret_id"]);
            string name = dt.Rows[0]["ret_navn"].ToString();
            string notes = dt.Rows[0]["noter"].ToString();
            int nServings = Convert.ToInt32(dt.Rows[0]["antal_portioner"]);
            int prepTime = Convert.ToInt32(dt.Rows[0]["tilberedningstid_tid"]);
            int totTime = Convert.ToInt32(dt.Rows[0]["arbejdstid_tid"]);
            string recipeType = dt.Rows[0]["opskriftstype_tekst"].ToString();

            DataTable dt_tags = db.GetRecipeTags(id);
            List<string> tagList = new List<string>();
            for (int i = 0; i < dt_tags.Rows.Count; i++)
            {
                tagList.Add(dt_tags.Rows[i]["tag_tekst"].ToString());
            }

            this.initiate(recipeid, name, notes, prepTime, totTime, nServings, recipeType, tagList);
            return;
        }

        public SimpleRecipe()
        {
        }

        public void initiate(int id, string name, string notes, int prepTime, int totTime, int nServings, string recipeType, List<string> tags)
        {
            this.ID = id;
            this.Name = name;
            this.Notes = Notes;
            this.PreparationTime = prepTime;
            this.TotalTime = totTime;
            this.NumberOfServings = nServings;
            this.RecipeType = recipeType;
            this.Tags = tags;
        }
    }
}
