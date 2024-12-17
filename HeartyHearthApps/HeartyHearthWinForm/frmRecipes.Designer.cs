namespace HeartyHearthWinForm
{
    partial class frmRecipeInfo
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
            txtRecipeName = new TextBox();
            txtCalories = new TextBox();
            lblRecipeStatus = new Label();
            lblDrafted = new Label();
            lblCaptionPublished = new Label();
            lblCaptionArchived = new Label();
            txtDrafted = new TextBox();
            txtRecipeStatus = new TextBox();
            lblPublished = new Label();
            lblArchived = new Label();
            lblUserName = new Label();
            lstCuisineName = new ComboBox();
            lstUserName = new ComboBox();
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
            tblMain.Controls.Add(txtRecipeName, 1, 0);
            tblMain.Controls.Add(txtCalories, 1, 2);
            tblMain.Controls.Add(lblRecipeStatus, 0, 3);
            tblMain.Controls.Add(lblDrafted, 0, 4);
            tblMain.Controls.Add(lblCaptionPublished, 0, 5);
            tblMain.Controls.Add(lblCaptionArchived, 0, 6);
            tblMain.Controls.Add(txtDrafted, 1, 4);
            tblMain.Controls.Add(txtRecipeStatus, 1, 3);
            tblMain.Controls.Add(lblPublished, 1, 5);
            tblMain.Controls.Add(lblArchived, 1, 6);
            tblMain.Controls.Add(lblUserName, 0, 7);
            tblMain.Controls.Add(lstCuisineName, 1, 1);
            tblMain.Controls.Add(lstUserName, 1, 7);
            tblMain.Dock = DockStyle.Top;
            tblMain.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 8;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblMain.Size = new Size(800, 382);
            tblMain.TabIndex = 0;
            // 
            // lblRecipeName
            // 
            lblRecipeName.Anchor = AnchorStyles.Right;
            lblRecipeName.AutoSize = true;
            lblRecipeName.Location = new Point(271, 9);
            lblRecipeName.Name = "lblRecipeName";
            lblRecipeName.Size = new Size(126, 28);
            lblRecipeName.TabIndex = 0;
            lblRecipeName.Text = "Recipe Name";
            // 
            // lblCuisineName
            // 
            lblCuisineName.Anchor = AnchorStyles.Right;
            lblCuisineName.AutoSize = true;
            lblCuisineName.Location = new Point(266, 56);
            lblCuisineName.Name = "lblCuisineName";
            lblCuisineName.Size = new Size(131, 28);
            lblCuisineName.TabIndex = 2;
            lblCuisineName.Text = "Cuisine Name";
            // 
            // lblCalories
            // 
            lblCalories.Anchor = AnchorStyles.Right;
            lblCalories.AutoSize = true;
            lblCalories.Location = new Point(316, 103);
            lblCalories.Name = "lblCalories";
            lblCalories.Size = new Size(81, 28);
            lblCalories.TabIndex = 4;
            lblCalories.Text = "Calories";
            // 
            // txtRecipeName
            // 
            txtRecipeName.Anchor = AnchorStyles.Left;
            txtRecipeName.Location = new Point(403, 6);
            txtRecipeName.Name = "txtRecipeName";
            txtRecipeName.Size = new Size(125, 34);
            txtRecipeName.TabIndex = 1;
            // 
            // txtCalories
            // 
            txtCalories.Anchor = AnchorStyles.Left;
            txtCalories.Location = new Point(403, 100);
            txtCalories.Name = "txtCalories";
            txtCalories.Size = new Size(125, 34);
            txtCalories.TabIndex = 5;
            // 
            // lblRecipeStatus
            // 
            lblRecipeStatus.Anchor = AnchorStyles.Right;
            lblRecipeStatus.AutoSize = true;
            lblRecipeStatus.Location = new Point(270, 150);
            lblRecipeStatus.Name = "lblRecipeStatus";
            lblRecipeStatus.Size = new Size(127, 28);
            lblRecipeStatus.TabIndex = 6;
            lblRecipeStatus.Text = "Recipe Status";
            // 
            // lblDrafted
            // 
            lblDrafted.Anchor = AnchorStyles.Right;
            lblDrafted.AutoSize = true;
            lblDrafted.Location = new Point(319, 197);
            lblDrafted.Name = "lblDrafted";
            lblDrafted.Size = new Size(78, 28);
            lblDrafted.TabIndex = 8;
            lblDrafted.Text = "Drafted";
            // 
            // lblCaptionPublished
            // 
            lblCaptionPublished.Anchor = AnchorStyles.Right;
            lblCaptionPublished.AutoSize = true;
            lblCaptionPublished.Location = new Point(300, 244);
            lblCaptionPublished.Name = "lblCaptionPublished";
            lblCaptionPublished.Size = new Size(97, 28);
            lblCaptionPublished.TabIndex = 10;
            lblCaptionPublished.Text = "Published";
            // 
            // lblCaptionArchived
            // 
            lblCaptionArchived.Anchor = AnchorStyles.Right;
            lblCaptionArchived.AutoSize = true;
            lblCaptionArchived.Location = new Point(308, 291);
            lblCaptionArchived.Name = "lblCaptionArchived";
            lblCaptionArchived.Size = new Size(89, 28);
            lblCaptionArchived.TabIndex = 12;
            lblCaptionArchived.Text = "Archived";
            // 
            // txtDrafted
            // 
            txtDrafted.Anchor = AnchorStyles.Left;
            txtDrafted.Location = new Point(403, 194);
            txtDrafted.Name = "txtDrafted";
            txtDrafted.Size = new Size(125, 34);
            txtDrafted.TabIndex = 9;
            // 
            // txtRecipeStatus
            // 
            txtRecipeStatus.Location = new Point(403, 144);
            txtRecipeStatus.Name = "txtRecipeStatus";
            txtRecipeStatus.ReadOnly = true;
            txtRecipeStatus.Size = new Size(125, 34);
            txtRecipeStatus.TabIndex = 7;
            // 
            // lblPublished
            // 
            lblPublished.BorderStyle = BorderStyle.FixedSingle;
            lblPublished.Location = new Point(403, 235);
            lblPublished.Name = "lblPublished";
            lblPublished.Size = new Size(125, 38);
            lblPublished.TabIndex = 11;
            lblPublished.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblArchived
            // 
            lblArchived.BorderStyle = BorderStyle.FixedSingle;
            lblArchived.Location = new Point(403, 282);
            lblArchived.Name = "lblArchived";
            lblArchived.Size = new Size(125, 38);
            lblArchived.TabIndex = 13;
            lblArchived.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblUserName
            // 
            lblUserName.Anchor = AnchorStyles.Right;
            lblUserName.AutoSize = true;
            lblUserName.Location = new Point(289, 341);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(108, 28);
            lblUserName.TabIndex = 14;
            lblUserName.Text = "User Name";
            // 
            // lstCuisineName
            // 
            lstCuisineName.FormattingEnabled = true;
            lstCuisineName.Location = new Point(403, 50);
            lstCuisineName.Name = "lstCuisineName";
            lstCuisineName.Size = new Size(125, 36);
            lstCuisineName.TabIndex = 3;
            // 
            // lstUserName
            // 
            lstUserName.FormattingEnabled = true;
            lstUserName.Location = new Point(403, 332);
            lstUserName.Name = "lstUserName";
            lstUserName.Size = new Size(125, 36);
            lstUserName.TabIndex = 15;
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
            // frmRecipeInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tblSaveAndDelete);
            Controls.Add(tblMain);
            Name = "frmRecipeInfo";
            Text = "Recipe Info";
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
        private Label lblDrafted;
        private Label lblCaptionPublished;
        private Label lblCaptionArchived;
        private Label lblUserName;
        private TextBox txtRecipeName;
        private TextBox txtCalories;
        private TextBox txtDrafted;
        private TableLayoutPanel tblSaveAndDelete;
        private Button btnSave;
        private Button btnDelete;
        private Label lblRecipeStatus;
        private Label lblPublished;
        private Label lblArchived;
        private ComboBox lstCuisineName;
        private ComboBox lstUserName;
        private TextBox txtRecipeStatus;
    }
}