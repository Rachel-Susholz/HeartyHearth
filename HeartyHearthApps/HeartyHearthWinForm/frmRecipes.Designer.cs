namespace HeartyHearthWinForm
{
    partial class frmRecipes
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
            lblRecipeName = new Label();
            lblCuisineName = new Label();
            lblCalories = new Label();
            lblCaptionImagePath = new Label();
            lblCaptionRecipeStatus = new Label();
            lblDrafted = new Label();
            lblPublished = new Label();
            lblArchived = new Label();
            lblFirstName = new Label();
            lblLastName = new Label();
            lblUserName = new Label();
            lblImagePath = new Label();
            lblRecipeStatus = new Label();
            txtRecipeName = new TextBox();
            txtCuisineName = new TextBox();
            txtCalories = new TextBox();
            txtDrafted = new TextBox();
            txtPublished = new TextBox();
            txtArchived = new TextBox();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            txtUserName = new TextBox();
            tblSaveAndDelete = new TableLayoutPanel();
            btnSave = new Button();
            btnDelete = new Button();
            tblMain.SuspendLayout();
            tblSaveAndDelete.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.Controls.Add(lblRecipeName, 0, 0);
            tblMain.Controls.Add(lblCuisineName, 0, 1);
            tblMain.Controls.Add(lblCalories, 0, 2);
            tblMain.Controls.Add(lblCaptionImagePath, 0, 3);
            tblMain.Controls.Add(lblCaptionRecipeStatus, 0, 4);
            tblMain.Controls.Add(lblDrafted, 0, 5);
            tblMain.Controls.Add(lblPublished, 0, 6);
            tblMain.Controls.Add(lblArchived, 0, 7);
            tblMain.Controls.Add(lblFirstName, 0, 8);
            tblMain.Controls.Add(lblLastName, 0, 9);
            tblMain.Controls.Add(lblUserName, 0, 10);
            tblMain.Controls.Add(lblImagePath, 1, 3);
            tblMain.Controls.Add(lblRecipeStatus, 1, 4);
            tblMain.Controls.Add(txtRecipeName, 1, 0);
            tblMain.Controls.Add(txtCuisineName, 1, 1);
            tblMain.Controls.Add(txtCalories, 1, 2);
            tblMain.Controls.Add(txtDrafted, 1, 5);
            tblMain.Controls.Add(txtPublished, 1, 6);
            tblMain.Controls.Add(txtArchived, 1, 7);
            tblMain.Controls.Add(txtFirstName, 1, 8);
            tblMain.Controls.Add(txtLastName, 1, 9);
            tblMain.Controls.Add(txtUserName, 1, 10);
            tblMain.Dock = DockStyle.Top;
            tblMain.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 11;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 7.142857F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 7.142857F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 7.142857F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 7.142857F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 7.142857F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 7.142857F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 7.142857F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 7.142857F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 7.142857F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 7.142857F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 7.142857F));
            tblMain.Size = new Size(800, 382);
            tblMain.TabIndex = 0;
            // 
            // lblRecipeName
            // 
            lblRecipeName.Anchor = AnchorStyles.Right;
            lblRecipeName.AutoSize = true;
            lblRecipeName.Location = new Point(271, 3);
            lblRecipeName.Name = "lblRecipeName";
            lblRecipeName.Size = new Size(126, 28);
            lblRecipeName.TabIndex = 0;
            lblRecipeName.Text = "Recipe Name";
            // 
            // lblCuisineName
            // 
            lblCuisineName.Anchor = AnchorStyles.Right;
            lblCuisineName.AutoSize = true;
            lblCuisineName.Location = new Point(266, 37);
            lblCuisineName.Name = "lblCuisineName";
            lblCuisineName.Size = new Size(131, 28);
            lblCuisineName.TabIndex = 1;
            lblCuisineName.Text = "Cuisine Name";
            // 
            // lblCalories
            // 
            lblCalories.Anchor = AnchorStyles.Right;
            lblCalories.AutoSize = true;
            lblCalories.Location = new Point(316, 71);
            lblCalories.Name = "lblCalories";
            lblCalories.Size = new Size(81, 28);
            lblCalories.TabIndex = 2;
            lblCalories.Text = "Calories";
            // 
            // lblCaptionImagePath
            // 
            lblCaptionImagePath.Anchor = AnchorStyles.Right;
            lblCaptionImagePath.AutoSize = true;
            lblCaptionImagePath.Location = new Point(288, 105);
            lblCaptionImagePath.Name = "lblCaptionImagePath";
            lblCaptionImagePath.Size = new Size(109, 28);
            lblCaptionImagePath.TabIndex = 3;
            lblCaptionImagePath.Text = "Image Path";
            // 
            // lblCaptionRecipeStatus
            // 
            lblCaptionRecipeStatus.Anchor = AnchorStyles.Right;
            lblCaptionRecipeStatus.AutoSize = true;
            lblCaptionRecipeStatus.Location = new Point(270, 139);
            lblCaptionRecipeStatus.Name = "lblCaptionRecipeStatus";
            lblCaptionRecipeStatus.Size = new Size(127, 28);
            lblCaptionRecipeStatus.TabIndex = 4;
            lblCaptionRecipeStatus.Text = "Recipe Status";
            // 
            // lblDrafted
            // 
            lblDrafted.Anchor = AnchorStyles.Right;
            lblDrafted.AutoSize = true;
            lblDrafted.Location = new Point(319, 173);
            lblDrafted.Name = "lblDrafted";
            lblDrafted.Size = new Size(78, 28);
            lblDrafted.TabIndex = 5;
            lblDrafted.Text = "Drafted";
            // 
            // lblPublished
            // 
            lblPublished.Anchor = AnchorStyles.Right;
            lblPublished.AutoSize = true;
            lblPublished.Location = new Point(300, 207);
            lblPublished.Name = "lblPublished";
            lblPublished.Size = new Size(97, 28);
            lblPublished.TabIndex = 6;
            lblPublished.Text = "Published";
            // 
            // lblArchived
            // 
            lblArchived.Anchor = AnchorStyles.Right;
            lblArchived.AutoSize = true;
            lblArchived.Location = new Point(308, 241);
            lblArchived.Name = "lblArchived";
            lblArchived.Size = new Size(89, 28);
            lblArchived.TabIndex = 7;
            lblArchived.Text = "Archived";
            // 
            // lblFirstName
            // 
            lblFirstName.Anchor = AnchorStyles.Right;
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(291, 275);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(106, 28);
            lblFirstName.TabIndex = 8;
            lblFirstName.Text = "First Name";
            // 
            // lblLastName
            // 
            lblLastName.Anchor = AnchorStyles.Right;
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(294, 309);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(103, 28);
            lblLastName.TabIndex = 9;
            lblLastName.Text = "Last Name";
            // 
            // lblUserName
            // 
            lblUserName.Anchor = AnchorStyles.Right;
            lblUserName.AutoSize = true;
            lblUserName.Location = new Point(289, 347);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(108, 28);
            lblUserName.TabIndex = 10;
            lblUserName.Text = "User Name";
            // 
            // lblImagePath
            // 
            lblImagePath.Anchor = AnchorStyles.Left;
            lblImagePath.AutoSize = true;
            lblImagePath.Location = new Point(403, 105);
            lblImagePath.Name = "lblImagePath";
            lblImagePath.Size = new Size(0, 28);
            lblImagePath.TabIndex = 11;
            lblImagePath.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblRecipeStatus
            // 
            lblRecipeStatus.Anchor = AnchorStyles.Left;
            lblRecipeStatus.AutoSize = true;
            lblRecipeStatus.Location = new Point(403, 139);
            lblRecipeStatus.Name = "lblRecipeStatus";
            lblRecipeStatus.Size = new Size(0, 28);
            lblRecipeStatus.TabIndex = 12;
            lblRecipeStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtRecipeName
            // 
            txtRecipeName.Anchor = AnchorStyles.Left;
            txtRecipeName.Location = new Point(403, 3);
            txtRecipeName.Name = "txtRecipeName";
            txtRecipeName.Size = new Size(125, 34);
            txtRecipeName.TabIndex = 13;
            // 
            // txtCuisineName
            // 
            txtCuisineName.Anchor = AnchorStyles.Left;
            txtCuisineName.Location = new Point(403, 37);
            txtCuisineName.Name = "txtCuisineName";
            txtCuisineName.Size = new Size(125, 34);
            txtCuisineName.TabIndex = 14;
            // 
            // txtCalories
            // 
            txtCalories.Anchor = AnchorStyles.Left;
            txtCalories.Location = new Point(403, 71);
            txtCalories.Name = "txtCalories";
            txtCalories.Size = new Size(125, 34);
            txtCalories.TabIndex = 15;
            // 
            // txtDrafted
            // 
            txtDrafted.Anchor = AnchorStyles.Left;
            txtDrafted.Location = new Point(403, 173);
            txtDrafted.Name = "txtDrafted";
            txtDrafted.Size = new Size(125, 34);
            txtDrafted.TabIndex = 16;
            // 
            // txtPublished
            // 
            txtPublished.Anchor = AnchorStyles.Left;
            txtPublished.Location = new Point(403, 207);
            txtPublished.Name = "txtPublished";
            txtPublished.Size = new Size(125, 34);
            txtPublished.TabIndex = 17;
            // 
            // txtArchived
            // 
            txtArchived.Anchor = AnchorStyles.Left;
            txtArchived.Location = new Point(403, 241);
            txtArchived.Name = "txtArchived";
            txtArchived.Size = new Size(125, 34);
            txtArchived.TabIndex = 18;
            // 
            // txtFirstName
            // 
            txtFirstName.Anchor = AnchorStyles.Left;
            txtFirstName.Location = new Point(403, 275);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(125, 34);
            txtFirstName.TabIndex = 19;
            // 
            // txtLastName
            // 
            txtLastName.Anchor = AnchorStyles.Left;
            txtLastName.Location = new Point(403, 309);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(125, 34);
            txtLastName.TabIndex = 20;
            // 
            // txtUserName
            // 
            txtUserName.Anchor = AnchorStyles.Left;
            txtUserName.Location = new Point(403, 344);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(125, 34);
            txtUserName.TabIndex = 21;
            // 
            // tblSaveAndDelete
            // 
            tblSaveAndDelete.ColumnCount = 2;
            tblSaveAndDelete.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblSaveAndDelete.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblSaveAndDelete.Controls.Add(btnSave, 0, 0);
            tblSaveAndDelete.Controls.Add(btnDelete, 1, 0);
            tblSaveAndDelete.Dock = DockStyle.Fill;
            tblSaveAndDelete.Location = new Point(0, 382);
            tblSaveAndDelete.Name = "tblSaveAndDelete";
            tblSaveAndDelete.RowCount = 1;
            tblSaveAndDelete.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblSaveAndDelete.Size = new Size(800, 68);
            tblSaveAndDelete.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.LimeGreen;
            btnSave.Dock = DockStyle.Bottom;
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.Location = new Point(3, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(394, 62);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.Dock = DockStyle.Bottom;
            btnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDelete.Location = new Point(403, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(394, 62);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // frmRecipes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tblSaveAndDelete);
            Controls.Add(tblMain);
            Name = "frmRecipes";
            Text = "frmRecipes";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tblSaveAndDelete.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Label lblRecipeName;
        private Label lblCuisineName;
        private Label lblCalories;
        private Label lblCaptionImagePath;
        private Label lblCaptionRecipeStatus;
        private Label lblDrafted;
        private Label lblPublished;
        private Label lblArchived;
        private Label lblFirstName;
        private Label lblLastName;
        private Label lblUserName;
        private Label lblImagePath;
        private Label lblRecipeStatus;
        private TextBox txtRecipeName;
        private TextBox txtCuisineName;
        private TextBox txtCalories;
        private TextBox txtDrafted;
        private TextBox txtPublished;
        private TextBox txtArchived;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtUserName;
        private TableLayoutPanel tblSaveAndDelete;
        private Button btnSave;
        private Button btnDelete;
    }
}