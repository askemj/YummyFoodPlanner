using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Model; 

namespace View
{
    public partial class MealCustomiserView : UserControl, IMealCustomiserView
    {
        public MealCustomiserView()
        {
            InitializeComponent();
        }

        private void btnAddToMealPlan_Click(object sender, EventArgs e)
        {

        }

        public void LoadRecipe(IRecipe recipe)
        {
            if(recipe != null)
            {
                this.tbRecipeTitle.Text = recipe.Name;
            }
        }

        private void MealCustomiserView_Load(object sender, EventArgs e)
        {

        }
    }
}
