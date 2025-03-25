
namespace HeartyHearthWinForm
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            mnuDashboard.Click += MnuDashboard_Click;
            mnuRecipesList.Click += MnuRecipesList_Click;
            mnuNewRecipe.Click += MnuNewRecipe_Click;
            mnuCloneRecipe.Click += MnuCloneRecipe_Click;
            mnuMealsList.Click += MnuMealsList_Click;
            mnuCookbookList.Click += MnuCookbookList_Click;
            mnuNewCookbook.Click += MnuNewCookbook_Click;
            mnuAutoCreate.Click += MnuAutoCreate_Click;
            mnuEditData.Click += MnuEditData_Click;
            mnuWindowTile.Click += MnuWindowTile_Click;
            mnuWindowStack.Click += MnuWindowStack_Click;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            OpenForm(typeof(frmDashboard));
        }

        public void OpenForm(Type frmtype, int pkvalue = 0)
        {
            if (WindowsFormsUtility.IsFormOpen(frmtype, pkvalue))
                return;

            Form newfrm = null;
            if (frmtype == typeof(frmCookbookInfo))
                newfrm = new frmCookbookInfo(pkvalue);
            else if (frmtype == typeof(frmRecipeInfo))
                newfrm = new frmRecipeInfo(pkvalue);
            else if (frmtype == typeof(frmRecipeList))
                newfrm = new frmRecipeList();
            else if (frmtype == typeof(frmMealList))
                newfrm = new frmMealList();
            else if (frmtype == typeof(frmCookbookList))
                newfrm = new frmCookbookList();
            else if (frmtype == typeof(frmDashboard))
                newfrm = new frmDashboard(this);
            else if (frmtype == typeof(frmDataMaintenance))
                newfrm = new frmDataMaintenance();
            else if (frmtype == typeof(frmCloneRecipe))
                newfrm = new frmCloneRecipe();
            else if (frmtype == typeof(frmAutoCreateCookbook))
                newfrm = new frmAutoCreateCookbook();
            else if (frmtype == typeof(frmChangeStatus))
                newfrm = new frmChangeStatus(pkvalue);

            if (newfrm != null)
            {
                newfrm.Tag = pkvalue;
                newfrm.MdiParent = this;
                newfrm.WindowState = FormWindowState.Maximized;
                newfrm.FormClosed += Frm_FormClosed;
                newfrm.Show();
                WindowsFormsUtility.SetUpNav(tsMain);
            }
        }

        public void UpdateNavigation()
        {
            WindowsFormsUtility.SetUpNav(tsMain);
        }

        private void Frm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            WindowsFormsUtility.SetUpNav(tsMain);
        }

        private void MnuDashboard_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmDashboard));
        }

        private void MnuRecipesList_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmRecipeList));
        }
        private void MnuNewRecipe_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmRecipeInfo), 0);
        }

        private void MnuCloneRecipe_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmCloneRecipe));
        }
        private void MnuMealsList_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmMealList));
        }
        private void MnuCookbookList_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmCookbookList));
        }
        private void MnuNewCookbook_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmCookbookInfo), 0);
        }
        private void MnuAutoCreate_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmAutoCreateCookbook));
        }

        private void MnuEditData_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmDataMaintenance));
        }

        private void MnuWindowStack_Click(object? sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void MnuWindowTile_Click(object? sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

    }
}

