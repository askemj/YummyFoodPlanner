using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Presenter;

namespace View
{
    public partial class ControlBarView : UserControl, IControlBarView
    {
        public event EventHandler<EventArgs> AddToMealPlanClicked;
        public event EventHandler<ShoppingListEventArgs> ShowShoppingListClicked;
        public event EventHandler<RecipeEventArgs> AddRecipeClicked;
        public event EventHandler<RecipeEventArgs> EditRecipeClicked;
        private IMealCustomiserPresenter mealCustomiserPresenter; 
        //private ShoppingList shoppingList { get; set;  }
        public ControlBarView()
        {
            InitializeComponent();
        }

        public void Setup(IMealCustomiserPresenter _mealCustomiserPresenter)//ShoppingList _shoppingList)
        {
            mealCustomiserPresenter = _mealCustomiserPresenter;
            //this.shoppingList = _shoppingList;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnEditRecipe_Click(object sender, EventArgs e)
        {

        }

        private void btnAddToMealPlan_Click(object sender, EventArgs e)
        {
            AddToMealPlanClicked(this, EventArgs.Empty);   
        }
    }
}
