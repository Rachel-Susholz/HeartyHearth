using HeartyHearthSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeartyHearthWinForm
{
    public partial class frmRecipeList : Form
    {
        public frmRecipeList()
        {
            InitializeComponent();
            this.Load += FrmRecipeList_Load;
        }

        private void FrmRecipeList_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
            try
            {
                DataTable dt = recipe.GetRecipeList();
                gRecipeList.Columns["RecipeId"].Visible = false;
                gRecipeList.Columns["RecipeName"].HeaderText = "Recipe Name";
                gRecipeList.Columns["Status"].HeaderText = "Status";
                gRecipeList.Columns["User"].HeaderText = "User";
                gRecipeList.Columns["Calories"].HeaderText = "Calories";

                gRecipeList.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading recipes: " + ex.Message);
            }
        }
    }
}

