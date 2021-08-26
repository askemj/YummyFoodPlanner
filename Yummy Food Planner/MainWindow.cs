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
        public MainWindow()
        {
            this.shoppingList = new ShoppingList();
            this.menu = new Menu();
            this.recipe = null;
            InitializeComponent();
            recipeNavigatorPresenter = new RecipeNavigatorPresenter(this.recipeNavigatorView1, this.menu);
            this.recipeNavigatorView1.Setup(recipeNavigatorPresenter, this.recipe, this.menu);
            MariaDBConnector.SetupConnection(); 
            SubscribeToMenuEvents();
        }

        private void SubscribeToMenuEvents()
        {
            //this.menu.MenuUpdated += MenuUpdated;            
            this.menu.MenuUpdated += MenuUpdated;
        }

        private void MenuUpdated(object sender, EventArgs e)//, MenuEventArgs e)
        {
            Console.WriteLine("Mainwindow: MenuUpdated()-function called");
            //this.recipeNavigatorView1.Menu.MenuList = e.menu.MenuList;
            //this.recipeNavigatorView1.Menu.MenuList.AddRange(e.menu.MenuList);
            foreach (string recipe in menu.MenuList)
            {
                this.recipeNavigatorView1.Menu.MenuList.Add(recipe);
            }
            //Console.WriteLine(e.menu.MenuList.ToString());
            
        }

        private void recipeNavigatorView1_Load(object sender, EventArgs e)
        {

        }
    }
}
