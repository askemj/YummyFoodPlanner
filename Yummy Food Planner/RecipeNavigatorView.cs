using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Model; 

namespace Yummy_Food_Planner
{
    public partial class RecipeNavigatorView : UserControl, IRecipeNavigatorView
    {
        public List<SimpleRecipe> ListOfRecipes { get; set; }
        public event EventHandler RecipeSelected;
        public event EventHandler SearchFieldChanged;
        public string Name { get; set; }
        public string Notes { get; set; }
        public int PreparationTime { get; set; }
        public int TotalTime { get; set; }
        public int NumberOfServings { get; set; }
        public string RecipeType { get; set; }
        public List<string> Tags { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public RecipeNavigatorView()
        {
            InitializeComponent();
        }
    }
}
