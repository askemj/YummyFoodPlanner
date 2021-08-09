using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Presenter;

namespace View
{
    public partial class MainWindow : Form
    {
        private readonly ShoppingList shoppingList;
        private RecipeNavigatorPresenter recipeNavigatorPresenter; 
        public MainWindow()
        {
            this.shoppingList = new ShoppingList();
            InitializeComponent();
        }

        private void recipeNavigatorView1_Load(object sender, EventArgs e)
        {

        }
    }
}
