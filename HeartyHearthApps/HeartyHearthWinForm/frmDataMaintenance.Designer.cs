namespace HeartyHearthWinForm
{
    partial class frmDataMaintenance
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
            btnSave = new Button();
            gData = new DataGridView();
            pnlOptionButtons = new FlowLayoutPanel();
            optUsers = new RadioButton();
            optCuisines = new RadioButton();
            optIngredients = new RadioButton();
            optMeasurements = new RadioButton();
            optCourses = new RadioButton();
            tblMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gData).BeginInit();
            pnlOptionButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.5336056F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 72.46639F));
            tblMain.Controls.Add(btnSave, 1, 1);
            tblMain.Controls.Add(gData, 1, 0);
            tblMain.Controls.Add(pnlOptionButtons, 0, 0);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 2;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.Size = new Size(800, 450);
            tblMain.TabIndex = 0;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.AutoSize = true;
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.Location = new Point(703, 409);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 38);
            btnSave.TabIndex = 0;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // gData
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            gData.DefaultCellStyle = dataGridViewCellStyle2;
            gData.Dock = DockStyle.Fill;
            gData.Location = new Point(223, 3);
            gData.Name = "gData";
            gData.RowHeadersWidth = 51;
            gData.RowTemplate.Height = 29;
            gData.Size = new Size(574, 400);
            gData.TabIndex = 1;
            // 
            // pnlOptionButtons
            // 
            pnlOptionButtons.Controls.Add(optUsers);
            pnlOptionButtons.Controls.Add(optCuisines);
            pnlOptionButtons.Controls.Add(optIngredients);
            pnlOptionButtons.Controls.Add(optMeasurements);
            pnlOptionButtons.Controls.Add(optCourses);
            pnlOptionButtons.Dock = DockStyle.Fill;
            pnlOptionButtons.FlowDirection = FlowDirection.TopDown;
            pnlOptionButtons.Location = new Point(3, 3);
            pnlOptionButtons.Name = "pnlOptionButtons";
            pnlOptionButtons.Size = new Size(214, 400);
            pnlOptionButtons.TabIndex = 2;
            // 
            // optUsers
            // 
            optUsers.AutoSize = true;
            optUsers.Checked = true;
            optUsers.Location = new Point(3, 3);
            optUsers.Name = "optUsers";
            optUsers.Size = new Size(65, 24);
            optUsers.TabIndex = 0;
            optUsers.TabStop = true;
            optUsers.Text = "Users";
            optUsers.UseVisualStyleBackColor = true;
            // 
            // optCuisines
            // 
            optCuisines.AutoSize = true;
            optCuisines.Location = new Point(3, 33);
            optCuisines.Name = "optCuisines";
            optCuisines.Size = new Size(83, 24);
            optCuisines.TabIndex = 1;
            optCuisines.Text = "Cuisines";
            optCuisines.UseVisualStyleBackColor = true;
            // 
            // optIngredients
            // 
            optIngredients.AutoSize = true;
            optIngredients.Location = new Point(3, 63);
            optIngredients.Name = "optIngredients";
            optIngredients.Size = new Size(104, 24);
            optIngredients.TabIndex = 2;
            optIngredients.Text = "Ingredients";
            optIngredients.UseVisualStyleBackColor = true;
            // 
            // optMeasurements
            // 
            optMeasurements.AutoSize = true;
            optMeasurements.Location = new Point(3, 93);
            optMeasurements.Name = "optMeasurements";
            optMeasurements.Size = new Size(126, 24);
            optMeasurements.TabIndex = 3;
            optMeasurements.Text = "Measurements";
            optMeasurements.UseVisualStyleBackColor = true;
            // 
            // optCourses
            // 
            optCourses.AutoSize = true;
            optCourses.Location = new Point(3, 123);
            optCourses.Name = "optCourses";
            optCourses.Size = new Size(81, 24);
            optCourses.TabIndex = 4;
            optCourses.Text = "Courses";
            optCourses.UseVisualStyleBackColor = true;
            // 
            // frmDataMaintenance
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tblMain);
            Name = "frmDataMaintenance";
            Text = "Hearty Hearth - Data Maintenance";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gData).EndInit();
            pnlOptionButtons.ResumeLayout(false);
            pnlOptionButtons.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Button btnSave;
        private DataGridView gData;
        private FlowLayoutPanel pnlOptionButtons;
        private RadioButton optUsers;
        private RadioButton optCuisines;
        private RadioButton optIngredients;
        private RadioButton optMeasurements;
        private RadioButton optCourses;
    }
}