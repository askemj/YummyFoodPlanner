
namespace View
{
    partial class ControlBarView
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
            this.btnAddToMealPlan = new System.Windows.Forms.Button();
            this.btnShowShoppingList = new System.Windows.Forms.Button();
            this.btnNewRecipe = new System.Windows.Forms.Button();
            this.btnEditRecipe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddToMealPlan
            // 
            this.btnAddToMealPlan.Location = new System.Drawing.Point(15, 14);
            this.btnAddToMealPlan.Name = "btnAddToMealPlan";
            this.btnAddToMealPlan.Size = new System.Drawing.Size(126, 23);
            this.btnAddToMealPlan.TabIndex = 0;
            this.btnAddToMealPlan.Text = "Add To Meal Plan";
            this.btnAddToMealPlan.UseVisualStyleBackColor = true;
            this.btnAddToMealPlan.Click += new System.EventHandler(this.btnAddToMealPlan_Click);
            // 
            // btnShowShoppingList
            // 
            this.btnShowShoppingList.Location = new System.Drawing.Point(147, 14);
            this.btnShowShoppingList.Name = "btnShowShoppingList";
            this.btnShowShoppingList.Size = new System.Drawing.Size(125, 23);
            this.btnShowShoppingList.TabIndex = 1;
            this.btnShowShoppingList.Text = "Show Shopping List";
            this.btnShowShoppingList.UseVisualStyleBackColor = true;
            this.btnShowShoppingList.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnNewRecipe
            // 
            this.btnNewRecipe.Location = new System.Drawing.Point(278, 14);
            this.btnNewRecipe.Name = "btnNewRecipe";
            this.btnNewRecipe.Size = new System.Drawing.Size(104, 23);
            this.btnNewRecipe.TabIndex = 2;
            this.btnNewRecipe.Text = "New Recipe";
            this.btnNewRecipe.UseVisualStyleBackColor = true;
            // 
            // btnEditRecipe
            // 
            this.btnEditRecipe.Location = new System.Drawing.Point(388, 14);
            this.btnEditRecipe.Name = "btnEditRecipe";
            this.btnEditRecipe.Size = new System.Drawing.Size(104, 23);
            this.btnEditRecipe.TabIndex = 3;
            this.btnEditRecipe.Text = "Edit Recipe";
            this.btnEditRecipe.UseVisualStyleBackColor = true;
            this.btnEditRecipe.Click += new System.EventHandler(this.btnEditRecipe_Click);
            // 
            // ControlBarView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnEditRecipe);
            this.Controls.Add(this.btnNewRecipe);
            this.Controls.Add(this.btnShowShoppingList);
            this.Controls.Add(this.btnAddToMealPlan);
            this.Name = "ControlBarView";
            this.Size = new System.Drawing.Size(516, 54);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddToMealPlan;
        private System.Windows.Forms.Button btnShowShoppingList;
        private System.Windows.Forms.Button btnNewRecipe;
        private System.Windows.Forms.Button btnEditRecipe;
    }
}
