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
        private readonly Recipe recipe;
        private readonly Menu menu;
        private RecipeNavigatorPresenter recipeNavigatorPresenter;
        private ControlBarPresenter controlBarPresenter; 
        private MariaDBConnector dbConnection;
        public MainWindow()
        {
            this.shoppingList = new ShoppingList();
            this.menu = new Menu();
            this.recipe = new Recipe(); 
            InitializeComponent();

            dbConnection = new MariaDBConnector();

            //RecipeNavigator MVP
            recipeNavigatorPresenter = new RecipeNavigatorPresenter(this.recipeNavigatorView, this.menu, this.recipe, this.dbConnection);
            this.recipeNavigatorView.Setup(recipeNavigatorPresenter, this.recipe, this.menu);
            SubscribeToMenuEvents();

            //Controlbar MVP
            this.controlBarPresenter = new ControlBarPresenter(controlBarView, this.recipe, this.shoppingList);
            //controlBarView.Setup(shoppingList);


        }

        private void SubscribeToMenuEvents()
        {         
            this.menu.MenuUpdated += MenuUpdated;
        }

        private void MenuUpdated(object sender, MenuEventArgs e)
        {
            Console.WriteLine("Mainwindow: MenuUpdated()-function called");
            this.recipeNavigatorView.setListofRecipeItems(e.MenuList); 
        }

        private void recipeNavigatorView1_Load(object sender, EventArgs e)
        {

        }
    }
}
