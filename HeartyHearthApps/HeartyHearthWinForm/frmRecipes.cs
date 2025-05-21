namespace HeartyHearthWinForm
{
    public partial class frmRecipeInfo : MultiFormBase
    {
        private DataTable dtrecipe, dtrecipeingredient, dtrecipesteps;
        private const string deleteColName = "deletecol";
        private bool isFreshClone;
        public bool IsFreshClone
        {
            get => isFreshClone;
            set
            {
                isFreshClone = value;
                if (btnDelete != null) btnDelete.Enabled = !isFreshClone;
            }
        }

        public frmRecipeInfo(int id)
        {
            InitializeComponent();
            PrimaryKeyId = id;
            Tag = id;
            Text = "Recipe";
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
            btnChangeStatus.Click += BtnChangeStatus_Click;
            btnSaveIngredients.Click += BtnSaveIngredients_Click;
            btnSaveSteps.Click += BtnSaveSteps_Click;
            gIngredients.CellContentClick += gIngredients_CellContentClick;
            gSteps.CellContentClick += gSteps_CellContentClick;
            FormClosing += FrmRecipeInfo_FormClosing;
            Shown += (s, e) => { if (IsFreshClone) btnDelete.Enabled = false; };
            lstUserName.DropDownStyle = ComboBoxStyle.DropDownList;
            lstCuisineName.DropDownStyle = ComboBoxStyle.DropDownList;
            if (PrimaryKeyId == 0)
                btnDelete.Enabled = btnChangeStatus.Enabled = btnSaveIngredients.Enabled = btnSaveSteps.Enabled = false;
            LoadForm(id);
            LoadRecipeIngredient();
            LoadRecipeSteps();
        }

        public void LoadForm(int recipeid)
        {
            PrimaryKeyId = recipeid;
            Tag = recipeid;
            dtrecipe = recipe.Load(PrimaryKeyId);
            if (dtrecipe.Rows.Count == 0)
            {
                var r = dtrecipe.NewRow();
                r["RecipeName"] = "";
                r["RecipeStatus"] = "";
                r["Calories"] = 0;
                r["StaffMemberId"] = 0;
                dtrecipe.Rows.Add(r);
            }
            BindSource.DataSource = dtrecipe;
            var du = recipe.GetUserList();
            var dc = recipe.GetCuisineList();
            WindowsFormsUtility.SetListBinding(lstUserName, du, dtrecipe, "StaffMember");
            WindowsFormsUtility.SetListBinding(lstCuisineName, dc, dtrecipe, "Cuisine");
            WindowsFormsUtility.SetControlBinding(txtRecipeName, BindSource);
            WindowsFormsUtility.SetControlBinding(txtCalories, BindSource);
            txtCalories.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true;
            };
            WindowsFormsUtility.BindOutputDateControl(txtDrafted, BindSource, "Drafted");
            WindowsFormsUtility.BindOutputDateControl(txtPublished, BindSource, "Published");
            WindowsFormsUtility.BindOutputDateControl(txtArchived, BindSource, "Archived");
            WindowsFormsUtility.SetControlBinding(txtRecipeStatus, BindSource);
            Text = "Recipe - " + GetRecipeDesc();
            SetButtonsEnablesBasedOnNewRecord();
        }

        private void LoadRecipeIngredient()
        {
            dtrecipeingredient = RecipeIngredient.LoadByRecipeId(PrimaryKeyId);
            if (dtrecipeingredient.Columns.Contains("Quantity"))
                dtrecipeingredient.Columns["Quantity"].ColumnName = "Amount";
            if (dtrecipeingredient.Columns.Contains("Sequence"))
                dtrecipeingredient.Columns["Sequence"].ColumnName = "IngredientSequence";
            dtrecipeingredient.Columns["RecipeId"].DefaultValue = PrimaryKeyId;

            gIngredients.Columns.Clear();
            gIngredients.DataSource = dtrecipeingredient;

            WindowsFormsUtility.AddDeleteButtonToGrid(gIngredients, deleteColName);

            WindowsFormsUtility.AddComboBoxToGrid(
                gIngredients, DataMaintenance.GetDataList("Ingredient"),
                "IngredientName", "Ingredient");
            WindowsFormsUtility.AddComboBoxToGrid(
                gIngredients, DataMaintenance.GetDataList("Measurement"),
                "MeasurementType", "Measurement");
            gIngredients.Columns["IngredientCombo"].DefaultCellStyle.NullValue = "Add Ingredient here";
            gIngredients.Columns["MeasurementCombo"].DefaultCellStyle.NullValue = "Add Measurement here";

            WindowsFormsUtility.FormatGridForEdit(gIngredients, "RecipeIngredient");
            GridHelper.AttachNumericKeyPressHandler(gIngredients, "Amount", "IngredientSequence");

            gIngredients.Columns["IngredientCombo"].DisplayIndex = 0;
            gIngredients.Columns["MeasurementCombo"].DisplayIndex = 1;
            gIngredients.Columns["Amount"].DisplayIndex = 2;
            gIngredients.Columns["IngredientSequence"].DisplayIndex = 3;
            gIngredients.Columns[deleteColName].DisplayIndex = 4;

            gIngredients.RowsAdded += (s, e) => btnSaveIngredients.Enabled = true;
        }

        private void BtnSaveIngredients_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataRow r in dtrecipeingredient.Rows)
                    if (r.RowState == DataRowState.Added)
                        r["RecipeId"] = PrimaryKeyId;
                RecipeIngredient.Save(dtrecipeingredient);
                foreach (DataRow dr in dtrecipeingredient.Select(
                    null, null, DataViewRowState.Deleted))
                {
                    var id = (int)dr["RecipeIngredientId", DataRowVersion.Original];
                    using var cmd = SQLUtility.GetSqlCommand("RecipeIngredientDelete");
                    SQLUtility.SetParamValue(cmd, "@RecipeIngredientId", id);
                    SQLUtility.ExecuteSQL(cmd);
                }
                MessageBox.Show("Ingredients saved!", "Save",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtrecipeingredient.AcceptChanges();
                btnSaveIngredients.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving ingredients: " + ex.Message,
                    Application.ProductName);
            }
        }

        private void gIngredients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0
             || gIngredients.Columns[e.ColumnIndex].Name != deleteColName)
                return;

            var row = gIngredients.Rows[e.RowIndex];
            if (row.IsNewRow
             || row.Cells["RecipeIngredientId"].Value == DBNull.Value)
                return;

            if (MessageBox.Show(
                    "Are you sure you want to delete this ingredient?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question)
                != DialogResult.Yes)
                return;

            int id = (int)row.Cells["RecipeIngredientId"].Value;
            using var cmd = SQLUtility.GetSqlCommand("RecipeIngredientDelete");
            SQLUtility.SetParamValue(cmd, "@RecipeIngredientId", id);
            SQLUtility.ExecuteSQL(cmd);
            MessageBox.Show("Ingredient deleted!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadRecipeIngredient();
        }

        private void LoadRecipeSteps()
        {
            dtrecipesteps = RecipeStep.LoadByRecipeId(PrimaryKeyId);
            if (dtrecipesteps.Columns.Contains("Sequence"))
                dtrecipesteps.Columns["Sequence"].ColumnName = "DirectionSequence";
            dtrecipesteps.Columns["RecipeId"].DefaultValue = PrimaryKeyId;

            gSteps.Columns.Clear();
            gSteps.DataSource = dtrecipesteps;

            WindowsFormsUtility.AddDeleteButtonToGrid(gSteps, deleteColName);
            WindowsFormsUtility.FormatGridForEdit(gSteps, "RecipeStep");
            GridHelper.AttachNumericKeyPressHandler(gSteps, "DirectionSequence");

            if (gSteps.Columns.Contains("DirectionSequence"))
                gSteps.Columns["DirectionSequence"].HeaderText = "Sequence";
 

        }


        private void BtnSaveSteps_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataRow r in dtrecipesteps.Rows)
                    if (r.RowState == DataRowState.Added)
                        r["RecipeId"] = PrimaryKeyId;
                RecipeStep.Save(dtrecipesteps);
                foreach (DataRow dr in dtrecipesteps.Select(
                    null, null, DataViewRowState.Deleted))
                {
                    var id = (int)dr["RecipeDirectionId", DataRowVersion.Original];
                    using var cmd = SQLUtility.GetSqlCommand("RecipeDirectionDelete");
                    SQLUtility.SetParamValue(cmd, "@RecipeDirectionId", id);
                    SQLUtility.ExecuteSQL(cmd);
                }
                MessageBox.Show("Steps saved!", "Save",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtrecipesteps.AcceptChanges();

                btnSaveSteps.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving steps: " + ex.Message,
                    Application.ProductName);
            }
        }

        private void gSteps_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0
             || gSteps.Columns[e.ColumnIndex].Name != deleteColName)
                return;

            var row = gSteps.Rows[e.RowIndex];
            if (row.IsNewRow
             || row.Cells["RecipeDirectionId"].Value == DBNull.Value)
                return;

            if (MessageBox.Show(
                    "Are you sure you want to delete this step?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question)
                != DialogResult.Yes)
                return;

            int id = (int)row.Cells["RecipeDirectionId"].Value;
            using var cmd = SQLUtility.GetSqlCommand("RecipeDirectionDelete");
            SQLUtility.SetParamValue(cmd, "@RecipeDirectionId", id);
            SQLUtility.ExecuteSQL(cmd);
            MessageBox.Show("Step deleted!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadRecipeSteps();
        }

        private string GetRecipeDesc() =>
            string.IsNullOrWhiteSpace(dtrecipe.Rows[0]["RecipeName"].ToString())
                ? "New Recipe"
                : dtrecipe.Rows[0]["RecipeName"].ToString();

        private void SetButtonsEnablesBasedOnNewRecord()
        {
            var isNew = PrimaryKeyId == 0;
            btnDelete.Enabled =
            btnChangeStatus.Enabled =
            btnSaveIngredients.Enabled =
            btnSaveSteps.Enabled = !isNew;
        }

        protected override void PreClose()
        {
            gIngredients.CommitEdit(DataGridViewDataErrorContexts.Commit);
            gSteps.CommitEdit(DataGridViewDataErrorContexts.Commit);
            base.PreClose();
        }

        protected override DataTable[] GetDataTablesForChangeCheck() =>
            new[] { dtrecipe, dtrecipeingredient, dtrecipesteps };

        protected override bool SaveData()
        {
            try
            {
                if (PrimaryKeyId == 0 &&
                    Convert.ToInt32(dtrecipe.Rows[0]["StaffMemberId"]) == 0)
                {
                    var du = recipe.GetUserList();
                    if (du.Rows.Count > 0)
                        dtrecipe.Rows[0]["StaffMemberId"] = du.Rows[0]["StaffMemberId"];
                }
                recipe.Save(dtrecipe);
                var up = recipe.Load(PrimaryKeyId).Rows[0];
                dtrecipe.Rows[0]["RecipeStatus"] = up["RecipeStatus"];
                dtrecipe.Rows[0]["Drafted"] = up["Drafted"];
                dtrecipe.Rows[0]["Published"] = up["Published"];
                dtrecipe.Rows[0]["Archived"] = up["Archived"];
                BindSource.ResetBindings(false);
                Text = "Recipe - " + GetRecipeDesc();
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

        private void BtnSave_Click(object sender, EventArgs e) => SaveData();

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to delete this recipe?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question    // ← question icon
            );
            if (result != DialogResult.Yes)
                return;

            try
            {
                using var cmd = SQLUtility.GetSqlCommand("RecipeDelete");
                SQLUtility.SetParamValue(cmd, "@RecipeId", PrimaryKeyId);
                SQLUtility.ExecuteSQL(cmd);

                MessageBox.Show(
                    "Recipe deleted.",
                    "Deleted",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                ((frmMain)MdiParent).OpenForm(typeof(frmRecipeList), 0);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,          
                    "Delete Not Allowed", 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void BtnChangeStatus_Click(object sender, EventArgs e) =>
            ((frmMain)MdiParent).OpenForm(typeof(frmChangeStatus), PrimaryKeyId);

        private void FrmRecipeInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsFreshClone) return;
            var changed = dtrecipe.GetChanges() != null
                       || dtrecipeingredient.GetChanges() != null
                       || dtrecipesteps.GetChanges() != null;
            var prompt = changed
                ? $"Do you want to save the changes to {GetRecipeDesc()}?"
                : $"Do you want to save {GetRecipeDesc()}?";
            var res = MessageBox.Show(prompt, "Confirm Save",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
                e.Cancel = !SaveData();
            else if (res == DialogResult.No)
                recipe.Delete(dtrecipe);
            else
                e.Cancel = true;
        }
    }
}