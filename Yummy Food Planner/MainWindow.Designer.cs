namespace View
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.recipeNavigatorView = new View.RecipeNavigatorView();
            this.SuspendLayout();
            // 
            // recipeNavigatorView
            // 
            this.recipeNavigatorView.Ingredients = null;
            this.recipeNavigatorView.ListOfRecipes = ((System.Collections.Generic.List<string>)(resources.GetObject("recipeNavigatorView.ListOfRecipes")));
            this.recipeNavigatorView.Location = new System.Drawing.Point(221, 163);
            this.recipeNavigatorView.Name = "recipeNavigatorView";
            this.recipeNavigatorView.Notes = null;
            this.recipeNavigatorView.NumberOfServings = 0;
            this.recipeNavigatorView.PreparationTime = 0;
            this.recipeNavigatorView.RecipeType = null;
            this.recipeNavigatorView.Size = new System.Drawing.Size(479, 268);
            this.recipeNavigatorView.TabIndex = 0;
            this.recipeNavigatorView.Tags = null;
            this.recipeNavigatorView.TotalTime = 0;
            this.recipeNavigatorView.Load += new System.EventHandler(this.recipeNavigatorView1_Load);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 573);
            this.Controls.Add(this.recipeNavigatorView);
            this.Name = "MainWindow";
            this.Text = "Yummy Food Planner";
            this.ResumeLayout(false);

        }

        #endregion

        private View.RecipeNavigatorView recipeNavigatorView;
    }
}

