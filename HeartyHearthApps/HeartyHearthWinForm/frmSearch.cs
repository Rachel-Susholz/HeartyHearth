using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CPUFramework;
using CPUWindowFormsFramework;

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
            WindowsFormsUtility.FormatGridForSearchResults(gRecipes);
        }

        

        private void GRecipes_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            ShowRecipeForm(e.RowIndex);
        }
        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            SearchForRecipe(txtRecipe.Text);
        }

        private void BtnNew_Click(object? sender, EventArgs e)
        {
            ShowRecipeForm(-1); 
        }

        private void ShowRecipeForm(int rowindex)
        {
            int id = 0;
            if (rowindex > -1)
            {
                id = (int)gRecipes.Rows[rowindex].Cells["RecipeId"].Value;
            }
            
            frmRecipeInfo frm = new();
            frm.ShowForm(id);
        }
        private DataTable SearchForRecipe(string recipe)
        {
            string sql = "select RecipeId, RecipeName from Recipe r where r.RecipeName like '%" + recipe + "%'";
            DataTable dt = SQLUtility.GetDataTable(sql);
            gRecipes.DataSource = dt;
            gRecipes.Columns["RecipeId"].Visible = false;
            return dt;
            
        }
    }
}
