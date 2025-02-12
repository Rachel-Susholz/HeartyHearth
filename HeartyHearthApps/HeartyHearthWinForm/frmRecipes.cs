

namespace HeartyHearthWinForm;

public partial class frmRecipeInfo : Form
{
    DataTable dtRecipe = new();
    BindingSource bindsource = new();
    
    public frmRecipeInfo()
    {
        InitializeComponent();
        btnSave.Click += BtnSave_Click;
        btnDelete.Click += BtnDelete_Click;
        this.FormClosing += FrmRecipeInfo_FormClosing;
    }


    public void ShowForm(int recipeid)
    {
        this.Tag = recipeid;
        dtRecipe = recipe.Load(recipeid);
        bindsource.DataSource = dtRecipe;
        if (recipeid == 0)
        {
            dtRecipe.Rows.Add();
        }
        DataTable dtCuisines = recipe.GetCuisineList();
        DataTable dtStaffMembers = recipe.GetUserList();

        WindowsFormsUtility.SetListBinding(lstCuisineName, dtCuisines, dtRecipe, "Cuisine");
        WindowsFormsUtility.SetListBinding(lstUserName, dtStaffMembers, dtRecipe, "StaffMember");
        WindowsFormsUtility.SetControlBinding(txtRecipeName, bindsource);
        WindowsFormsUtility.SetControlBinding(txtCalories, bindsource);
        WindowsFormsUtility.SetControlBinding(txtRecipeStatus, bindsource);
        WindowsFormsUtility.SetControlBinding(txtDrafted, bindsource);
        WindowsFormsUtility.SetControlBinding(lblPublished, bindsource);
        WindowsFormsUtility.SetControlBinding(lblArchived, bindsource);
        this.Text = GetRecipeDesc();
        this.Show();
    }

   

   private bool Save()
    {
        bool b = false;
        Application.UseWaitCursor = true;
        try
        {
            recipe.Save(dtRecipe);
            b = true;
            bindsource.ResetBindings(false);
            this.Tag = SQLUtility.GetValueFromFirstRowAsInt(dtRecipe, "RecipeId");
            this.Text = GetRecipeDesc();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, Application.ProductName);
        }
        finally
        {
            Application.UseWaitCursor = false;
        }
        return b;
    }

    private void Delete()
    {
        var response = MessageBox.Show("Are you sure you want to delete this recipe?", Application.ProductName, MessageBoxButtons.YesNo);
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
            MessageBox.Show(ex.Message, Application.ProductName);
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

    private string GetRecipeDesc()
    {
        string value = "New Recipe";
        int pkvalue = SQLUtility.GetValueFromFirstRowAsInt(dtRecipe, "RecipeId");
        if (pkvalue > 0)
        {
            value = SQLUtility.GetValueFromFirstRowAsInt(dtRecipe, "RecipeId") + " " + SQLUtility.GetValueFromFirstRowAsString(dtRecipe, "RecipeName");
        }
        return value;
    }

    private void FrmRecipeInfo_FormClosing(object? sender, FormClosingEventArgs e)
    {
        bindsource.EndEdit();
        if (SQLUtility.DoesTableHaveChanges(dtRecipe) == true)
        { 
            var res = MessageBox.Show($"Do you want to save changes to {this.Text} before closing the form?", Application.ProductName, MessageBoxButtons.YesNoCancel);

            switch (res)
            {
                case DialogResult.Yes:
                    bool b = Save();
                    if(b == false)
                    {
                        e.Cancel = true;
                        this.Activate();
                    }
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    this.Activate();
                    break;
            }
        }
    }

}
