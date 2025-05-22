using HeartyHearthWinForm.Properties;
using System.Configuration;

namespace HeartyHearthWinForm
{
    public partial class frmLogin : Form
    {
        bool loginsuccess = false;
        public frmLogin()
        {
            InitializeComponent();
            btnLogin.Click += BtnLogin_Click;
            btnCancel.Click += BtnCancel_Click;

        }
        public bool ShowLogin()
        {
#if DEBUG
            this.Text = this.Text + " - DEV";
#endif
            txtUserId.Text = Settings.Default.userid;
            this.ShowDialog();
            return loginsuccess;
        }
        private void BtnLogin_Click(object? sender, EventArgs e)
        {
            try
            {
                string connstringkey = "";
#if DEBUG
                connstringkey = "devconn";
                this.Text = this.Text + " DEV";
#else 
                connstringkey = "liveconn";
#endif
                string connstring = ConfigurationManager.ConnectionStrings[connstringkey].ConnectionString;
                DBManager.SetConnectionString(connstring, true, txtUserId.Text, txtPassword.Text);
                loginsuccess = true;
                Settings.Default.userid = txtUserId.Text;
                Settings.Default.Save();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Login. Try again.", Application.ProductName);
            }
        }
        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
