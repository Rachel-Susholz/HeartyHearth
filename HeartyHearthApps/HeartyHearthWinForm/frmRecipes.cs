namespace HeartyHearthWinForm
{
    public partial class frmRecipeInfo : MultiFormBase
    {
        private DataTable dtrecipe, dtrecipeingredient, dtrecipesteps;
        private const string deleteColName = "deletecol";

        private bool _isFreshClone = false;
        public bool IsFreshClone
        {
            get { return _isFreshClone; }
            set
            {
                _isFreshClone = value;
                if (btnDelete != null)
                {
                    btnDelete.Enabled = !_isFreshClone;
                }
            }
        }

        public frmRecipeInfo(int id)
        {
            InitializeComponent();
            PrimaryKeyId = id;
            this.Tag = PrimaryKeyId;
            this.Text = "Recipe";

            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
            btnChangeStatus.Click += BtnChangeStatus_Click;
            btnSaveIngredients.Click += BtnSaveIngredients_Click;
            btnSaveSteps.Click += BtnSaveSteps_Click;
            this.FormClosing += FrmRecipeInfo_FormClosing;
            this.Shown += (s, e) =>
            {
                gIngredients.Columns["IngredientCombo"].DisplayIndex = 0;
                gIngredients.Columns["MeasurementCombo"].DisplayIndex = 1;
                gIngredients.Columns["Quantity"].DisplayIndex = 2;
                gIngredients.Columns["Sequence"].DisplayIndex = 3;
                gIngredients.Columns[deleteColName].DisplayIndex = 4;

                // Re-check the fresh clone state.
                if (IsFreshClone)
                {
                    btnDelete.Enabled = false;
                }
            };

            lstUserName.DropDownStyle = ComboBoxStyle.DropDownList;
            lstCuisineName.DropDownStyle = ComboBoxStyle.DropDownList;
            lstUserName.Visible = false;
            lblUserName.Visible = false;

            if (PrimaryKeyId == 0)
            {
                btnDelete.Enabled = btnChangeStatus.Enabled = btnSaveIngredients.Enabled = btnSaveSteps.Enabled = false;
            }

            LoadForm(PrimaryKeyId);
            LoadRecipeIngredient();
            LoadRecipeSteps();
        }

        public void LoadForm(int recipeidval)
        {
            PrimaryKeyId = recipeidval;
            this.Tag = PrimaryKeyId;
            dtrecipe = recipe.Load(PrimaryKeyId);
            if (dtrecipe.Rows.Count == 0)
            {
                DataRow newRow = dtrecipe.NewRow();
                newRow["RecipeName"] = "";
                newRow["RecipeStatus"] = "";
                newRow["Calories"] = 0;
                newRow["StaffMemberId"] = 0;
                dtrecipe.Rows.Add(newRow);
            }
            BindSource.DataSource = dtrecipe;

            DataTable dtusers = recipe.GetUserList();
            DataTable dtcuisine = recipe.GetCuisineList();

            WindowsFormsUtility.SetListBinding(lstUserName, dtusers, dtrecipe, "StaffMember");
            WindowsFormsUtility.SetListBinding(lstCuisineName, dtcuisine, dtrecipe, "Cuisine");

            WindowsFormsUtility.SetControlBinding(txtRecipeName, BindSource);
            WindowsFormsUtility.SetControlBinding(txtCalories, BindSource);
            WindowsFormsUtility.BindOutputDateControl(txtDrafted, BindSource, "Drafted");
            WindowsFormsUtility.BindOutputDateControl(lblPublished, BindSource, "Published");
            WindowsFormsUtility.BindOutputDateControl(lblArchived, BindSource, "Archived");
            txtDrafted.ReadOnly = true;
            WindowsFormsUtility.SetControlBinding(txtRecipeStatus, BindSource);

            this.Text = "Recipe - " + GetRecipeDesc();
            SetButtonsEnablesBasedOnNewRecord();
        }

        private void LoadRecipeIngredient()
        {
            dtrecipeingredient = RecipeIngredient.LoadByRecipeId(PrimaryKeyId);
            gIngredients.Columns.Clear();
            gIngredients.DataSource = dtrecipeingredient;

            WindowsFormsUtility.AddDeleteButtonToGrid(gIngredients, deleteColName);
            WindowsFormsUtility.AddComboBoxToGrid(gIngredients, DataMaintenance.GetDataList("Ingredient"), "IngredientName", "Ingredient");
            WindowsFormsUtility.AddComboBoxToGrid(gIngredients, DataMaintenance.GetDataList("Measurement"), "MeasurementType", "Measurement");

            gIngredients.Columns["IngredientCombo"].HeaderText = "Ingredient";
            gIngredients.Columns["IngredientCombo"].DefaultCellStyle.NullValue = "Add Ingredient here";
            gIngredients.Columns["MeasurementCombo"].HeaderText = "Measurement";
            gIngredients.Columns["MeasurementCombo"].DefaultCellStyle.NullValue = "Add Measurement here";

            WindowsFormsUtility.FormatGridForEdit(gIngredients, "RecipeIngredient");

            gIngredients.Columns["IngredientCombo"].DisplayIndex = 0;
            gIngredients.Columns["MeasurementCombo"].DisplayIndex = 1;
            gIngredients.Columns["Quantity"].DisplayIndex = 2;
            gIngredients.Columns["Sequence"].DisplayIndex = 3;
            gIngredients.Columns[deleteColName].DisplayIndex = 4;
            gIngredients.CellBeginEdit += gIngredients_CellBeginEdit;

            GridHelper.AttachNumericKeyPressHandler(gIngredients, "Quantity", "Sequence");
            gIngredients.CellContentClick += gIngredients_CellContentClick;
        }

        private void LoadRecipeSteps()
        {
            dtrecipesteps = RecipeStep.LoadByRecipeId(PrimaryKeyId);
            gSteps.Columns.Clear();
            gSteps.DataSource = dtrecipesteps;
            WindowsFormsUtility.AddDeleteButtonToGrid(gSteps, deleteColName);
            WindowsFormsUtility.FormatGridForEdit(gSteps, "RecipeStep");

            gSteps.CellContentClick -= gSteps_CellContentClick;
            gSteps.CellContentClick += gSteps_CellContentClick;
        }

        private void gIngredients_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            string colName = gIngredients.Columns[e.ColumnIndex].Name;
            if (colName == "Quantity" || colName == "Sequence")
            {
                DataGridViewRow row = gIngredients.Rows[e.RowIndex];
                bool ingredientMissing = row.Cells["IngredientCombo"].Value == null ||
                                         string.IsNullOrWhiteSpace(row.Cells["IngredientCombo"].Value.ToString());
                bool measurementMissing = row.Cells["MeasurementCombo"].Value == null ||
                                          string.IsNullOrWhiteSpace(row.Cells["MeasurementCombo"].Value.ToString());
                if (ingredientMissing || measurementMissing)
                {
                    MessageBox.Show("Please choose an ingredient and measurement first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
        }
        private void gIngredients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (gIngredients.Columns[e.ColumnIndex].Name == deleteColName)
            {
                DataGridViewRow row = gIngredients.Rows[e.RowIndex];
                if (row.IsNewRow || row.Cells["IngredientCombo"].Value == null || row.Cells["MeasurementCombo"].Value == null)
                {
                    MessageBox.Show("Cannot delete placeholder row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Are you sure you want to delete this ingredient?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dtrecipeingredient.Rows[e.RowIndex].Delete();
                    btnSaveIngredients.Enabled = true;
                }
            }
        }

        private void gSteps_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (gSteps.Columns[e.ColumnIndex].Name == deleteColName)
            {
                DataGridViewRow row = gSteps.Rows[e.RowIndex];
                if (row.IsNewRow)
                {
                    MessageBox.Show("Cannot delete placeholder row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Are you sure you want to delete this step?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dtrecipesteps.Rows[e.RowIndex].Delete();
                    btnSaveSteps.Enabled = true;
                }
            }
        }

        private string GetRecipeDesc() =>
            string.IsNullOrWhiteSpace(dtrecipe.Rows[0]["RecipeName"].ToString()) ? "New Recipe" : dtrecipe.Rows[0]["RecipeName"].ToString();

        private void SetButtonsEnablesBasedOnNewRecord()
        {
            bool isNew = PrimaryKeyId == 0;
            btnDelete.Enabled = btnChangeStatus.Enabled = btnSaveIngredients.Enabled = btnSaveSteps.Enabled = !isNew;
        }

        private void Save()
        {
            try
            {
                if (PrimaryKeyId == 0 && Convert.ToInt32(dtrecipe.Rows[0]["StaffMemberId"]) == 0)
                {
                    DataTable dtusers = recipe.GetUserList();
                    if (dtusers.Rows.Count > 0)
                        dtrecipe.Rows[0]["StaffMemberId"] = dtusers.Rows[0]["StaffMemberId"];
                }
                recipe.Save(dtrecipe);
                if (PrimaryKeyId == 0 && dtrecipe.Rows[0]["RecipeId"] != DBNull.Value)
                {
                    PrimaryKeyId = Convert.ToInt32(dtrecipe.Rows[0]["RecipeId"]);
                    this.Tag = PrimaryKeyId;
                }
                DataRow updatedRow = recipe.Load(PrimaryKeyId).Rows[0];
                dtrecipe.Rows[0]["RecipeStatus"] = updatedRow["RecipeStatus"];
                dtrecipe.Rows[0]["Drafted"] = updatedRow["Drafted"];
                dtrecipe.Rows[0]["Published"] = updatedRow["Published"];
                dtrecipe.Rows[0]["Archived"] = updatedRow["Archived"];

                BindSource.ResetBindings(false);
                this.Text = "Recipe - " + GetRecipeDesc();
                MessageBox.Show("Saved!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtrecipe.AcceptChanges();
                dtrecipeingredient.AcceptChanges();
                dtrecipesteps.AcceptChanges();
                SetButtonsEnablesBasedOnNewRecord();
                if (IsFreshClone)
                {
                    IsFreshClone = false;
                    btnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this recipe?", Application.ProductName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                try { recipe.Delete(dtrecipe); this.Close(); }
                catch (Exception ex) { MessageBox.Show(ex.Message, Application.ProductName); }
        }

        private void BtnChangeStatus_Click(object sender, EventArgs e) =>
            ((frmMain)this.MdiParent).OpenForm(typeof(frmChangeStatus), PrimaryKeyId);

        private void BtnSaveIngredients_Click(object sender, EventArgs e)
        {
            try
            {
                RecipeIngredient.Save(dtrecipeingredient);
                MessageBox.Show("Ingredients saved!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSaveIngredients.Enabled = false;
                dtrecipeingredient.AcceptChanges();
            }
            catch (Exception ex) { MessageBox.Show("Error saving ingredients: " + ex.Message, Application.ProductName); }
        }

        private void BtnSaveSteps_Click(object sender, EventArgs e)
        {
            try
            {
                RecipeStep.Save(dtrecipesteps);
                MessageBox.Show("Steps saved!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSaveSteps.Enabled = false;
                dtrecipesteps.AcceptChanges();
            }
            catch (Exception ex) { MessageBox.Show("Error saving steps: " + ex.Message, Application.ProductName); }
        }

        protected override void PreClose()
        {
            gIngredients.CommitEdit(DataGridViewDataErrorContexts.Commit);
            gSteps.CommitEdit(DataGridViewDataErrorContexts.Commit);
            base.PreClose();
        }

        protected override DataTable[] GetDataTablesForChangeCheck()
        {
            return new DataTable[] { dtrecipe, dtrecipeingredient, dtrecipesteps };
        }

        protected override bool SaveData()
        {
            try
            {
                if (PrimaryKeyId == 0 && Convert.ToInt32(dtrecipe.Rows[0]["StaffMemberId"]) == 0)
                {
                    DataTable dtusers = recipe.GetUserList();
                    if (dtusers.Rows.Count > 0)
                        dtrecipe.Rows[0]["StaffMemberId"] = dtusers.Rows[0]["StaffMemberId"];
                }
                recipe.Save(dtrecipe);
                if (PrimaryKeyId == 0 && dtrecipe.Rows[0]["RecipeId"] != DBNull.Value)
                {
                    PrimaryKeyId = Convert.ToInt32(dtrecipe.Rows[0]["RecipeId"]);
                    this.Tag = PrimaryKeyId;
                }
                DataRow updatedRow = recipe.Load(PrimaryKeyId).Rows[0];
                dtrecipe.Rows[0]["RecipeStatus"] = updatedRow["RecipeStatus"];
                dtrecipe.Rows[0]["Drafted"] = updatedRow["Drafted"];
                dtrecipe.Rows[0]["Published"] = updatedRow["Published"];
                dtrecipe.Rows[0]["Archived"] = updatedRow["Archived"];

                BindSource.ResetBindings(false);
                this.Text = "Recipe - " + GetRecipeDesc();
                MessageBox.Show("Saved!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtrecipe.AcceptChanges();
                dtrecipeingredient.AcceptChanges();
                dtrecipesteps.AcceptChanges();
                SetButtonsEnablesBasedOnNewRecord();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
                return false;
            }
        }

        private bool HasUnsavedChanges()
        {
            return (dtrecipe.GetChanges() != null ||
                    dtrecipeingredient.GetChanges() != null ||
                    dtrecipesteps.GetChanges() != null);
        }

        private void FrmRecipeInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsFreshClone)
            {
                bool changesExist = HasUnsavedChanges();
                string prompt = changesExist ?
                    "Do you want to save the changes to " + GetRecipeDesc() + "?" :
                    "Do you want to save " + GetRecipeDesc() + "?";
                DialogResult result = MessageBox.Show(prompt, "Confirm Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (!SaveData())
                    {
                        e.Cancel = true;
                    }
                }
                else if (result == DialogResult.No)
                {
                    try
                    {
                        recipe.Delete(dtrecipe);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error discarding the cloned recipe: " + ex.Message, Application.ProductName);
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
