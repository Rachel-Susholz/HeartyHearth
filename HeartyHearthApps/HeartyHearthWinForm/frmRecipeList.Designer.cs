namespace HeartyHearthWinForm
{
    partial class frmRecipeList
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            tblMain = new TableLayoutPanel();
            btnNewRecipe = new Button();
            gRecipeList = new DataGridView();
            colRecipeName = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colUser = new DataGridViewTextBoxColumn();
            colCalories = new DataGridViewTextBoxColumn();
            colIngredients = new DataGridViewTextBoxColumn();
            tblMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gRecipeList).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(btnNewRecipe, 0, 0);
            tblMain.Controls.Add(gRecipeList, 0, 1);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 2;
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblMain.Size = new Size(800, 450);
            tblMain.TabIndex = 0;
            // 
            // btnNewRecipe
            // 
            btnNewRecipe.AutoSize = true;
            btnNewRecipe.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnNewRecipe.Location = new Point(3, 3);
            btnNewRecipe.Name = "btnNewRecipe";
            btnNewRecipe.Size = new Size(123, 38);
            btnNewRecipe.TabIndex = 0;
            btnNewRecipe.Text = "New Recipe";
            btnNewRecipe.UseVisualStyleBackColor = true;
            // 
            // gRecipeList
            // 
            gRecipeList.AllowUserToAddRows = false;
            gRecipeList.AllowUserToDeleteRows = false;
            gRecipeList.AllowUserToResizeColumns = false;
            gRecipeList.AllowUserToResizeRows = false;
            gRecipeList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gRecipeList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gRecipeList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gRecipeList.Columns.AddRange(new DataGridViewColumn[] { colRecipeName, colStatus, colUser, colCalories, colIngredients });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            gRecipeList.DefaultCellStyle = dataGridViewCellStyle2;
            gRecipeList.Dock = DockStyle.Fill;
            gRecipeList.Location = new Point(3, 47);
            gRecipeList.Name = "gRecipeList";
            gRecipeList.ReadOnly = true;
            gRecipeList.RowHeadersVisible = false;
            gRecipeList.RowHeadersWidth = 51;
            gRecipeList.RowTemplate.Height = 29;
            gRecipeList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gRecipeList.Size = new Size(794, 400);
            gRecipeList.TabIndex = 1;
            // 
            // colRecipeName
            // 
            colRecipeName.HeaderText = "Recipe Name";
            colRecipeName.MinimumWidth = 6;
            colRecipeName.Name = "colRecipeName";
            colRecipeName.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.HeaderText = "RecipeStatus";
            colStatus.MinimumWidth = 6;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // colUser
            // 
            colUser.HeaderText = "User";
            colUser.MinimumWidth = 6;
            colUser.Name = "colUser";
            colUser.ReadOnly = true;
            // 
            // colCalories
            // 
            colCalories.HeaderText = "Calories";
            colCalories.MinimumWidth = 6;
            colCalories.Name = "colCalories";
            colCalories.ReadOnly = true;
            // 
            // colIngredients
            // 
            colIngredients.HeaderText = "Num Ingredients";
            colIngredients.MinimumWidth = 6;
            colIngredients.Name = "colIngredients";
            colIngredients.ReadOnly = true;
            // 
            // frmRecipeList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tblMain);
            Name = "frmRecipeList";
            Text = "Recipe List";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gRecipeList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Button btnNewRecipe;
        private DataGridView gRecipeList;
        private DataGridViewTextBoxColumn colRecipeName;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colUser;
        private DataGridViewTextBoxColumn colCalories;
        private DataGridViewTextBoxColumn colIngredients;
    }
}