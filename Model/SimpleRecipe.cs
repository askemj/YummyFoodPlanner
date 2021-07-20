using System;
using System.Collections.Generic;
using System.Text;

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

        public SimpleRecipe(int id)
        {
            //kald til db funktion
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
