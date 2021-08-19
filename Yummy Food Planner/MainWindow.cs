﻿using System;
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
            recipeNavigatorPresenter = new RecipeNavigatorPresenter(this.recipeNavigatorView1, menu);
            this.recipeNavigatorView1.Setup(recipeNavigatorPresenter, recipe, menu);
            MariaDBConnector.SetupConnection();

        }

        public void SubscribeToMenuEvents()
        {
            this.menu.MenuUpdated += MenuUpdated;
        }

        public void MenuUpdated(object sender, MenuEventArgs e)
        {
            this.recipeNavigatorView1.Menu.MenuList = e.menu.MenuList;
        }

        private void recipeNavigatorView1_Load(object sender, EventArgs e)
        {

        }
    }
}
