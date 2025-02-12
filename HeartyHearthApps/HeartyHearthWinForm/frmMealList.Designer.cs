namespace HeartyHearthWinForm
{
    partial class frmMealList
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
            gMealList = new DataGridView();
            colMealName = new DataGridViewTextBoxColumn();
            colUser = new DataGridViewTextBoxColumn();
            colCalories = new DataGridViewTextBoxColumn();
            colCourses = new DataGridViewTextBoxColumn();
            colRecipes = new DataGridViewTextBoxColumn();
            tblMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gMealList).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.Controls.Add(gMealList, 0, 0);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 1;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblMain.Size = new Size(800, 450);
            tblMain.TabIndex = 0;
            // 
            // gMealList
            // 
            gMealList.AllowUserToAddRows = false;
            gMealList.AllowUserToDeleteRows = false;
            gMealList.AllowUserToResizeColumns = false;
            gMealList.AllowUserToResizeRows = false;
            gMealList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gMealList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gMealList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gMealList.Columns.AddRange(new DataGridViewColumn[] { colMealName, colUser, colCalories, colCourses, colRecipes });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            gMealList.DefaultCellStyle = dataGridViewCellStyle2;
            gMealList.Dock = DockStyle.Fill;
            gMealList.Location = new Point(3, 3);
            gMealList.Name = "gMealList";
            gMealList.RowHeadersVisible = false;
            gMealList.RowHeadersWidth = 51;
            gMealList.RowTemplate.Height = 29;
            gMealList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gMealList.Size = new Size(794, 444);
            gMealList.TabIndex = 0;
            // 
            // colMealName
            // 
            colMealName.HeaderText = "Meal Name";
            colMealName.MinimumWidth = 6;
            colMealName.Name = "colMealName";
            colMealName.ReadOnly = true;
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
            // colCourses
            // 
            colCourses.HeaderText = "Num Courses";
            colCourses.MinimumWidth = 6;
            colCourses.Name = "colCourses";
            colCourses.ReadOnly = true;
            // 
            // colRecipes
            // 
            colRecipes.HeaderText = "NumRecipes";
            colRecipes.MinimumWidth = 6;
            colRecipes.Name = "colRecipes";
            colRecipes.ReadOnly = true;
            // 
            // frmMealList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tblMain);
            Name = "frmMealList";
            Text = "Meal List";
            tblMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gMealList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private DataGridView gMealList;
        private DataGridViewTextBoxColumn colMealName;
        private DataGridViewTextBoxColumn colUser;
        private DataGridViewTextBoxColumn colCalories;
        private DataGridViewTextBoxColumn colCourses;
        private DataGridViewTextBoxColumn colRecipes;
    }
}