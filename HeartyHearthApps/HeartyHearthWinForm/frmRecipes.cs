using System.Data;
using System.Diagnostics;
using CPUFramework;
using CPUWindowFormsFramework;
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
        
        string sql = "select r.RecipeId, r.RecipeName, ct.CuisineTypeId, ct.CuisineName, r.Calories,  r.RecipeStatus, r.Drafted, r.Archived, " +
        "r.Published, sm.StaffMemberId, sm.UserName " +
        "from Recipe r join CuisineType ct on r.CuisineTypeId = ct.CuisineTypeId join StaffMember sm on r.StaffMemberId = sm.StaffMemberId where r.RecipeId = " + recipeid.ToString();
        dtRecipe = SQLUtility.GetDataTable(sql);
        if (recipeid == 0)
        {
            dtRecipe.Rows.Add();
        }
        DataTable dtCuisines = SQLUtility.GetDataTable("Select CuisineTypeId, CuisineName from CuisineType");
        DataTable dtStaffMembers = SQLUtility.GetDataTable("Select StaffMemberId, UserName from StaffMember");

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
        SQLUtility.DebugPrintDataTable(dtRecipe);
        DataRow r = dtRecipe.Rows[0];
        int id = (int)(r["RecipeId"] ?? 0); // Default to 0 if RecipeId is null
        string sql = "";

        if (id > 0) // Update existing recipe
        {
            sql = $"update recipe set " +
                  $"RecipeName = '{r["RecipeName"] ?? ""}', " +
                  $"CuisineTypeId = {(r["CuisineTypeId"] == DBNull.Value ? "NULL" : r["CuisineTypeId"])}, " +
                  $"Calories = {(r["Calories"] == DBNull.Value ? 0 : r["Calories"])}, " +
                  $"Drafted = {(r["Drafted"] == DBNull.Value ? "NULL" : $"'{r["Drafted"]}'")}, " +
                  $"Published = {(r["Published"] == DBNull.Value ? "NULL" : $"'{r["Published"]}'")}, " +
                  $"Archived = {(r["Archived"] == DBNull.Value ? "NULL" : $"'{r["Archived"]}'")}, " +
                  $"StaffMemberId = {(r["StaffMemberId"] == DBNull.Value ? "NULL" : r["StaffMemberId"])} " +
                  $"where RecipeId = {id}";
        }
        else // Insert new recipe
        {
            sql = "insert into recipe (RecipeName, CuisineTypeId, Calories, RecipeStatus, Drafted, Published, Archived, StaffMemberId) " +
                  $"values ('{r["RecipeName"] ?? ""}', " +
                  $"{(r["CuisineTypeId"] == DBNull.Value ? "NULL" : r["CuisineTypeId"])}, " +
                  $"{(r["Calories"] == DBNull.Value ? 0 : r["Calories"])}, " +
                  $"'{r["RecipeStatus"] ?? ""}', " +
                  $"{(r["Drafted"] == DBNull.Value ? "NULL" : $"'{r["Drafted"]}'")}, " +
                  $"{(r["Published"] == DBNull.Value ? "NULL" : $"'{r["Published"]}'")}, " +
                  $"{(r["Archived"] == DBNull.Value ? "NULL" : $"'{r["Archived"]}'")}, " +
                  $"{(r["StaffMemberId"] == DBNull.Value ? "NULL" : r["StaffMemberId"])} )";
        }


        
        SQLUtility.ExecuteSQL(sql);

    }


    private void Delete()
    {
        int id = (int)dtRecipe.Rows[0]["RecipeId"];
        string sql = "delete recipe where RecipeId = " + id;
        SQLUtility.ExecuteSQL(sql);
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
