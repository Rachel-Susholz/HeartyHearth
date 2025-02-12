namespace HeartyHearthWinForm
{
    public partial class frmSearch : Form
    {
        public frmSearch()
        {
            InitializeComponent();
            btnSearch.Click += BtnSearch_Click;
            btnNew.Click += BtnNew_Click;
            gRecipes.CellDoubleClick += GRecipes_CellDoubleClick;
            txtRecipe.KeyDown += TxtRecipe_KeyDown;
            gRecipes.KeyDown += GRecipes_KeyDown;    
        }


        private void GRecipes_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            ShowRecipeForm(e.RowIndex);
        }
        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            DoSearch();
        }

        private void BtnNew_Click(object? sender, EventArgs e)
        {
            ShowRecipeForm(-1); 
        }

        private void TxtRecipe_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DoSearch();
            }
        }


        private void GRecipes_KeyDown(object? sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && gRecipes.SelectedRows.Count > 0)
            {
                ShowRecipeForm(gRecipes.SelectedRows[0].Index);
                e.SuppressKeyPress = true;
            }
        }
        private void ShowRecipeForm(int rowindex)
        {
            int id = 0;
            if (rowindex > -1)
            {
                id = WindowsFormsUtility.GetIdFromGrid(gRecipes, rowindex, "RecipeId");
            }
            if (this.MdiParent != null && this.MdiParent is frmMain)
            {
                ((frmMain)this.MdiParent).OpenForm(typeof(frmRecipeInfo), id);
            } 
        }

        private void DoSearch()
        {
            SearchForRecipe(txtRecipe.Text);
        }
        private void SearchForRecipe(string recipename)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = recipe.SearchRecipes(recipename);
                gRecipes.DataSource = dt;
                WindowsFormsUtility.FormatGridForSearchResults(gRecipes, "Recipe");
                if (gRecipes.Rows.Count > 0)
                {
                    gRecipes.Focus();
                    gRecipes.Rows[0].Selected = true;
                }
            }
            catch
            {
                throw;
            } 
            finally
            {
                this.Cursor = Cursors.Default;
            }
           
        }

       
    }
}
