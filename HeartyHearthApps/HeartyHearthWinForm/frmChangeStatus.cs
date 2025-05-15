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

            btnDraft.Click += btnDraft_Click;
            btnPublish.Click += btnPublish_Click;
            btnArchive.Click += btnArchive_Click;

            Load += (s, e) => LoadRecipeData();
        }

        void LoadRecipeData()
        {
            dtRecipe = recipe.Load(RecipeId);
            if (dtRecipe.Rows.Count == 0)
            {
                MessageBox.Show("Recipe not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            var row = dtRecipe.Rows[0];
            lblRecipeName.Text = row["RecipeName"].ToString();

            lblDrafted.Text = row["Drafted"] == DBNull.Value
                               ? "N/A"
                               : Convert.ToDateTime(row["Drafted"]).ToShortDateString();

            lblPublished.Text = row["Published"] == DBNull.Value
                               ? "N/A"
                               : Convert.ToDateTime(row["Published"]).ToShortDateString();

            lblArchived.Text = row["Archived"] == DBNull.Value
                               ? "N/A"
                               : Convert.ToDateTime(row["Archived"]).ToShortDateString();

            var status = row["RecipeStatus"].ToString();
            lblCurrentStatus.Text = "Current Status: " + status;

            btnDraft.Enabled = !status.Equals("Drafted", StringComparison.OrdinalIgnoreCase);
            btnPublish.Enabled = !status.Equals("Published", StringComparison.OrdinalIgnoreCase);
            btnArchive.Enabled = !status.Equals("Archived", StringComparison.OrdinalIgnoreCase);
        }

        void AttemptStatusChangeAndClose(string newStatus)
        {
            if (MessageBox.Show(
                    $"Are you sure you want to change this recipe to {newStatus}?",
                    "Confirm Status Change",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                ) != DialogResult.Yes) return;

            try
            {
                recipe.ChangeStatus(RecipeId, newStatus);
                MessageBox.Show(
                    "Status changed successfully",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                RecipeEvents.RaiseRecipeStatusChanged();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDraft_Click(object sender, EventArgs e)
            => AttemptStatusChangeAndClose("Drafted");

        private void btnPublish_Click(object sender, EventArgs e)
            => AttemptStatusChangeAndClose("Published");

        private void btnArchive_Click(object sender, EventArgs e)
            => AttemptStatusChangeAndClose("Archived");
    }
}
