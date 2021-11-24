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
        public List<string> ListOfRecipes { get; set; } // get { return getListofRecipeItems()}; set; }
        public string SearchField { get { return tbSearchField.Text; } }
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

        private List<string> getListofRecipeItems()
        {
            List<string> recipeItemsList = new List<string>();
            foreach(object item in this.lbMenu.Items)
            {
                recipeItemsList.Add(item.ToString()); //new SimpleRecipe(0, item.ToString(), "", 0, 1, 2, "", new List<string>() { }) );
            }
            return recipeItemsList;
        }

        public void setListofRecipeItems(List<SimpleRecipe> recipes)
        {
            if (recipes != null)
            {
                if (this.lbMenu.Items.Count > 0)
                {
                    this.lbMenu.Items.Clear();
                }
                foreach (SimpleRecipe recipe in recipes)
                {
                    this.lbMenu.Items.Add(recipe.Name);
                }
            }
        }

        public void Setup(RecipeNavigatorPresenter _presenter, IRecipe _recipe, IMenu _menu)
        {
            this.presenter = _presenter; 
            this.recipe = _recipe;
            this.Menu = _menu;
        }

        private void tbSearchField_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("RecipeNavigaorView: tbSearchfield_TextChanged()-called");
            
            presenter.SearchForRecipe(); 
        }

        private void lvMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbMenu.SelectedItem != null)
            {
                //presenter.DisplayRecipe(lbMenu.SelectedItem);
            }
        }
    }
}
