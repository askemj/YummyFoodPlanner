using System;

namespace Model
{
    public class Ingredient
    {
        private int ID { get; set; }
        private float Quantity { get; set; }
        private string Unit { get; set; }
        private string Name { get; set; }
        private string Role { get; set; }
        private string SuperMarketSection { get; set; }
        private bool IsBasicItem { get; set; }
        public Ingredient(float quantity, string unit, string name, string role, string superMarketSection, bool isBasicItem)
        {
            this.ID = 0;
            this.Name = name;
            this.Unit = unit;
            this.Quantity = quantity;
            this.Role = role;
            this.SuperMarketSection = superMarketSection;
            this.IsBasicItem = isBasicItem;
        }

        // create constructoroverload for db-invocation of ingredient-object 
    }
}
