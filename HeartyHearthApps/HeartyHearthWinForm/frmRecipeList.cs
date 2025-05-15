namespace HeartyHearthWinForm
{
    public partial class frmRecipeList : Form
    {
        public frmRecipeList()
        {
            InitializeComponent();
            this.Load += (s, e) => LoadGrid();
            gRecipeList.CellDoubleClick += gRecipeList_CellDoubleClick;
            btnNewRecipe.Click += BtnNewRecipe_Click;
        }

        private void LoadGrid()
        {
            DataTable dt = recipe.GetRecipeList();
            ListHelper.LoadGrid(gRecipeList, dt, "RecipeId", new Dictionary<string, string>
            {
                { "RecipeName", "Recipe Name" },
                { "RecipeStatus", "Status" },
                { "UserName", "User" },
                { "Calories", "Calories" },
                { "NumIngredients","Num Ingredients" }
            });
        }

        private void gRecipeList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int recipeId = WindowsFormsUtility.GetIdFromGrid(gRecipeList, e.RowIndex, "RecipeId");
            if (this.MdiParent is frmMain mainForm)
                mainForm.OpenForm(typeof(frmRecipeInfo), recipeId);
        }

        private void BtnNewRecipe_Click(object sender, EventArgs e)
        {
            if (this.MdiParent is frmMain mainForm)
                mainForm.OpenForm(typeof(frmRecipeInfo), 0);
        }
    }
}
