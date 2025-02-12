namespace HeartyHearthWinForm
{
    partial class frmCookbookList
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
            btnNewCookbook = new Button();
            gCookbookList = new DataGridView();
            colCookbookName = new DataGridViewTextBoxColumn();
            colAuthor = new DataGridViewTextBoxColumn();
            colNumRecipes = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            tblMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gCookbookList).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(btnNewCookbook, 0, 0);
            tblMain.Controls.Add(gCookbookList, 0, 1);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 2;
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblMain.Size = new Size(800, 450);
            tblMain.TabIndex = 0;
            // 
            // btnNewCookbook
            // 
            btnNewCookbook.AutoSize = true;
            btnNewCookbook.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnNewCookbook.Location = new Point(3, 3);
            btnNewCookbook.Name = "btnNewCookbook";
            btnNewCookbook.Size = new Size(158, 38);
            btnNewCookbook.TabIndex = 0;
            btnNewCookbook.Text = "New Cookbook";
            btnNewCookbook.UseVisualStyleBackColor = true;
            // 
            // gCookbookList
            // 
            gCookbookList.AllowUserToAddRows = false;
            gCookbookList.AllowUserToDeleteRows = false;
            gCookbookList.AllowUserToResizeColumns = false;
            gCookbookList.AllowUserToResizeRows = false;
            gCookbookList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gCookbookList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gCookbookList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gCookbookList.Columns.AddRange(new DataGridViewColumn[] { colCookbookName, colAuthor, colNumRecipes, colPrice });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            gCookbookList.DefaultCellStyle = dataGridViewCellStyle2;
            gCookbookList.Dock = DockStyle.Fill;
            gCookbookList.Location = new Point(3, 47);
            gCookbookList.Name = "gCookbookList";
            gCookbookList.RowHeadersVisible = false;
            gCookbookList.RowHeadersWidth = 51;
            gCookbookList.RowTemplate.Height = 29;
            gCookbookList.Size = new Size(794, 400);
            gCookbookList.TabIndex = 1;
            // 
            // colCookbookName
            // 
            colCookbookName.HeaderText = "Cookbook Name";
            colCookbookName.MinimumWidth = 6;
            colCookbookName.Name = "colCookbookName";
            colCookbookName.ReadOnly = true;
            // 
            // colAuthor
            // 
            colAuthor.HeaderText = "Author";
            colAuthor.MinimumWidth = 6;
            colAuthor.Name = "colAuthor";
            colAuthor.ReadOnly = true;
            // 
            // colNumRecipes
            // 
            colNumRecipes.HeaderText = "Num Recipes";
            colNumRecipes.MinimumWidth = 6;
            colNumRecipes.Name = "colNumRecipes";
            colNumRecipes.ReadOnly = true;
            // 
            // colPrice
            // 
            colPrice.HeaderText = "Price";
            colPrice.MinimumWidth = 6;
            colPrice.Name = "colPrice";
            colPrice.ReadOnly = true;
            // 
            // frmCookbookList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tblMain);
            Name = "frmCookbookList";
            Text = "Cookbook List";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gCookbookList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Button btnNewCookbook;
        private DataGridView gCookbookList;
        private DataGridViewTextBoxColumn colCookbookName;
        private DataGridViewTextBoxColumn colAuthor;
        private DataGridViewTextBoxColumn colNumRecipes;
        private DataGridViewTextBoxColumn colPrice;
    }
}