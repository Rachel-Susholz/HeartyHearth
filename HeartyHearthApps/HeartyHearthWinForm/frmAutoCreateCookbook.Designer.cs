namespace HeartyHearthWinForm
{
    partial class frmAutoCreateCookbook
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
            btnCreateCookbook = new Button();
            cbxUser = new ComboBox();
            tblMain.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.Controls.Add(btnCreateCookbook, 1, 0);
            tblMain.Controls.Add(cbxUser, 0, 0);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 1;
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.Size = new Size(800, 151);
            tblMain.TabIndex = 0;
            // 
            // btnCreateCookbook
            // 
            btnCreateCookbook.Anchor = AnchorStyles.None;
            btnCreateCookbook.AutoSize = true;
            btnCreateCookbook.Location = new Point(533, 60);
            btnCreateCookbook.Name = "btnCreateCookbook";
            btnCreateCookbook.Size = new Size(134, 30);
            btnCreateCookbook.TabIndex = 0;
            btnCreateCookbook.Text = "Create Cookbook";
            btnCreateCookbook.UseVisualStyleBackColor = true;
            // 
            // cbxUser
            // 
            cbxUser.Anchor = AnchorStyles.None;
            cbxUser.FormattingEnabled = true;
            cbxUser.Location = new Point(124, 58);
            cbxUser.Name = "cbxUser";
            cbxUser.Size = new Size(151, 28);
            cbxUser.TabIndex = 1;
            // 
            // frmAutoCreateCookbook
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 151);
            Controls.Add(tblMain);
            Name = "frmAutoCreateCookbook";
            Text = "frmAutoCreateCookbook";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Button btnCreateCookbook;
        private ComboBox cbxUser;
    }
}