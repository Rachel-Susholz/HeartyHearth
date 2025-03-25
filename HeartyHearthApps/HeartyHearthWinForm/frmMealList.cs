namespace HeartyHearthWinForm
{
    public partial class frmMealList : Form
    {
        public frmMealList()
        {
            InitializeComponent();
            this.Load += FrmMealList_Load;
        }

        private void FrmMealList_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
            try
            {
                DataTable dt = recipe.GetMealList();
                ListHelper.LoadGrid(gMealList, dt, "mealid", new Dictionary<string, string>
                {
                    { "mealname", "Meal Name" },
                    { "user", "User" },
                    { "numcalories","Num Calories" },
                    { "numcourses", "Num Courses" },
                    { "numrecipes", "Num Recipes" }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading meals: " + ex.Message, Application.ProductName);
            }
        }
    }
}
