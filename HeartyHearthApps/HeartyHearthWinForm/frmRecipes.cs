using System.Data;
using System.Diagnostics;

namespace HeartyHearthWinForm;

public partial class frmRecipeInfo : Form
{
    DataTable dtRecipe;
    
    public frmRecipeInfo()
    {
        InitializeComponent();
        btnSave.Click += BtnSave_Click;
        btnDelete.Click += BtnDelete_Click;
    }
    public void ShowForm(int recipeid)
    {

        dtRecipe = recipe.Load(recipeid);
        if (recipeid == 0)
        {
            dtRecipe.Rows.Add();
        }
        DataTable dtCuisines = recipe.GetCuisineList();
        DataTable dtStaffMembers = recipe.GetUserList();

        WindowsFormsUtility.SetListBinding(lstCuisineName, dtCuisines, dtRecipe, "CuisineType");
        WindowsFormsUtility.SetListBinding(lstUserName, dtStaffMembers, dtRecipe, "StaffMember");
        WindowsFormsUtility.SetControlBinding(txtRecipeName, dtRecipe);
        WindowsFormsUtility.SetControlBinding(txtCalories, dtRecipe);
        WindowsFormsUtility.SetControlBinding(txtRecipeStatus, dtRecipe);
        WindowsFormsUtility.SetControlBinding(txtDrafted, dtRecipe);
        WindowsFormsUtility.SetControlBinding(lblPublished, dtRecipe);
        WindowsFormsUtility.SetControlBinding(lblArchived, dtRecipe);
        this.Show();
    }

   

   private void Save()
    {
        recipe.Save(dtRecipe);
    }

    private void Delete()
    {
        recipe.Delete(dtRecipe);
        this.Close();
    }
    private void BtnDelete_Click(object? sender, EventArgs e)
    {
        Delete();
    }

    private void BtnSave_Click(object? sender, EventArgs e)
    {
        Save();
    }
    
}
