namespace View
{
    partial class RecipeNavigatorView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbRecipe = new System.Windows.Forms.TextBox();
            this.tbSearchField = new System.Windows.Forms.TextBox();
            this.lbMenu = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // tbRecipe
            // 
            this.tbRecipe.Location = new System.Drawing.Point(162, 16);
            this.tbRecipe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbRecipe.Multiline = true;
            this.tbRecipe.Name = "tbRecipe";
            this.tbRecipe.Size = new System.Drawing.Size(160, 125);
            this.tbRecipe.TabIndex = 1;
            // 
            // tbSearchField
            // 
            this.tbSearchField.Location = new System.Drawing.Point(10, 120);
            this.tbSearchField.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSearchField.Name = "tbSearchField";
            this.tbSearchField.Size = new System.Drawing.Size(133, 23);
            this.tbSearchField.TabIndex = 2;
            this.tbSearchField.TextChanged += new System.EventHandler(this.tbSearchField_TextChanged);
            // 
            // lbMenu
            // 
            this.lbMenu.FormattingEnabled = true;
            this.lbMenu.ItemHeight = 15;
            this.lbMenu.Location = new System.Drawing.Point(11, 16);
            this.lbMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbMenu.Name = "lbMenu";
            this.lbMenu.Size = new System.Drawing.Size(132, 94);
            this.lbMenu.TabIndex = 3;
            this.lbMenu.SelectedIndexChanged += new System.EventHandler(this.lbMenu_SelectedIndexChanged);
            // 
            // RecipeNavigatorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbMenu);
            this.Controls.Add(this.tbSearchField);
            this.Controls.Add(this.tbRecipe);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RecipeNavigatorView";
            this.Size = new System.Drawing.Size(335, 160);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbRecipe;
        private System.Windows.Forms.TextBox tbSearchField;
        private System.Windows.Forms.ListBox lbMenu;
    }
}
