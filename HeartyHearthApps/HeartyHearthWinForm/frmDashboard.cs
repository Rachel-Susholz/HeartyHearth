namespace HeartyHearthWinForm
{
    public partial class frmDashboard : Form
    {
        private frmMain mainForm;
        public frmDashboard(frmMain parentForm)
        {
            InitializeComponent();
            mainForm = parentForm;
            btnRecipeList.Click += BtnRecipeList_Click;
            btnMealList.Click += BtnMealList_Click;
            btnCookbookList.Click += BtnCookbookList_Click;
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            LoadDashboardCounts();
        }

        private void LoadDashboardCounts()
        {
            DataTable dt = recipe.GetDashboardCounts();

            DataTable dashboardTable = new DataTable();
            dashboardTable.Columns.Add("Type", typeof(string));
            dashboardTable.Columns.Add("Number", typeof(int));

            gDashboard.Rows.Clear();

            gDashboard.DataSource = dashboardTable;

            if (dt.Rows.Count > 0)
            {
                dashboardTable.Rows.Add("Recipes", dt.Rows[0]["NumRecipes"]);
                dashboardTable.Rows.Add("Meals", dt.Rows[0]["NumMeals"]);
                dashboardTable.Rows.Add("Cookbooks", dt.Rows[0]["NumCookbooks"]);
            }

            gDashboard.Columns["Type"].HeaderText = "Type";
            gDashboard.Columns["Number"].HeaderText = "Number";
        }

        private void BtnRecipeList_Click(object sender, EventArgs e)
        {
            mainForm.OpenForm(typeof(frmRecipeList));
        }

        private void BtnMealList_Click(object? sender, EventArgs e)
        {
            mainForm.OpenForm(typeof(frmMealList));
        }

        private void BtnCookbookList_Click(object? sender, EventArgs e)
        {
            mainForm.OpenForm(typeof(frmCookbookList));
        }
    }
}
