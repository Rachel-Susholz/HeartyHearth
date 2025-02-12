using HeartyHearthSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            mnuEditData.Click += MnuEditData_Click1;
        }


        public void OpenForm(Type frmtype, int pkvalue = 0)
        {
            bool b = WindowsFormsUtility.IsFormOpen(frmtype);
            if (b == false)
            {
                Form? newfrm = null;
                if (frmtype == typeof(frmRecipeInfo))
                {
                    frmRecipeInfo f = new();
                    newfrm = f;
                    f.ShowForm(pkvalue);
                }
                else if (frmtype == typeof(frmSearch))
                {
                    frmSearch f = new();
                    newfrm = f;
                    f.Show();
                }
                else if (frmtype == typeof(frmDataMaintenance))
                {
                    frmDataMaintenance f = new();
                    newfrm = f;
                    f.Show();
                }
                else if (frmtype == typeof(frmRecipeList))
                {
                    frmRecipeList f = new();
                    newfrm = f;
                    f.Show();
                }
                else if (frmtype == typeof(frmMealList))
                {
                    frmMealList f = new();
                    newfrm = f;
                    f.Show();
                }
                else if (frmtype == typeof(frmCookbookList))
                {
                    frmCookbookList f = new();
                    newfrm = f;
                    f.Show();
                }
                else if (frmtype == typeof(frmDashboard))
                {
                    frmDashboard f = new(this);
                    newfrm = f;
                    f.Show();
                }

                if (newfrm != null)
                {
                    newfrm.MdiParent = this;
                    newfrm.WindowState = FormWindowState.Maximized;
                    newfrm.FormClosed += Frm_FormClosed;
                    newfrm.TextChanged += Newfrm_TextChanged;
                }
                WindowsFormsUtility.SetUpNav(tsMain);
            }
        }





        private void Newfrm_TextChanged(object? sender, EventArgs e)
        {
            WindowsFormsUtility.SetUpNav(tsMain);
        }

        private void Frm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            WindowsFormsUtility.SetUpNav(tsMain);
        }

        

        private void MnuWindowStack_Click(object? sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void MnuWindowTile_Click(object? sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void MnuEditData_Click(object? sender, EventArgs e)
        {

        }

        private void MnuAutoCreate_Click(object? sender, EventArgs e)
        {

        }

        private void MnuNewCookbook_Click(object? sender, EventArgs e)
        {

        }

        private void MnuCookbookList_Click(object? sender, EventArgs e)
        {

        }

        private void MnuMealsList_Click(object? sender, EventArgs e)
        {

        }

        private void MnuDashboard_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmDashboard));
        }

        private void MnuCloneRecipe_Click(object? sender, EventArgs e)
        {

        }

        private void MnuNewRecipe_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmRecipeInfo));
        }


        private void MnuRecipesList_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmRecipeList));
        }

        private void MnuEditData_Click1(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmDataMaintenance));
        }

        private void btnMealList_Click(object sender, EventArgs e)
        {

        }
    }
}

