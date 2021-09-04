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
            this.tbRecipe.Location = new System.Drawing.Point(185, 22);
            this.tbRecipe.Multiline = true;
            this.tbRecipe.Name = "tbRecipe";
            this.tbRecipe.Size = new System.Drawing.Size(182, 165);
            this.tbRecipe.TabIndex = 1;
            // 
            // tbSearchField
            // 
            this.tbSearchField.Location = new System.Drawing.Point(12, 160);
            this.tbSearchField.Name = "tbSearchField";
            this.tbSearchField.Size = new System.Drawing.Size(151, 27);
            this.tbSearchField.TabIndex = 2;
            this.tbSearchField.TextChanged += new System.EventHandler(this.tbSearchField_TextChanged);
            // 
            // lbMenu
            // 
            this.lbMenu.FormattingEnabled = true;
            this.lbMenu.ItemHeight = 20;
            this.lbMenu.Location = new System.Drawing.Point(13, 22);
            this.lbMenu.Name = "lbMenu";
            this.lbMenu.Size = new System.Drawing.Size(150, 124);
            this.lbMenu.TabIndex = 3;
            // 
            // RecipeNavigatorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbMenu);
            this.Controls.Add(this.tbSearchField);
            this.Controls.Add(this.tbRecipe);
            this.Name = "RecipeNavigatorView";
            this.Size = new System.Drawing.Size(383, 214);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbRecipe;
        private System.Windows.Forms.TextBox tbSearchField;
        private System.Windows.Forms.ListBox lbMenu;
    }
}
