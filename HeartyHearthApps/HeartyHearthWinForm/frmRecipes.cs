using System.Data;
using CPUFramework;
using CPUWindowFormsFramework;
namespace HeartyHearthWinForm;

public partial class frmRecipeInfo : Form
{
    DataTable dtRecipe;
    DataTable dtCuisines = SQLUtility.GetDataTable("Select CuisineId, CuisineName from CuisineType" +
        "union select null, ''");
    DataTable dtStaffMembers = SQLUtility.GetDataTable("Select StaffMemberId, UserName from StaffMember" +
        "union select null, ''");
    public frmRecipeInfo()
    {
        InitializeComponent();
        //btnSave.Click += BtnSave_Click;
        //btnDelete.Click += BtnDelete_Click;
    }
    public void ShowForm(int recipeid)
    {
        string sql = "select r.RecipeName, ct.CuisineTypeId, ct.CuisineName, r.Calories,  r.RecipeStatus, r.Drafted, r.Archived, " +
        "r.Published, r.Archived, sm.StaffMemberId, sm.UserName " +
        "from Recipe r join CuisineType ct on r.CuisineId = ct.CuisineId join StaffMember sm on r.StaffMemberId = sm.StaffMemberId where r.RecipeId = " + recipeid.ToString();
        dtRecipe = SQLUtility.GetDataTable(sql);
        if (recipeid == 0)
        {
            dtRecipe.Rows.Add();
        }
        WindowsFormsUtility.SetListBinding(lstCuisineName, dtCuisines, dtRecipe, "CuisineType");
        WindowsFormsUtility.SetListBinding(lstUserName, dtStaffMembers, dtRecipe, "StaffMember");
        WindowsFormsUtility.SetControlBinding(lblRecipeName, dtRecipe);
        WindowsFormsUtility.SetControlBinding(txtCalories, dtRecipe);
        WindowsFormsUtility.SetControlBinding(lblRecipeStatus, dtRecipe);
        WindowsFormsUtility.SetControlBinding(txtDrafted, dtRecipe);
        WindowsFormsUtility.SetControlBinding(lblPublished, dtRecipe);
        WindowsFormsUtility.SetControlBinding(lblArchived, dtRecipe);
        this.Show();
    }

   

    private void Save()
    {
        SQLUtility.DebugPrintDataTable(dtRecipe);
        DataRow r = dtRecipe.Rows[0];
        int id = (int)r["RecipeId"];
        string sql = "";
        if (id > 0)
        {
            sql = string.Join($"update recipe set",
                $"RecipeName = '{r["RecipeName"]}',",
                $"CuisineId = '{r["CusineId"]}',",
                $"Calories = '{r["Calories"]}',",
                $"Drafted = '{r["Drafted"]}',",
                $"StaffMemberId = '{r["StaffMemberId"]}',",
                $"where RecipeId = {r["RecipeId"]}");
        }
        else
        {
            sql = "insert recipe(RecipeId, CuisineId, Calories, RecipeStatus, Drafted, Published, Archived, StaffMemberId)";
            sql += $"select '{r["RecipeId"]}', '{r["CuisineId"]}', '{r["Calories"]}', '{r["RecipeStatus"]}', '{r["Drafted"]}', '{r["Published"]}', '{r["Archived"]}', '{r["UserName"]}'";
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
