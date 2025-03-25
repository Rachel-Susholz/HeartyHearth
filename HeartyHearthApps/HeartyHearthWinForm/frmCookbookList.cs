namespace HeartyHearthWinForm
{
    public partial class frmCookbookList : Form
    {
        public frmCookbookList()
        {
            InitializeComponent();
            this.Load += FrmCookbookList_Load;
            btnNewCookbook.Click += BtnNewCookbook_Click;
            gCookbookList.CellDoubleClick += gCookbookList_CellDoubleClick;
        }

        private void FrmCookbookList_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
            try
            {
                DataTable dt = cookbook.GetCookbookList();
                ListHelper.LoadGrid(gCookbookList, dt, "CookbookId", new Dictionary<string, string>
                {
                    { "CookbookName", "Cookbook Name" },
                    { "Author", "Author" },
                    { "NumRecipes", "Recipes" },
                    { "Price", "Price" }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading cookbooks: " + ex.Message);
            }
        }

        private void BtnNewCookbook_Click(object sender, EventArgs e)
        {
            ((frmMain)this.MdiParent).OpenForm(typeof(frmCookbookInfo), 0);
        }

        private void gCookbookList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int cookbookId = WindowsFormsUtility.GetIdFromGrid(gCookbookList, e.RowIndex, "CookbookId");
                ((frmMain)this.MdiParent).OpenForm(typeof(frmCookbookInfo), cookbookId);
            }
        }
    }
}
