namespace HeartyHearthWinForm
{
    public partial class frmCookbookInfo : MultiFormBase
    {
        private DataTable dtCookbook, dtCookbookRecipes;
        const string deleteCol = "deletecol";
        bool bFormBounded = false;

        public frmCookbookInfo(int id)
        {
            InitializeComponent();
            PrimaryKeyId = id; // cookbookId
            this.Tag = PrimaryKeyId;
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
            btnSaveRecipe.Click += BtnSaveRecipe_Click;
            this.Shown += FrmCookbookInfo_Shown;
            this.FormClosing += FrmCookbookInfo_FormClosing;
        }

        private void FrmCookbookInfo_Shown(object sender, EventArgs e)
        {
            this.Text = (PrimaryKeyId == 0) ? "New Cookbook" : $"Cookbook - {GetCookbookDesc()}";
            LoadForm(PrimaryKeyId);
            SetupRecipesGrid();
        }

        public void LoadForm(int id)
        {
            PrimaryKeyId = id;
            this.Tag = PrimaryKeyId;
            dtCookbook = cookbook.LoadCookbook(PrimaryKeyId);
            if (dtCookbook.Rows.Count == 0)
            {
                DataRow newRow = dtCookbook.NewRow();
                newRow["CookbookName"] = "";
                newRow["Price"] = 0.00m;
                newRow["CookbookStatus"] = true;
                newRow["Created"] = DateTime.Now;
                newRow["StaffMemberId"] = 0;
                dtCookbook.Rows.Add(newRow);
            }
            BindSource.DataSource = dtCookbook;
            if (!bFormBounded)
            {
                WindowsFormsUtility.BindHeaderControls(BindSource, txtCookbookName, txtPrice);
                WindowsFormsUtility.SetControlBinding(cbxCookbookStatus, BindSource);
                WindowsFormsUtility.BindOutputDateControl(txtCreated, BindSource, "Created");

                DataTable dtUsers = recipe.GetUserList();
                WindowsFormsUtility.SetListBinding(lstUserName, dtUsers, dtCookbook, "StaffMember");
                bFormBounded = true;
            }
            this.Text = "Cookbook - " + GetCookbookDesc();
            SetButtonsEnablesBasedOnNewRecord();
        }

        private void SetupRecipesGrid()
        {
            dtCookbookRecipes = CookbookRecipe.LoadByCookbookId(PrimaryKeyId);
            if (dtCookbookRecipes.Columns.Contains("CookbookRecipeId"))
            {
                dtCookbookRecipes.Columns["CookbookRecipeId"].AutoIncrement = true;
                dtCookbookRecipes.Columns["CookbookRecipeId"].AutoIncrementSeed = -1;
                dtCookbookRecipes.Columns["CookbookRecipeId"].AutoIncrementStep = -1;
            }
            if (dtCookbookRecipes.Columns.Contains("RecipeSequence"))
                dtCookbookRecipes.Columns["RecipeSequence"].ColumnName = "Sequence";

            for (int i = dtCookbookRecipes.Rows.Count - 1; i >= 0; i--)
            {
                int rid = (dtCookbookRecipes.Rows[i]["RecipeId"] == DBNull.Value) ? 0 : Convert.ToInt32(dtCookbookRecipes.Rows[i]["RecipeId"]);
                if (rid == 0)
                    dtCookbookRecipes.Rows.RemoveAt(i);
            }
            dtCookbookRecipes.AcceptChanges();
            DataRow placeholder = dtCookbookRecipes.NewRow();
            placeholder["RecipeId"] = 0;
            placeholder["Sequence"] = DBNull.Value;
            dtCookbookRecipes.Rows.Add(placeholder);

            gCookbookRecipes.DataSource = dtCookbookRecipes;
            gCookbookRecipes.AllowUserToAddRows = false;

            DataTable dtRecipes = DataMaintenance.GetDataList("Recipe");
            bool found = false;
            foreach (DataRow r in dtRecipes.Rows)
            {
                int rid = (r["RecipeId"] == DBNull.Value) ? 0 : Convert.ToInt32(r["RecipeId"]);
                if (rid == 0)
                {
                    r["RecipeName"] = "Add a recipe here";
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                DataRow newRow = dtRecipes.NewRow();
                newRow["RecipeId"] = 0;
                newRow["RecipeName"] = "Add a recipe here";
                dtRecipes.Rows.Add(newRow);
            }

            WindowsFormsUtility.AddComboBoxToGrid(gCookbookRecipes, dtRecipes, "RecipeName", "Recipe");
            WindowsFormsUtility.FormatGridForEdit(gCookbookRecipes, "CookbookRecipe");
            WindowsFormsUtility.AddDeleteButtonToGrid(gCookbookRecipes, deleteCol);
            gCookbookRecipes.Columns[deleteCol].DisplayIndex = gCookbookRecipes.Columns.Count - 1;

            SetupRecipeGridEvents();
            UpdatePrice();
            WindowsFormsUtility.AcceptBaselineChanges(dtCookbook, dtCookbookRecipes);
            if (this.MdiParent is frmMain mainForm)
                mainForm.UpdateNavigation();
        }

        void SetupRecipeGridEvents()
        {
            GridHelper.AttachCellBeginEditHandler(
                gCookbookRecipes,
                new string[] { "Sequence" },
                row => Convert.ToInt32(row.Cells["RecipeId"].Value) != 0,
                "Cannot enter recipe sequence before entering recipe name");
            GridHelper.AttachNumericKeyPressHandler(gCookbookRecipes, "Sequence");
            GridHelper.AttachDeleteButtonHandler(
            gCookbookRecipes,
            deleteCol,
            "Are you sure you want to delete this recipe?",
            rowIndex => Convert.ToInt32(dtCookbookRecipes.Rows[rowIndex]["RecipeId"]) != 0,
            rowIndex =>
             {
                dtCookbookRecipes.Rows.RemoveAt(rowIndex);
                MessageBox.Show("Recipe deleted successfully", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (this.MdiParent is frmMain mainForm)
                mainForm.UpdateNavigation();
            });

        }

        string GetCookbookDesc() =>
            (dtCookbook == null || dtCookbook.Rows.Count == 0 || dtCookbook.Rows[0]["CookbookName"] == DBNull.Value ||
             string.IsNullOrWhiteSpace(dtCookbook.Rows[0]["CookbookName"].ToString()))
            ? "New Cookbook" : dtCookbook.Rows[0]["CookbookName"].ToString();

        void UpdatePrice()
        {
            int count = 0;
            foreach (DataRow row in dtCookbookRecipes.Rows)
                if (Convert.ToInt32(row["RecipeId"]) != 0)
                    count++;
            dtCookbook.Rows[0]["Price"] = count * 1.25m;
        }

        void SetButtonsEnablesBasedOnNewRecord()
        {
            bool isNew = PrimaryKeyId == 0 || string.IsNullOrWhiteSpace(dtCookbook.Rows[0]["CookbookName"].ToString());
            btnDelete.Enabled = btnSaveRecipe.Enabled = !isNew;
        }
        bool SaveCookbookData()
        {
            Application.UseWaitCursor = true;
            try
            {
                UpdatePrice();
                if (Convert.ToDecimal(dtCookbook.Rows[0]["Price"]) <= 0)
                {
                    MessageBox.Show("A cookbook must contain at least one recipe before saving.",
                        Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSaveRecipe.Enabled = true;
                    return false;
                }
                cookbook.SaveCookbook(dtCookbook);
                CookbookRecipe.Save(dtCookbookRecipes);
                BindSource.ResetBindings(false);
                this.Tag = SQLUtility.GetValueFromFirstRowAsInt(dtCookbook, "CookbookId");
                this.Text = GetCookbookDesc();
                MessageBox.Show("Saved!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetButtonsEnablesBasedOnNewRecord();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving cookbook: " + ex.Message, Application.ProductName);
                return false;
            }
            finally { Application.UseWaitCursor = false; }
        }
        private void Delete()
        {
            if (MessageBox.Show($"Are you sure you want to delete {GetCookbookDesc()} and all related recipes?",
                Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.UseWaitCursor = true;
                try { cookbook.DeleteCookbook(dtCookbook); }
                catch (Exception ex) { MessageBox.Show("Error deleting cookbook: " + ex.Message, Application.ProductName); }
                finally { Application.UseWaitCursor = false; }
                MessageBox.Show($"{GetCookbookDesc()} successfully deleted", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (this.MdiParent is frmMain mainForm)
                    mainForm.UpdateNavigation();
                this.Close();
            }
        }
        void BtnSave_Click(object sender, EventArgs e) => SaveCookbookData();

        void BtnDelete_Click(object sender, EventArgs e) => Delete();

        void BtnSaveRecipe_Click(object sender, EventArgs e)
        {
            try
            {
                CookbookRecipe.Save(dtCookbookRecipes);
                MessageBox.Show("Saved!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving cookbook recipes: " + ex.Message, Application.ProductName);
            }
        }

        protected override DataTable[] GetDataTablesForChangeCheck()
        {
            return new DataTable[] { dtCookbook };
        }

        protected override bool SaveData()
        {
            return SaveCookbookData();
        }

        private void FrmCookbookInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
