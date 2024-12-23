namespace HeartyHearthWinForm;

public partial class frmRecipeInfo : Form
{
    DataTable dtRecipe = new();
    
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

        WindowsFormsUtility.SetListBinding(lstCuisineName, dtCuisines, dtRecipe, "Cuisine");
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
        Application.UseWaitCursor = true;
        try
        {
            recipe.Save(dtRecipe);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "HeartyHearth");
        }
        finally
        {
            Application.UseWaitCursor = false;
        }
    }

    private void Delete()
    {
        var response = MessageBox.Show("Are you sure you want to delete this recipe?", "HeartyHearth", MessageBoxButtons.YesNo);
        if(response == DialogResult.No)
        {
            return;
        }
        Application.UseWaitCursor = true;
        try
        {
            recipe.Delete(dtRecipe);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "HeartyHearth");
        }
        finally
        {
            Application.UseWaitCursor = false;
        }
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
