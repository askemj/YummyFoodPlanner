using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Model;
using Presenter;

namespace View
{
    public partial class RecipeNavigatorView : UserControl, IRecipeNavigatorView
    {
        private RecipeNavigatorPresenter presenter;
        private IRecipe recipe;
        public IMenu Menu;
        public List<SimpleRecipe> ListOfRecipes { get; set; }
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

        public void Setup(RecipeNavigatorPresenter _presenter, IRecipe _recipe, IMenu _menu)
        {
            this.presenter = _presenter; 
            this.recipe = _recipe;
            this.Menu = _menu;
        }

        private void tbSearchField_TextChanged(object sender, EventArgs e)
        {
            presenter.SearchForRecipe(e.ToString());
        }
    }
}
