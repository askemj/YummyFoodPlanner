
namespace View
{
    partial class MealCustomiserView
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
            this.dgwIngredients = new System.Windows.Forms.DataGridView();
            this.btnAddToMealPlan = new System.Windows.Forms.Button();
            this.tbRecipeTitle = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgwIngredients)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwIngredients
            // 
            this.dgwIngredients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwIngredients.Location = new System.Drawing.Point(3, 42);
            this.dgwIngredients.Name = "dgwIngredients";
            this.dgwIngredients.RowTemplate.Height = 25;
            this.dgwIngredients.Size = new System.Drawing.Size(482, 314);
            this.dgwIngredients.TabIndex = 0;
            // 
            // btnAddToMealPlan
            // 
            this.btnAddToMealPlan.Location = new System.Drawing.Point(88, 372);
            this.btnAddToMealPlan.Name = "btnAddToMealPlan";
            this.btnAddToMealPlan.Size = new System.Drawing.Size(304, 23);
            this.btnAddToMealPlan.TabIndex = 1;
            this.btnAddToMealPlan.Text = "Add To Meal Plan";
            this.btnAddToMealPlan.UseVisualStyleBackColor = true;
            this.btnAddToMealPlan.Click += new System.EventHandler(this.btnAddToMealPlan_Click);
            // 
            // tbRecipeTitle
            // 
            this.tbRecipeTitle.Location = new System.Drawing.Point(3, 3);
            this.tbRecipeTitle.Name = "tbRecipeTitle";
            this.tbRecipeTitle.Size = new System.Drawing.Size(100, 23);
            this.tbRecipeTitle.TabIndex = 2;
            this.tbRecipeTitle.Text = "Recipe Title ...";
            // 
            // MealCustomiserView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbRecipeTitle);
            this.Controls.Add(this.btnAddToMealPlan);
            this.Controls.Add(this.dgwIngredients);
            this.Name = "MealCustomiserView";
            this.Size = new System.Drawing.Size(493, 415);
            this.Load += new System.EventHandler(this.MealCustomiserView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwIngredients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwIngredients;
        private System.Windows.Forms.Button btnAddToMealPlan;
        private System.Windows.Forms.TextBox tbRecipeTitle;
    }
}
