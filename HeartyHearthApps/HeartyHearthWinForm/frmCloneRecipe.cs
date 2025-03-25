using System.Data.SqlClient;

namespace HeartyHearthWinForm
{
    public partial class frmCloneRecipe : Form
    {
        public frmCloneRecipe()
        {
            InitializeComponent();
            this.Load += frmCloneRecipe_Load;
            btnClone.Click += BtnClone_Click;
        }

        private void frmCloneRecipe_Load(object sender, EventArgs e)
        {
            DataTable dtRecipes = recipe.GetRecipeList();
            cbxRecipes.DataSource = dtRecipes;
            cbxRecipes.DisplayMember = "RecipeName";
            cbxRecipes.ValueMember = "RecipeId";
        }

        private void BtnClone_Click(object sender, EventArgs e)
        {
            if (cbxRecipes.SelectedValue == null)
            {
                MessageBox.Show("Please select a recipe to clone.", "Clone Recipe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int baseRecipeId = Convert.ToInt32(cbxRecipes.SelectedValue);
            try
            {
                int newRecipeId = CloneRecipeUsingProc(baseRecipeId);
                if (this.MdiParent is frmMain mainForm)
                {
                    frmRecipeInfo recipeInfoForm = new frmRecipeInfo(newRecipeId);
                    recipeInfoForm.IsFreshClone = true;
                    recipeInfoForm.MdiParent = mainForm;
                    recipeInfoForm.Show();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cloning recipe: " + ex.Message, "Clone Recipe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int CloneRecipeUsingProc(int baseRecipeId)
        {
            int newRecipeId = 0;
            string message = string.Empty;
            SqlCommand cmd = SQLUtility.GetSqlCommand("CloneARecipe");

            cmd.Parameters["@BaseRecipeId"].Value = baseRecipeId;

            if (cmd.Parameters.Contains("@RecipeId"))
                cmd.Parameters["@RecipeId"].Value = DBNull.Value;
            if (cmd.Parameters.Contains("@Message"))
                cmd.Parameters["@Message"].Value = DBNull.Value;

            SQLUtility.ExecuteSQL(cmd);

            object recipeIdObj = cmd.Parameters["@RecipeId"].Value;
            object messageObj = cmd.Parameters["@Message"].Value;

            if (recipeIdObj == DBNull.Value)
            {
                string errMsg = messageObj != DBNull.Value
                    ? SQLUtility.ParseConstraintMessage(messageObj.ToString())
                    : "Stored proc did not return a new RecipeId.";
                throw new Exception("Clone failed: " + errMsg);
            }

            newRecipeId = Convert.ToInt32(recipeIdObj);
            message = messageObj != DBNull.Value ? messageObj.ToString() : "";

            if (newRecipeId <= 0)
            {
                string parsedMessage = SQLUtility.ParseConstraintMessage(message);
                throw new Exception("Clone failed: " + parsedMessage);
            }

            return newRecipeId;
        }
    }
}
