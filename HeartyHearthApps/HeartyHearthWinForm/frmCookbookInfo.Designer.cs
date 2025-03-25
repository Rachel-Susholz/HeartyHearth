namespace HeartyHearthWinForm
{
    partial class frmCookbookInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tblMain = new TableLayoutPanel();
            btnSave = new Button();
            btnDelete = new Button();
            lblCookbokkName = new Label();
            lblUser = new Label();
            lblPrice = new Label();
            lblActive = new Label();
            txtCookbookName = new TextBox();
            txtPrice = new TextBox();
            lstUserName = new ComboBox();
            tbChildRecords = new TableLayoutPanel();
            btnSaveRecipe = new Button();
            gCookbookRecipes = new DataGridView();
            lblDateCreated = new Label();
            txtCreated = new TextBox();
            cbxCookbookStatus = new CheckBox();
            tblMain.SuspendLayout();
            tbChildRecords.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gCookbookRecipes).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 3;
            tblMain.ColumnStyles.Add(new ColumnStyle());
            tblMain.ColumnStyles.Add(new ColumnStyle());
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(btnSave, 0, 0);
            tblMain.Controls.Add(btnDelete, 1, 0);
            tblMain.Controls.Add(lblCookbokkName, 0, 1);
            tblMain.Controls.Add(lblUser, 0, 2);
            tblMain.Controls.Add(lblPrice, 0, 4);
            tblMain.Controls.Add(lblActive, 0, 5);
            tblMain.Controls.Add(txtCookbookName, 1, 1);
            tblMain.Controls.Add(txtPrice, 1, 4);
            tblMain.Controls.Add(lstUserName, 1, 2);
            tblMain.Controls.Add(tbChildRecords, 0, 6);
            tblMain.Controls.Add(lblDateCreated, 2, 3);
            tblMain.Controls.Add(txtCreated, 2, 4);
            tblMain.Controls.Add(cbxCookbookStatus, 1, 5);
            tblMain.Dock = DockStyle.Fill;
            tblMain.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 7;
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblMain.Size = new Size(800, 450);
            tblMain.TabIndex = 0;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(3, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(130, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // lblCookbokkName
            // 
            lblCookbokkName.AutoSize = true;
            lblCookbokkName.Location = new Point(3, 35);
            lblCookbokkName.Name = "lblCookbokkName";
            lblCookbokkName.Size = new Size(121, 20);
            lblCookbokkName.TabIndex = 2;
            lblCookbokkName.Text = "Cookbook Name";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(3, 68);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(38, 20);
            lblUser.TabIndex = 3;
            lblUser.Text = "User";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(3, 122);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(41, 20);
            lblPrice.TabIndex = 4;
            lblPrice.Text = "Price";
            // 
            // lblActive
            // 
            lblActive.AutoSize = true;
            lblActive.Location = new Point(3, 155);
            lblActive.Name = "lblActive";
            lblActive.Size = new Size(50, 20);
            lblActive.TabIndex = 5;
            lblActive.Text = "Active";
            // 
            // txtCookbookName
            // 
            tblMain.SetColumnSpan(txtCookbookName, 2);
            txtCookbookName.Location = new Point(130, 38);
            txtCookbookName.Name = "txtCookbookName";
            txtCookbookName.Size = new Size(461, 27);
            txtCookbookName.TabIndex = 6;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(130, 125);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(125, 27);
            txtPrice.TabIndex = 7;
            // 
            // lstUserName
            // 
            tblMain.SetColumnSpan(lstUserName, 2);
            lstUserName.FormattingEnabled = true;
            lstUserName.Location = new Point(130, 71);
            lstUserName.Name = "lstUserName";
            lstUserName.Size = new Size(461, 28);
            lstUserName.TabIndex = 9;
            // 
            // tbChildRecords
            // 
            tbChildRecords.ColumnCount = 1;
            tblMain.SetColumnSpan(tbChildRecords, 3);
            tbChildRecords.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tbChildRecords.Controls.Add(btnSaveRecipe, 0, 0);
            tbChildRecords.Controls.Add(gCookbookRecipes, 0, 1);
            tbChildRecords.Dock = DockStyle.Fill;
            tbChildRecords.Location = new Point(3, 181);
            tbChildRecords.Name = "tbChildRecords";
            tbChildRecords.RowCount = 2;
            tbChildRecords.RowStyles.Add(new RowStyle());
            tbChildRecords.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tbChildRecords.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tbChildRecords.Size = new Size(794, 266);
            tbChildRecords.TabIndex = 10;
            // 
            // btnSaveRecipe
            // 
            btnSaveRecipe.Location = new Point(3, 3);
            btnSaveRecipe.Name = "btnSaveRecipe";
            btnSaveRecipe.Size = new Size(94, 29);
            btnSaveRecipe.TabIndex = 0;
            btnSaveRecipe.Text = "Save";
            btnSaveRecipe.UseVisualStyleBackColor = true;
            // 
            // gCookbookRecipes
            // 
            gCookbookRecipes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gCookbookRecipes.Dock = DockStyle.Fill;
            gCookbookRecipes.Location = new Point(3, 38);
            gCookbookRecipes.Name = "gCookbookRecipes";
            gCookbookRecipes.RowHeadersWidth = 51;
            gCookbookRecipes.RowTemplate.Height = 29;
            gCookbookRecipes.Size = new Size(788, 225);
            gCookbookRecipes.TabIndex = 1;
            // 
            // lblDateCreated
            // 
            lblDateCreated.Anchor = AnchorStyles.Top;
            lblDateCreated.AutoSize = true;
            lblDateCreated.Location = new Point(480, 102);
            lblDateCreated.Name = "lblDateCreated";
            lblDateCreated.Size = new Size(97, 20);
            lblDateCreated.TabIndex = 11;
            lblDateCreated.Text = "Date Created";
            // 
            // txtCreated
            // 
            txtCreated.Anchor = AnchorStyles.Top;
            txtCreated.Location = new Point(466, 125);
            txtCreated.Name = "txtCreated";
            txtCreated.Size = new Size(125, 27);
            txtCreated.TabIndex = 12;
            txtCreated.TextAlign = HorizontalAlignment.Center;
            // 
            // cbxCookbookStatus
            // 
            cbxCookbookStatus.AutoSize = true;
            cbxCookbookStatus.Location = new Point(130, 158);
            cbxCookbookStatus.Name = "cbxCookbookStatus";
            cbxCookbookStatus.Size = new Size(18, 17);
            cbxCookbookStatus.TabIndex = 13;
            cbxCookbookStatus.UseVisualStyleBackColor = true;
            // 
            // frmCookbookInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tblMain);
            Name = "frmCookbookInfo";
            Text = "frmCookbookInfo";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tbChildRecords.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gCookbookRecipes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Button btnSave;
        private Button btnDelete;
        private Label lblCookbokkName;
        private Label lblUser;
        private Label lblPrice;
        private Label lblActive;
        private TextBox txtCookbookName;
        private TextBox txtPrice;
        private ComboBox lstUserName;
        private TableLayoutPanel tbChildRecords;
        private Button btnSaveRecipe;
        private DataGridView gCookbookRecipes;
        private Label lblDateCreated;
        private TextBox txtCreated;
        private CheckBox cbxCookbookStatus;
    }
}