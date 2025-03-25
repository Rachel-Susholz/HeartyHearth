namespace HeartyHearthWinForm
{
    public partial class frmChangeStatus : Form
    {
        private int RecipeId;
        private DataTable dtRecipe;

        public frmChangeStatus(int recipeId)
        {
            InitializeComponent();
            RecipeId = recipeId;
            this.Load += (s, e) => LoadRecipeData();
        }

        void LoadRecipeData()
        {
            dtRecipe = recipe.Load(RecipeId);
            if (dtRecipe.Rows.Count == 0)
            {
                MessageBox.Show("Recipe not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            DataRow row = dtRecipe.Rows[0];
            lblRecipeName.Text = row["RecipeName"].ToString();
            lblDrafted.Text = "Drafted: " +
                (row["Drafted"] == DBNull.Value ? "N/A" : Convert.ToDateTime(row["Drafted"]).ToShortDateString());
            lblPublished.Text = "Published: " +
                (row["Published"] == DBNull.Value ? "N/A" : Convert.ToDateTime(row["Published"]).ToShortDateString());
            lblArchived.Text = "Archived: " +
                (row["Archived"] == DBNull.Value ? "N/A" : Convert.ToDateTime(row["Archived"]).ToShortDateString());

            string currentStatus = row["RecipeStatus"].ToString();
            lblCurrentStatus.Text = "Current Status: " + currentStatus;
            btnDraft.Enabled = !currentStatus.Equals("Drafted", StringComparison.OrdinalIgnoreCase);
            btnPublish.Enabled = !currentStatus.Equals("Published", StringComparison.OrdinalIgnoreCase);
            btnArchive.Enabled = !currentStatus.Equals("Archived", StringComparison.OrdinalIgnoreCase);
        }

        void AttemptStatusChangeAndClose(string newstatus)
        {
            if (MessageBox.Show($"Are you sure you want to change this recipe to {newstatus}?",
                "Confirm Status Change", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            try
            {
                recipe.ChangeStatus(RecipeId, newstatus);
                MessageBox.Show("Status changed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RecipeEvents.RaiseRecipeStatusChanged();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDraft_Click(object sender, EventArgs e)
        {
            AttemptStatusChangeAndClose("Drafted");
        }
        private void btnPublish_Click(object sender, EventArgs e)
        {
            AttemptStatusChangeAndClose("Published");
        }
        private void btnArchive_Click(object sender, EventArgs e)
        {
            AttemptStatusChangeAndClose("Archived");
        }
    }
}
