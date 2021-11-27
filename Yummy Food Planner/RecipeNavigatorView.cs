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
        public event EventHandler<RecipeViewEventArgs> RecipeSelectionChanged; 
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

        public void Setup(RecipeNavigatorPresenter _presenter, IRecipe _recipe, IMenu _menu)
        {
            this.presenter = _presenter;
            this.recipe = _recipe;
            this.Menu = _menu;
        }

        private List<string> getListofRecipeItems()
        {
            List<string> recipeItemsList = new List<string>();
            foreach (object item in this.lbMenu.Items)
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

        public void DisplayRecipe(IRecipe recipe)
        {
            tbRecipe.Text = "Recipe title: " + recipe.Name;  //_recipe.ToString();
            Console.WriteLine("TEST inside display recipe ");
        }


        private void tbSearchField_TextChanged(object sender, EventArgs e) // skriv mig om så der ikke er nogen som helst presenter-referencer, jeg er view og skal IKKE kende presenter !!!
        {
            Console.WriteLine("RecipeNavigatorView: tbSearchfield_TextChanged()-called");

            presenter.SearchForRecipe();
        }

        private void lbMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lbMenu.SelectedItem != null)
            {
                string recipeTitle = lbMenu.SelectedItem.ToString();
                SimpleRecipe recipe = this.Menu.MenuList.Find(item => item.Name == recipeTitle);
                if (recipe != null)
                {
                    RecipeSelectionChanged(this, new RecipeViewEventArgs(recipe));
                }
                else
                {
                    MessageBox.Show("ERROR recipe not found...");
                }
            }
        }
    }

    public class RecipeViewEventArgs : EventArgs
    {
        public SimpleRecipe Recipe { get; set; }

        public RecipeViewEventArgs(SimpleRecipe _recipe)
        {
            this.Recipe = _recipe;
        }
    }
}
