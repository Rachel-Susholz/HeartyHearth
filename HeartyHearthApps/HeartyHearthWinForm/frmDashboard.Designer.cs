namespace HeartyHearthWinForm
{
    partial class frmDashboard
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
            lblHeartyHearthTitle = new Label();
            lblWelcome = new Label();
            gDashboard = new DataGridView();
            tblButtons = new TableLayoutPanel();
            btnRecipeList = new Button();
            btnMealList = new Button();
            btnCookbookList = new Button();
            tblMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gDashboard).BeginInit();
            tblButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tblMain.Controls.Add(lblHeartyHearthTitle, 0, 0);
            tblMain.Controls.Add(lblWelcome, 0, 2);
            tblMain.Controls.Add(gDashboard, 0, 4);
            tblMain.Controls.Add(tblButtons, 0, 6);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 7;
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblMain.Size = new Size(800, 450);
            tblMain.TabIndex = 0;
            // 
            // lblHeartyHearthTitle
            // 
            lblHeartyHearthTitle.AutoSize = true;
            lblHeartyHearthTitle.Dock = DockStyle.Fill;
            lblHeartyHearthTitle.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblHeartyHearthTitle.Location = new Point(3, 0);
            lblHeartyHearthTitle.Name = "lblHeartyHearthTitle";
            lblHeartyHearthTitle.Size = new Size(794, 31);
            lblHeartyHearthTitle.TabIndex = 0;
            lblHeartyHearthTitle.Text = "Hearty Hearth Desktop App";
            lblHeartyHearthTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Dock = DockStyle.Fill;
            lblWelcome.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblWelcome.Location = new Point(3, 51);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(794, 56);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Welcome to the Hearty Hearth desktop app. In this app you can create recipes and cookbooks. You can also...";
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gDashboard
            // 
            gDashboard.AllowUserToAddRows = false;
            gDashboard.AllowUserToDeleteRows = false;
            gDashboard.AllowUserToResizeColumns = false;
            gDashboard.AllowUserToResizeRows = false;
            gDashboard.Anchor = AnchorStyles.Top;
            gDashboard.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gDashboard.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gDashboard.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            gDashboard.DefaultCellStyle = dataGridViewCellStyle2;
            gDashboard.Location = new Point(250, 130);
            gDashboard.Name = "gDashboard";
            gDashboard.RowHeadersVisible = false;
            gDashboard.RowHeadersWidth = 51;
            gDashboard.RowTemplate.Height = 29;
            gDashboard.Size = new Size(300, 149);
            gDashboard.TabIndex = 2;
            // 
            // tblButtons
            // 
            tblButtons.ColumnCount = 5;
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblButtons.ColumnStyles.Add(new ColumnStyle());
            tblButtons.ColumnStyles.Add(new ColumnStyle());
            tblButtons.ColumnStyles.Add(new ColumnStyle());
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblButtons.Controls.Add(btnRecipeList, 1, 0);
            tblButtons.Controls.Add(btnMealList, 2, 0);
            tblButtons.Controls.Add(btnCookbookList, 3, 0);
            tblButtons.Dock = DockStyle.Fill;
            tblButtons.Location = new Point(3, 305);
            tblButtons.Name = "tblButtons";
            tblButtons.RowCount = 1;
            tblButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblButtons.Size = new Size(794, 142);
            tblButtons.TabIndex = 3;
            // 
            // btnRecipeList
            // 
            btnRecipeList.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRecipeList.AutoSize = true;
            btnRecipeList.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnRecipeList.Location = new Point(211, 3);
            btnRecipeList.Name = "btnRecipeList";
            btnRecipeList.Size = new Size(113, 38);
            btnRecipeList.TabIndex = 0;
            btnRecipeList.Text = "Recipe List";
            btnRecipeList.UseVisualStyleBackColor = true;
            // 
            // btnMealList
            // 
            btnMealList.Anchor = AnchorStyles.Top;
            btnMealList.AutoSize = true;
            btnMealList.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnMealList.Location = new Point(330, 3);
            btnMealList.Name = "btnMealList";
            btnMealList.Size = new Size(99, 38);
            btnMealList.TabIndex = 1;
            btnMealList.Text = "Meal List";
            btnMealList.UseVisualStyleBackColor = true;
            // 
            // btnCookbookList
            // 
            btnCookbookList.AutoSize = true;
            btnCookbookList.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnCookbookList.Location = new Point(435, 3);
            btnCookbookList.Name = "btnCookbookList";
            btnCookbookList.Size = new Size(148, 38);
            btnCookbookList.TabIndex = 2;
            btnCookbookList.Text = "Cookbook List";
            btnCookbookList.UseVisualStyleBackColor = true;
            // 
            // frmDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tblMain);
            Name = "frmDashboard";
            Text = "Hearty Hearth - Dashboard";
            Load += this.frmDashboard_Load;
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gDashboard).EndInit();
            tblButtons.ResumeLayout(false);
            tblButtons.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Label lblHeartyHearthTitle;
        private Label lblWelcome;
        private DataGridView gDashboard;
        private TableLayoutPanel tblButtons;
        private Button btnRecipeList;
        private Button btnMealList;
        private Button btnCookbookList;
    }
}