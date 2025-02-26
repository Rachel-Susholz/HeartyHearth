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
            lstUserName = new ComboBox();
            btnSave = new Button();
            btnDelete = new Button();
            lstCuisineName = new ComboBox();
            btnChangeStatus = new Button();
            tbChildRecords = new TabControl();
            tbIngredients = new TabPage();
            tblIngredients = new TableLayoutPanel();
            btnSaveIngredients = new Button();
            gIngredients = new DataGridView();
            tbSteps = new TabPage();
            tblMain.SuspendLayout();
            tbChildRecords.SuspendLayout();
            tbIngredients.SuspendLayout();
            tblIngredients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gIngredients).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.AutoSize = true;
            tblMain.ColumnCount = 3;
            tblMain.ColumnStyles.Add(new ColumnStyle());
            tblMain.ColumnStyles.Add(new ColumnStyle());
            tblMain.ColumnStyles.Add(new ColumnStyle());
            tblMain.Controls.Add(lblRecipeName, 0, 1);
            tblMain.Controls.Add(lblCuisineName, 0, 2);
            tblMain.Controls.Add(lblCalories, 0, 3);
            tblMain.Controls.Add(txtRecipeName, 1, 1);
            tblMain.Controls.Add(txtCalories, 1, 3);
            tblMain.Controls.Add(lblRecipeStatus, 0, 4);
            tblMain.Controls.Add(lblDrafted, 0, 5);
            tblMain.Controls.Add(lblCaptionPublished, 0, 6);
            tblMain.Controls.Add(lblCaptionArchived, 0, 7);
            tblMain.Controls.Add(txtDrafted, 1, 5);
            tblMain.Controls.Add(txtRecipeStatus, 1, 4);
            tblMain.Controls.Add(lblPublished, 1, 6);
            tblMain.Controls.Add(lblArchived, 1, 7);
            tblMain.Controls.Add(lblUserName, 0, 8);
            tblMain.Controls.Add(lstUserName, 1, 8);
            tblMain.Controls.Add(btnSave, 0, 0);
            tblMain.Controls.Add(btnDelete, 1, 0);
            tblMain.Controls.Add(lstCuisineName, 1, 2);
            tblMain.Controls.Add(btnChangeStatus, 2, 0);
            tblMain.Dock = DockStyle.Top;
            tblMain.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 9;
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblMain.Size = new Size(870, 380);
            tblMain.TabIndex = 0;
            // 
            // lblRecipeName
            // 
            lblRecipeName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblRecipeName.AutoSize = true;
            lblRecipeName.Location = new Point(3, 51);
            lblRecipeName.Name = "lblRecipeName";
            lblRecipeName.Size = new Size(182, 28);
            lblRecipeName.TabIndex = 0;
            lblRecipeName.Text = "Recipe Name";
            // 
            // lblCuisineName
            // 
            lblCuisineName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblCuisineName.AutoSize = true;
            lblCuisineName.Location = new Point(3, 93);
            lblCuisineName.Name = "lblCuisineName";
            lblCuisineName.Size = new Size(182, 28);
            lblCuisineName.TabIndex = 2;
            lblCuisineName.Text = "Cuisine Name";
            // 
            // lblCalories
            // 
            lblCalories.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblCalories.AutoSize = true;
            lblCalories.Location = new Point(3, 135);
            lblCalories.Name = "lblCalories";
            lblCalories.Size = new Size(182, 28);
            lblCalories.TabIndex = 4;
            lblCalories.Text = "Calories";
            // 
            // txtRecipeName
            // 
            tblMain.SetColumnSpan(txtRecipeName, 2);
            txtRecipeName.Dock = DockStyle.Fill;
            txtRecipeName.Location = new Point(191, 47);
            txtRecipeName.Name = "txtRecipeName";
            txtRecipeName.Size = new Size(676, 34);
            txtRecipeName.TabIndex = 1;
            // 
            // txtCalories
            // 
            tblMain.SetColumnSpan(txtCalories, 2);
            txtCalories.Dock = DockStyle.Fill;
            txtCalories.Location = new Point(191, 131);
            txtCalories.Name = "txtCalories";
            txtCalories.Size = new Size(676, 34);
            txtCalories.TabIndex = 5;
            // 
            // lblRecipeStatus
            // 
            lblRecipeStatus.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblRecipeStatus.AutoSize = true;
            lblRecipeStatus.Location = new Point(3, 177);
            lblRecipeStatus.Name = "lblRecipeStatus";
            lblRecipeStatus.Size = new Size(182, 28);
            lblRecipeStatus.TabIndex = 6;
            lblRecipeStatus.Text = "Recipe Status";
            // 
            // lblDrafted
            // 
            lblDrafted.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblDrafted.AutoSize = true;
            lblDrafted.Location = new Point(3, 219);
            lblDrafted.Name = "lblDrafted";
            lblDrafted.Size = new Size(182, 28);
            lblDrafted.TabIndex = 8;
            lblDrafted.Text = "Drafted";
            // 
            // lblCaptionPublished
            // 
            lblCaptionPublished.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblCaptionPublished.AutoSize = true;
            lblCaptionPublished.Location = new Point(3, 261);
            lblCaptionPublished.Name = "lblCaptionPublished";
            lblCaptionPublished.Size = new Size(182, 28);
            lblCaptionPublished.TabIndex = 10;
            lblCaptionPublished.Text = "Published";
            // 
            // lblCaptionArchived
            // 
            lblCaptionArchived.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblCaptionArchived.AutoSize = true;
            lblCaptionArchived.Location = new Point(3, 303);
            lblCaptionArchived.Name = "lblCaptionArchived";
            lblCaptionArchived.Size = new Size(182, 28);
            lblCaptionArchived.TabIndex = 12;
            lblCaptionArchived.Text = "Archived";
            // 
            // txtDrafted
            // 
            tblMain.SetColumnSpan(txtDrafted, 2);
            txtDrafted.Dock = DockStyle.Fill;
            txtDrafted.Location = new Point(191, 215);
            txtDrafted.Name = "txtDrafted";
            txtDrafted.Size = new Size(676, 34);
            txtDrafted.TabIndex = 9;
            // 
            // txtRecipeStatus
            // 
            tblMain.SetColumnSpan(txtRecipeStatus, 2);
            txtRecipeStatus.Dock = DockStyle.Fill;
            txtRecipeStatus.Location = new Point(191, 173);
            txtRecipeStatus.Name = "txtRecipeStatus";
            txtRecipeStatus.ReadOnly = true;
            txtRecipeStatus.Size = new Size(676, 34);
            txtRecipeStatus.TabIndex = 7;
            // 
            // lblPublished
            // 
            lblPublished.BorderStyle = BorderStyle.FixedSingle;
            tblMain.SetColumnSpan(lblPublished, 2);
            lblPublished.Dock = DockStyle.Fill;
            lblPublished.Location = new Point(191, 254);
            lblPublished.Name = "lblPublished";
            lblPublished.Size = new Size(676, 42);
            lblPublished.TabIndex = 11;
            lblPublished.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblArchived
            // 
            lblArchived.BorderStyle = BorderStyle.FixedSingle;
            tblMain.SetColumnSpan(lblArchived, 2);
            lblArchived.Dock = DockStyle.Fill;
            lblArchived.Location = new Point(191, 296);
            lblArchived.Name = "lblArchived";
            lblArchived.Size = new Size(676, 42);
            lblArchived.TabIndex = 13;
            lblArchived.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblUserName
            // 
            lblUserName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblUserName.AutoSize = true;
            lblUserName.Location = new Point(3, 345);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(182, 28);
            lblUserName.TabIndex = 14;
            lblUserName.Text = "User Name";
            // 
            // lstUserName
            // 
            tblMain.SetColumnSpan(lstUserName, 2);
            lstUserName.Dock = DockStyle.Fill;
            lstUserName.FormattingEnabled = true;
            lstUserName.Location = new Point(191, 341);
            lstUserName.Name = "lstUserName";
            lstUserName.Size = new Size(676, 36);
            lstUserName.TabIndex = 15;
            // 
            // btnSave
            // 
            btnSave.AutoSize = true;
            btnSave.Dock = DockStyle.Fill;
            btnSave.Location = new Point(3, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(182, 38);
            btnSave.TabIndex = 16;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.AutoSize = true;
            btnDelete.Dock = DockStyle.Fill;
            btnDelete.Location = new Point(191, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(177, 38);
            btnDelete.TabIndex = 17;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // lstCuisineName
            // 
            tblMain.SetColumnSpan(lstCuisineName, 2);
            lstCuisineName.Dock = DockStyle.Fill;
            lstCuisineName.FormattingEnabled = true;
            lstCuisineName.Location = new Point(191, 89);
            lstCuisineName.Name = "lstCuisineName";
            lstCuisineName.Size = new Size(676, 36);
            lstCuisineName.TabIndex = 3;
            // 
            // btnChangeStatus
            // 
            btnChangeStatus.AutoSize = true;
            btnChangeStatus.Dock = DockStyle.Right;
            btnChangeStatus.Location = new Point(709, 3);
            btnChangeStatus.Name = "btnChangeStatus";
            btnChangeStatus.Size = new Size(158, 38);
            btnChangeStatus.TabIndex = 18;
            btnChangeStatus.Text = "Change Status...";
            btnChangeStatus.UseVisualStyleBackColor = true;
            // 
            // tbChildRecords
            // 
            tbChildRecords.Controls.Add(tbIngredients);
            tbChildRecords.Controls.Add(tbSteps);
            tbChildRecords.Dock = DockStyle.Fill;
            tbChildRecords.Location = new Point(0, 380);
            tbChildRecords.Name = "tbChildRecords";
            tbChildRecords.SelectedIndex = 0;
            tbChildRecords.Size = new Size(870, 221);
            tbChildRecords.TabIndex = 1;
            // 
            // tbIngredients
            // 
            tbIngredients.Controls.Add(tblIngredients);
            tbIngredients.Location = new Point(4, 29);
            tbIngredients.Name = "tbIngredients";
            tbIngredients.Padding = new Padding(3);
            tbIngredients.Size = new Size(862, 188);
            tbIngredients.TabIndex = 0;
            tbIngredients.Text = "Ingredients";
            tbIngredients.UseVisualStyleBackColor = true;
            // 
            // tblIngredients
            // 
            tblIngredients.ColumnCount = 1;
            tblIngredients.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblIngredients.Controls.Add(btnSaveIngredients, 0, 0);
            tblIngredients.Controls.Add(gIngredients, 0, 1);
            tblIngredients.Dock = DockStyle.Fill;
            tblIngredients.Location = new Point(3, 3);
            tblIngredients.Name = "tblIngredients";
            tblIngredients.RowCount = 2;
            tblIngredients.RowStyles.Add(new RowStyle());
            tblIngredients.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblIngredients.Size = new Size(856, 182);
            tblIngredients.TabIndex = 0;
            // 
            // btnSaveIngredients
            // 
            btnSaveIngredients.AutoSize = true;
            btnSaveIngredients.Location = new Point(3, 3);
            btnSaveIngredients.Name = "btnSaveIngredients";
            btnSaveIngredients.Size = new Size(94, 30);
            btnSaveIngredients.TabIndex = 0;
            btnSaveIngredients.Text = "Save";
            btnSaveIngredients.UseVisualStyleBackColor = true;
            // 
            // gIngredients
            // 
            gIngredients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gIngredients.Dock = DockStyle.Fill;
            gIngredients.Location = new Point(3, 39);
            gIngredients.Name = "gIngredients";
            gIngredients.RowHeadersWidth = 51;
            gIngredients.RowTemplate.Height = 29;
            gIngredients.Size = new Size(850, 140);
            gIngredients.TabIndex = 1;
            // 
            // tbSteps
            // 
            tbSteps.Location = new Point(4, 29);
            tbSteps.Name = "tbSteps";
            tbSteps.Padding = new Padding(3);
            tbSteps.Size = new Size(710, 188);
            tbSteps.TabIndex = 1;
            tbSteps.Text = "Steps";
            tbSteps.UseVisualStyleBackColor = true;
            // 
            // frmRecipeInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(870, 601);
            Controls.Add(tbChildRecords);
            Controls.Add(tblMain);
            Name = "frmRecipeInfo";
            Text = "Recipe Info";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tbChildRecords.ResumeLayout(false);
            tbIngredients.ResumeLayout(false);
            tblIngredients.ResumeLayout(false);
            tblIngredients.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gIngredients).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private Label lblRecipeStatus;
        private Label lblPublished;
        private Label lblArchived;
        private ComboBox lstCuisineName;
        private ComboBox lstUserName;
        private TextBox txtRecipeStatus;
        private Button btnSave;
        private Button btnDelete;
        private Button btnChangeStatus;
        private TabControl tbChildRecords;
        private TabPage tbIngredients;
        private TabPage tbSteps;
        private TableLayoutPanel tblIngredients;
        private Button btnSaveIngredients;
        private DataGridView gIngredients;
    }
}