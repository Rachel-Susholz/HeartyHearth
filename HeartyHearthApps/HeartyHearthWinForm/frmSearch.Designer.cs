namespace HeartyHearthWinForm
{
    partial class frmSearch
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
            tblMain = new TableLayoutPanel();
            tblControls = new TableLayoutPanel();
            txtRecipe = new TextBox();
            lblRecipe = new Label();
            btnSearch = new Button();
            gRecipes = new DataGridView();
            btnNew = new Button();
            tblMain.SuspendLayout();
            tblControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gRecipes).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(tblControls, 0, 0);
            tblMain.Controls.Add(gRecipes, 0, 1);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 2;
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.Size = new Size(800, 450);
            tblMain.TabIndex = 0;
            // 
            // tblControls
            // 
            tblControls.ColumnCount = 4;
            tblControls.ColumnStyles.Add(new ColumnStyle());
            tblControls.ColumnStyles.Add(new ColumnStyle());
            tblControls.ColumnStyles.Add(new ColumnStyle());
            tblControls.ColumnStyles.Add(new ColumnStyle());
            tblControls.Controls.Add(txtRecipe, 1, 0);
            tblControls.Controls.Add(lblRecipe, 0, 0);
            tblControls.Controls.Add(btnSearch, 2, 0);
            tblControls.Controls.Add(btnNew, 3, 0);
            tblControls.Location = new Point(3, 3);
            tblControls.Name = "tblControls";
            tblControls.RowCount = 1;
            tblControls.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblControls.Size = new Size(342, 36);
            tblControls.TabIndex = 0;
            // 
            // txtRecipe
            // 
            txtRecipe.Anchor = AnchorStyles.Left;
            txtRecipe.Location = new Point(63, 4);
            txtRecipe.Name = "txtRecipe";
            txtRecipe.Size = new Size(125, 27);
            txtRecipe.TabIndex = 0;
            // 
            // lblRecipe
            // 
            lblRecipe.Anchor = AnchorStyles.Left;
            lblRecipe.AutoSize = true;
            lblRecipe.Location = new Point(3, 8);
            lblRecipe.Name = "lblRecipe";
            lblRecipe.Size = new Size(54, 20);
            lblRecipe.TabIndex = 1;
            lblRecipe.Text = "Recipe";
            lblRecipe.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Left;
            btnSearch.AutoSize = true;
            btnSearch.Location = new Point(194, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(78, 30);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // gRecipes
            // 
            gRecipes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gRecipes.Dock = DockStyle.Fill;
            gRecipes.Location = new Point(3, 45);
            gRecipes.Name = "gRecipes";
            gRecipes.RowHeadersWidth = 51;
            gRecipes.RowTemplate.Height = 29;
            gRecipes.Size = new Size(794, 402);
            gRecipes.TabIndex = 1;
            // 
            // btnNew
            // 
            btnNew.AutoSize = true;
            btnNew.Dock = DockStyle.Fill;
            btnNew.Location = new Point(278, 3);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(61, 30);
            btnNew.TabIndex = 3;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            // 
            // frmSearch
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tblMain);
            Name = "frmSearch";
            Text = "HeartyHearth Search";
            tblMain.ResumeLayout(false);
            tblControls.ResumeLayout(false);
            tblControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gRecipes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private TableLayoutPanel tblControls;
        private TextBox txtRecipe;
        private Label lblRecipe;
        private Button btnSearch;
        private DataGridView gRecipes;
        private Button btnNew;
    }
}