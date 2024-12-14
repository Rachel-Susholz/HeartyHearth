using System.Data;
using CPUFramework;
namespace HeartyHearthWinForm
{
    public partial class frmRecipeInfo : Form
    {
        DataTable dtRecipe;
        public frmRecipeInfo()
        {
            InitializeComponent();
            //btnSave.Click += BtnSave_Click;
            //btnDelete.Click += BtnDelete_Click;
        }
        public void ShowForm(int recipeid)
        {
            string sql = "select r.RecipeName, ct.CuisineName, r.Calories, r.ImagePath, r.RecipeStatus, r.Drafted, r.Archived, " +
            "r.Published, r.Archived, sm.FirstName, sm.LastName, sm.UserName " +
            "from Recipe r join CuisineType ct on r.CuisineId = ct.CuisineId join StaffMember sm on r.StaffMemberId = sm.StaffMemberId where r.RecipeId = " + recipeid.ToString();
            dtRecipe = SQLUtility.GetDataTable(sql);
            txtRecipeName.DataBindings.Add("Text", dtRecipe, "RecipeName");
            txtCuisineName.DataBindings.Add("Text", dtRecipe, "CuisineName");
            txtCalories.DataBindings.Add("Text", dtRecipe, "Calories");
            lblRecipeStatus.DataBindings.Add("Text", dtRecipe, "RecipeStatus");
            txtDrafted.DataBindings.Add("Text", dtRecipe, "Drafted");
            txtPublished.DataBindings.Add("Text", dtRecipe, "Published");
            txtArchived.DataBindings.Add("Text", dtRecipe, "Archived");
            txtFirstName.DataBindings.Add("Text", dtRecipe, "FirstName");
            txtLastName.DataBindings.Add("Text", dtRecipe, "LastName");
            txtUserName.DataBindings.Add("Text", dtRecipe, "UserName");
            this.Show();
        }

        /*private void Save()
        {
            SQLUtility.DebugPrintDataTable(dtRecipe);

        }

        private void Delete()
        {

        }
        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            Delete();
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            Save();
        }
        */
    }
}
