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
            this.recipeNavigatorView1 = new View.RecipeNavigatorView();
            this.SuspendLayout();
            // 
            // recipeNavigatorView1
            // 
            this.recipeNavigatorView1.Ingredients = null;
            this.recipeNavigatorView1.ListOfRecipes = null;
            this.recipeNavigatorView1.Location = new System.Drawing.Point(221, 163);
            this.recipeNavigatorView1.Name = "recipeNavigatorView1";
            this.recipeNavigatorView1.Notes = null;
            this.recipeNavigatorView1.NumberOfServings = 0;
            this.recipeNavigatorView1.PreparationTime = 0;
            this.recipeNavigatorView1.RecipeType = null;
            this.recipeNavigatorView1.Size = new System.Drawing.Size(479, 268);
            this.recipeNavigatorView1.TabIndex = 0;
            this.recipeNavigatorView1.Tags = null;
            this.recipeNavigatorView1.TotalTime = 0;
            this.recipeNavigatorView1.Load += new System.EventHandler(this.recipeNavigatorView1_Load);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 573);
            this.Controls.Add(this.recipeNavigatorView1);
            this.Name = "MainWindow";
            this.Text = "Yummy Food Planner";
            this.ResumeLayout(false);

        }

        #endregion

        private View.RecipeNavigatorView recipeNavigatorView1;
    }
}

