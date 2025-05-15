namespace HeartyHearthWinForm
{
    partial class frmRecipeInfo
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel tblHeader;
        private System.Windows.Forms.Label lblRecipeName;
        private System.Windows.Forms.Label lblCuisineName;
        private System.Windows.Forms.Label lblCalories;
        private System.Windows.Forms.Label lblRecipeStatus;
        private System.Windows.Forms.Label lblDrafted;
        private System.Windows.Forms.Label lblCaptionPublished;
        private System.Windows.Forms.Label lblCaptionArchived;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtRecipeName;
        private System.Windows.Forms.TextBox txtCalories;
        private System.Windows.Forms.TextBox txtRecipeStatus;
        private System.Windows.Forms.TextBox txtDrafted;
        private System.Windows.Forms.TextBox txtPublished;
        private System.Windows.Forms.TextBox txtArchived;
        private System.Windows.Forms.ComboBox lstCuisineName;
        private System.Windows.Forms.ComboBox lstUserName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnChangeStatus;
        private System.Windows.Forms.TabControl tbChildRecords;
        private System.Windows.Forms.TabPage tbIngredients;
        private System.Windows.Forms.TableLayoutPanel tblIngredients;
        private System.Windows.Forms.Button btnSaveIngredients;
        private System.Windows.Forms.DataGridView gIngredients;
        private System.Windows.Forms.TabPage tbSteps;
        private System.Windows.Forms.TableLayoutPanel tblSteps;
        private System.Windows.Forms.Button btnSaveSteps;
        private System.Windows.Forms.DataGridView gSteps;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            tblHeader = new TableLayoutPanel();
            btnSave = new Button();
            btnDelete = new Button();
            btnChangeStatus = new Button();
            lblRecipeName = new Label();
            txtRecipeName = new TextBox();
            lblCuisineName = new Label();
            lstCuisineName = new ComboBox();
            lblCalories = new Label();
            txtCalories = new TextBox();
            lblRecipeStatus = new Label();
            txtRecipeStatus = new TextBox();
            lblDrafted = new Label();
            txtDrafted = new TextBox();
            lblCaptionPublished = new Label();
            txtPublished = new TextBox();
            lblCaptionArchived = new Label();
            txtArchived = new TextBox();
            lblUserName = new Label();
            lstUserName = new ComboBox();
            tbChildRecords = new TabControl();
            tbIngredients = new TabPage();
            tblIngredients = new TableLayoutPanel();
            btnSaveIngredients = new Button();
            gIngredients = new DataGridView();
            tbSteps = new TabPage();
            tblSteps = new TableLayoutPanel();
            btnSaveSteps = new Button();
            gSteps = new DataGridView();
            tblHeader.SuspendLayout();
            tbChildRecords.SuspendLayout();
            tbIngredients.SuspendLayout();
            tblIngredients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gIngredients).BeginInit();
            tbSteps.SuspendLayout();
            tblSteps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gSteps).BeginInit();
            SuspendLayout();
            // 
            // tblHeader
            // 
            tblHeader.AutoSize = false;
            tblHeader.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tblHeader.ColumnCount = 3;
            tblHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tblHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tblHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblHeader.Controls.Add(btnSave, 0, 0);
            tblHeader.Controls.Add(btnDelete, 1, 0);
            tblHeader.Controls.Add(btnChangeStatus, 2, 0);
            tblHeader.Controls.Add(lblRecipeName, 0, 1);
            tblHeader.Controls.Add(txtRecipeName, 1, 1);
            tblHeader.Controls.Add(lblCuisineName, 0, 2);
            tblHeader.Controls.Add(lstCuisineName, 1, 2);
            tblHeader.Controls.Add(lblCalories, 0, 3);
            tblHeader.Controls.Add(txtCalories, 1, 3);
            tblHeader.Controls.Add(lblRecipeStatus, 0, 4);
            tblHeader.Controls.Add(txtRecipeStatus, 1, 4);
            tblHeader.Controls.Add(lblDrafted, 0, 5);
            tblHeader.Controls.Add(txtDrafted, 1, 5);
            tblHeader.Controls.Add(lblCaptionPublished, 0, 6);
            tblHeader.Controls.Add(txtPublished, 1, 6);
            tblHeader.Controls.Add(lblCaptionArchived, 0, 7);
            tblHeader.Controls.Add(txtArchived, 1, 7);
            tblHeader.Controls.Add(lblUserName, 0, 8);
            tblHeader.Controls.Add(lstUserName, 1, 8);
            tblHeader.Dock = DockStyle.Top;
            tblHeader.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tblHeader.Location = new Point(0, 0);
            tblHeader.Name = "tblHeader";
            tblHeader.RowCount = 9;
            tblHeader.RowStyles.Add(new RowStyle());
            tblHeader.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblHeader.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblHeader.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblHeader.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblHeader.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblHeader.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tblHeader.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tblHeader.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblHeader.Size = new Size(782, 364);
            tblHeader.TabIndex = 0;
            // 
            // btnSave
            // 
            btnSave.AutoSize = true;
            btnSave.Dock = DockStyle.Fill;
            btnSave.Location = new Point(3, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(194, 38);
            btnSave.TabIndex = 16;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.AutoSize = true;
            btnDelete.Dock = DockStyle.Fill;
            btnDelete.Location = new Point(203, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(194, 38);
            btnDelete.TabIndex = 17;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnChangeStatus
            // 
            btnChangeStatus.AutoSize = true;
            btnChangeStatus.Dock = DockStyle.Fill;
            btnChangeStatus.Location = new Point(403, 3);
            btnChangeStatus.Name = "btnChangeStatus";
            btnChangeStatus.Size = new Size(376, 38);
            btnChangeStatus.TabIndex = 18;
            btnChangeStatus.Text = "Change Status...";
            btnChangeStatus.UseVisualStyleBackColor = true;
            // 
            // lblRecipeName
            // 
            lblRecipeName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblRecipeName.AutoSize = true;
            lblRecipeName.Location = new Point(3, 50);
            lblRecipeName.Name = "lblRecipeName";
            lblRecipeName.Size = new Size(194, 28);
            lblRecipeName.TabIndex = 0;
            lblRecipeName.Text = "Recipe Name";
            // 
            // txtRecipeName
            // 
            tblHeader.SetColumnSpan(txtRecipeName, 2);
            txtRecipeName.Dock = DockStyle.Left;
            txtRecipeName.Location = new Point(203, 47);
            txtRecipeName.Name = "txtRecipeName";
            txtRecipeName.Size = new Size(500, 34);
            txtRecipeName.TabIndex = 1;
            // 
            // lblCuisineName
            // 
            lblCuisineName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblCuisineName.AutoSize = true;
            lblCuisineName.Location = new Point(3, 90);
            lblCuisineName.Name = "lblCuisineName";
            lblCuisineName.Size = new Size(194, 28);
            lblCuisineName.TabIndex = 2;
            lblCuisineName.Text = "Cuisine Name";
            // 
            // lstCuisineName
            // 
            tblHeader.SetColumnSpan(lstCuisineName, 2);
            lstCuisineName.Dock = DockStyle.Left;
            lstCuisineName.FormattingEnabled = true;
            lstCuisineName.Location = new Point(203, 87);
            lstCuisineName.Name = "lstCuisineName";
            lstCuisineName.Size = new Size(500, 36);
            lstCuisineName.BackColor = SystemColors.Window;
            lstCuisineName.TabIndex = 3;
            // 
            // lblCalories
            // 
            lblCalories.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblCalories.AutoSize = true;
            lblCalories.Location = new Point(3, 130);
            lblCalories.Name = "lblCalories";
            lblCalories.Size = new Size(194, 28);
            lblCalories.TabIndex = 4;
            lblCalories.Text = "Calories";
            // 
            // txtCalories
            // 
            tblHeader.SetColumnSpan(txtCalories, 2);
            txtCalories.Dock = DockStyle.Left;
            txtCalories.Location = new Point(203, 127);
            txtCalories.Name = "txtCalories";
            txtCalories.Size = new Size(500, 34);
            txtCalories.TabIndex = 5;
            // 
            // lblRecipeStatus
            // 
            lblRecipeStatus.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblRecipeStatus.AutoSize = true;
            lblRecipeStatus.Location = new Point(3, 170);
            lblRecipeStatus.Name = "lblRecipeStatus";
            lblRecipeStatus.Size = new Size(194, 28);
            lblRecipeStatus.TabIndex = 6;
            lblRecipeStatus.Text = "Recipe Status";
            // 
            // txtRecipeStatus
            // 
            tblHeader.SetColumnSpan(txtRecipeStatus, 2);
            txtRecipeStatus.Dock = DockStyle.Left;
            txtRecipeStatus.Location = new Point(203, 167);
            txtRecipeStatus.Name = "txtRecipeStatus";
            txtRecipeStatus.ReadOnly = true;
            txtRecipeStatus.Size = new Size(500, 34);
            txtRecipeStatus.TabIndex = 7;
            // 
            // lblDrafted
            // 
            lblDrafted.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblDrafted.AutoSize = true;
            lblDrafted.Location = new Point(3, 210);
            lblDrafted.Name = "lblDrafted";
            lblDrafted.Size = new Size(194, 28);
            lblDrafted.TabIndex = 8;
            lblDrafted.Text = "Drafted";
            // 
            // txtDrafted
            // 
            txtDrafted.ReadOnly = true;
            tblHeader.SetColumnSpan(txtDrafted, 2);
            txtDrafted.Dock = DockStyle.Left;
            txtDrafted.Location = new Point(203, 207);
            txtDrafted.Name = "txtDrafted";
            txtDrafted.Size = new Size(500, 34);
            txtDrafted.TabIndex = 9;
            // 
            // lblCaptionPublished
            // 
            lblCaptionPublished.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblCaptionPublished.AutoSize = true;
            lblCaptionPublished.Location = new Point(3, 250);
            lblCaptionPublished.Name = "lblCaptionPublished";
            lblCaptionPublished.Size = new Size(194, 28);
            lblCaptionPublished.TabIndex = 10;
            lblCaptionPublished.Text = "Published";
            // 
            // txtPublished
            // 
            txtPublished.ReadOnly = true;
            txtPublished.BorderStyle = BorderStyle.FixedSingle;
            tblHeader.SetColumnSpan(txtPublished, 2);
            txtPublished.Dock = DockStyle.Left;
            txtPublished.Location = new Point(203, 244);
            txtPublished.Name = "txtPublished";
            txtPublished.TabIndex = 11;
            txtPublished.Size = new Size(500, 34);
            // 
            // lblCaptionArchived
            // 
            lblCaptionArchived.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblCaptionArchived.AutoSize = true;
            lblCaptionArchived.Location = new Point(3, 290);
            lblCaptionArchived.Name = "lblCaptionArchived";
            lblCaptionArchived.Size = new Size(194, 28);
            lblCaptionArchived.TabIndex = 12;
            lblCaptionArchived.Text = "Archived";
            // 
            // txtArchived
            // 
            txtArchived.ReadOnly = true;
            txtArchived.BorderStyle = BorderStyle.FixedSingle;
            tblHeader.SetColumnSpan(txtArchived, 2);
            txtArchived.Dock = DockStyle.Left;
            txtArchived.Location = new Point(203, 284);
            txtArchived.Name = "txtArchived";
            txtArchived.TabIndex = 13;
            txtArchived.Size = new Size(500, 34);
            // 
            // lblUserName
            // 
            lblUserName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblUserName.AutoSize = true;
            lblUserName.Location = new Point(3, 330);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(194, 28);
            lblUserName.TabIndex = 14;
            lblUserName.Text = "User Name";
            // 
            // lstUserName
            // 
            tblHeader.SetColumnSpan(lstUserName, 2);
            lstUserName.Dock = DockStyle.Left;
            lstUserName.FormattingEnabled = true;
            lstUserName.Location = new Point(203, 327);
            lstUserName.Name = "lstUserName";
            lstUserName.Size = new Size(500, 36);
            lstUserName.TabIndex = 15;
            // 
            // tbChildRecords
            // 
            tbChildRecords.Controls.Add(tbIngredients);
            tbChildRecords.Controls.Add(tbSteps);
            tbChildRecords.Dock = DockStyle.Fill;
            tbChildRecords.Location = new Point(0, 364);
            tbChildRecords.Name = "tbChildRecords";
            tbChildRecords.SelectedIndex = 0;
            tbChildRecords.Size = new Size(782, 189);
            tbChildRecords.TabIndex = 1;
            // 
            // tbIngredients
            // 
            tbIngredients.Controls.Add(tblIngredients);
            tbIngredients.Location = new Point(4, 29);
            tbIngredients.Name = "tbIngredients";
            tbIngredients.Padding = new Padding(3);
            tbIngredients.Size = new Size(774, 156);
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
            tblIngredients.Size = new Size(768, 150);
            tblIngredients.TabIndex = 0;
            // 
            // btnSaveIngredients
            // 
            btnSaveIngredients.AutoSize = true;
            btnSaveIngredients.Location = new Point(3, 3);
            btnSaveIngredients.Name = "btnSaveIngredients";
            btnSaveIngredients.Size = new Size(54, 30);
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
            gIngredients.Size = new Size(762, 108);
            gIngredients.TabIndex = 1;
            // 
            // tbSteps
            // 
            tbSteps.Controls.Add(tblSteps);
            tbSteps.Location = new Point(4, 29);
            tbSteps.Name = "tbSteps";
            tbSteps.Padding = new Padding(3);
            tbSteps.Size = new Size(774, 156);
            tbSteps.TabIndex = 1;
            tbSteps.Text = "Steps";
            tbSteps.UseVisualStyleBackColor = true;
            // 
            // tblSteps
            // 
            tblSteps.ColumnCount = 1;
            tblSteps.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblSteps.Controls.Add(btnSaveSteps, 0, 0);
            tblSteps.Controls.Add(gSteps, 0, 1);
            tblSteps.Dock = DockStyle.Fill;
            tblSteps.Location = new Point(3, 3);
            tblSteps.Name = "tblSteps";
            tblSteps.RowCount = 2;
            tblSteps.RowStyles.Add(new RowStyle());
            tblSteps.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblSteps.Size = new Size(768, 150);
            tblSteps.TabIndex = 0;
            // 
            // btnSaveSteps
            // 
            btnSaveSteps.AutoSize = true;
            btnSaveSteps.Location = new Point(3, 3);
            btnSaveSteps.Name = "btnSaveSteps";
            btnSaveSteps.Size = new Size(54, 30);
            btnSaveSteps.TabIndex = 0;
            btnSaveSteps.Text = "Save";
            btnSaveSteps.UseVisualStyleBackColor = true;
            // 
            // gSteps
            // 
            gSteps.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gSteps.Dock = DockStyle.Fill;
            gSteps.Location = new Point(3, 39);
            gSteps.Name = "gSteps";
            gSteps.RowHeadersWidth = 51;
            gSteps.RowTemplate.Height = 29;
            gSteps.Size = new Size(762, 108);
            gSteps.TabIndex = 1;
            // 
            // frmRecipeInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 553);
            Controls.Add(tbChildRecords);
            Controls.Add(tblHeader);
            Name = "frmRecipeInfo";
            Text = "Recipe Info";
            tblHeader.ResumeLayout(false);
            tblHeader.PerformLayout();
            tbChildRecords.ResumeLayout(false);
            tbIngredients.ResumeLayout(false);
            tblIngredients.ResumeLayout(false);
            tblIngredients.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gIngredients).EndInit();
            tbSteps.ResumeLayout(false);
            tblSteps.ResumeLayout(false);
            tblSteps.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gSteps).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
    }
}
