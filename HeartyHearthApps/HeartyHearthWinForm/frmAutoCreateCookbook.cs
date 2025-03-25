using System.Data.SqlClient;

namespace HeartyHearthWinForm
{
    public partial class frmAutoCreateCookbook : Form
    {
        public frmAutoCreateCookbook()
        {
            InitializeComponent();
            this.Load += frmAutoCreateCookbook_Load;
            btnCreateCookbook.Click += BtnCreateCookbook_Click;
        }

        private void frmAutoCreateCookbook_Load(object sender, EventArgs e)
        {
            DataTable dtUsers = recipe.GetUserList();
            cbxUser.DataSource = dtUsers;
            cbxUser.DisplayMember = "UserName";
            cbxUser.ValueMember = "StaffMemberId";
        }

        private void BtnCreateCookbook_Click(object sender, EventArgs e)
        {
            if (cbxUser.SelectedValue == null)
            {
                MessageBox.Show("Please select a user.", "Auto Create Cookbook", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int staffMemberId = Convert.ToInt32(cbxUser.SelectedValue);
            try
            {
                int newCookbookId = AutoCreateCookbookUsingProc(staffMemberId);

                if (this.MdiParent is frmMain mainForm)
                {
                    mainForm.OpenForm(typeof(frmCookbookInfo), newCookbookId);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                string parsedError = SQLUtility.ParseConstraintMessage(ex.Message);
                MessageBox.Show("Error auto-creating cookbook: " + parsedError, "Auto Create Cookbook", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int AutoCreateCookbookUsingProc(int staffMemberId)
        {
            SqlCommand cmd = SQLUtility.GetSqlCommand("AutoCreateCookbook");
            SQLUtility.SetParamValue(cmd, "@StaffMemberId", staffMemberId);

            if (cmd.Parameters.Contains("@NewCookbookId"))
            {
                cmd.Parameters["@NewCookbookId"].Value = DBNull.Value;
            }
            using (SqlConnection conn = new SqlConnection(SQLUtility.ConnectionString))
            {
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            return Convert.ToInt32(cmd.Parameters["@NewCookbookId"].Value);
        }
    }
}
