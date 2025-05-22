namespace HeartyHearthWinForm
{
    partial class frmLogin
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
            lblUserId = new Label();
            lblPassword = new Label();
            txtUserId = new TextBox();
            txtPassword = new TextBox();
            tblButtons = new TableLayoutPanel();
            btnLogin = new Button();
            btnCancel = new Button();
            tblMain.SuspendLayout();
            tblButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle());
            tblMain.ColumnStyles.Add(new ColumnStyle());
            tblMain.Controls.Add(lblUserId, 0, 0);
            tblMain.Controls.Add(lblPassword, 0, 1);
            tblMain.Controls.Add(txtUserId, 1, 0);
            tblMain.Controls.Add(txtPassword, 1, 1);
            tblMain.Controls.Add(tblButtons, 1, 2);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 4;
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblMain.Size = new Size(654, 150);
            tblMain.TabIndex = 0;
            
            // 
            // lblUserId
            // 
            lblUserId.AutoSize = true;
            lblUserId.Location = new Point(3, 0);
            lblUserId.Name = "lblUserId";
            lblUserId.Size = new Size(108, 28);
            lblUserId.TabIndex = 0;
            lblUserId.Text = "User Name";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(3, 40);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(93, 28);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Password";
            // 
            // txtUserId
            // 
            txtUserId.Dock = DockStyle.Fill;
            txtUserId.Location = new Point(117, 3);
            txtUserId.Name = "txtUserId";
            txtUserId.Size = new Size(534, 34);
            txtUserId.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Dock = DockStyle.Fill;
            txtPassword.Location = new Point(117, 43);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(534, 34);
            txtPassword.TabIndex = 2;
            // 
            // tblButtons
            // 
            tblButtons.Anchor = AnchorStyles.Right;
            tblButtons.AutoSize = true;
            tblButtons.ColumnCount = 2;
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblButtons.Controls.Add(btnLogin, 0, 0);
            tblButtons.Controls.Add(btnCancel, 1, 0);
            tblButtons.Location = new Point(451, 83);
            tblButtons.Name = "tblButtons";
            tblButtons.RowCount = 1;
            tblButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblButtons.Size = new Size(200, 44);
            tblButtons.TabIndex = 4;
            // 
            // btnLogin
            // 
            btnLogin.AutoSize = true;
            btnLogin.Location = new Point(3, 3);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(94, 38);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "OK";
            btnLogin.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.Location = new Point(103, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 38);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(654, 150);
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4, 4, 4, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmLogin";
            Text = "HeartyHearth Login";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tblButtons.ResumeLayout(false);
            tblButtons.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Label lblUserId;
        private Label lblPassword;
        private TextBox txtUserId;
        private TextBox txtPassword;
        private TableLayoutPanel tblButtons;
        private Button btnLogin;
        private Button btnCancel;
    }
}