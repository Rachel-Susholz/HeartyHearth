namespace HeartyHearthWinForm
{
    public partial class frmCookbookInfo : MultiFormBase
    {
        private DataTable dtCookbook, dtRecipes;
        private const string DeleteCol = "deletecol";

        public frmCookbookInfo(int id)
        {
            InitializeComponent();
            PrimaryKeyId = id;

            Text = id == 0
                ? "Cookbook - New Cookbook"
                : "Cookbook -";

            Load += OnLoad;
            btnSave.Click += SaveAll_Click;
            btnSaveRecipe.Click += SaveAll_Click;
            btnDelete.Click += BtnDelete_Click;

            lstUserName.DropDownStyle = ComboBoxStyle.DropDownList;
            txtCreated.ReadOnly = true;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            LoadCookbook();
            LoadRecipesGrid();
            UpdateButtons();
        }

        private void LoadCookbook()
        {
            dtCookbook = cookbook.LoadCookbook(PrimaryKeyId);

            if (dtCookbook.Rows.Count == 0)
            {
                var r = dtCookbook.NewRow();
                r["CookbookName"] = "";
                r["Price"] = 0m;
                r["CookbookStatus"] = false;
                r["Created"] = DBNull.Value;
                r["StaffMemberId"] = 0;
                dtCookbook.Rows.Add(r);
            }

            BindSource.DataSource = dtCookbook;
            WindowsFormsUtility.SetControlBinding(txtCookbookName, BindSource);

            txtPrice.DataBindings.Clear();
            txtPrice.DataBindings.Add("Text", BindSource, "Price", true, DataSourceUpdateMode.OnPropertyChanged, "0.00");
            txtPrice.KeyPress += (s, ev) =>
            {
                if (!char.IsControl(ev.KeyChar)
                    && !char.IsDigit(ev.KeyChar)
                    && ev.KeyChar != '.')
                    ev.Handled = true;
                if (ev.KeyChar == '.' && txtPrice.Text.Contains("."))
                    ev.Handled = true;
            };

            cbxCookbookStatus.DataBindings.Clear();
            cbxCookbookStatus.DataBindings.Add("Checked", BindSource, "CookbookStatus", false, DataSourceUpdateMode.OnPropertyChanged);

            WindowsFormsUtility.BindOutputDateControl(txtCreated, BindSource, "Created");

            lstUserName.DataBindings.Clear();
            WindowsFormsUtility.SetListBinding(lstUserName, recipe.GetUserList(), dtCookbook, "StaffMember");

            dtCookbook.AcceptChanges();
            UpdateTitle();
        }

        private void LoadRecipesGrid()
        {
            dtRecipes = CookbookRecipe.LoadByCookbookId(PrimaryKeyId);
            if (dtRecipes.Columns.Contains("RecipeSequence"))
                dtRecipes.Columns["RecipeSequence"].ColumnName = "Sequence";
            dtRecipes.Columns["CookbookId"].DefaultValue = PrimaryKeyId;
            gCookbookRecipes.Columns.Clear();
            gCookbookRecipes.DataSource = dtRecipes;
            WindowsFormsUtility.FormatGridForEdit(gCookbookRecipes, "CookbookRecipe");
            WindowsFormsUtility.AddComboBoxToGrid(gCookbookRecipes, DataMaintenance.GetDataList("Recipe"), "RecipeName", "Recipe");
            gCookbookRecipes.DataBindingComplete += Grid_DataBindingComplete;
            if (!gCookbookRecipes.Columns.Contains(DeleteCol))
            {
                var del = new DataGridViewButtonColumn
                {
                    Name = DeleteCol,
                    HeaderText = "Delete",
                    Text = "X",
                    UseColumnTextForButtonValue = true,
                    FlatStyle = FlatStyle.Flat
                };
                gCookbookRecipes.Columns.Add(del);
            }

            gCookbookRecipes.AllowUserToAddRows = true;
            GridHelper.AttachNumericKeyPressHandler(gCookbookRecipes, "Sequence");

            gCookbookRecipes.CellContentClick += Grid_CellContentClick;
        }

        private void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = gCookbookRecipes.Rows[e.RowIndex];
            var cell = row.Cells[DeleteCol];
            if (cell.ReadOnly) return;

            MessageBox.Show(
                "Are you sure you want to delete this recipe?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            ).OnlyIfYes(() =>
            {
                ((DataRowView)row.DataBoundItem).Row.Delete();
                dtRecipes.AcceptChanges();
                UpdateDeleteButtons();
            });
        }

        private void Grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var combo = gCookbookRecipes.Columns["RecipeCombo"];
            if (combo != null)
                combo.DisplayIndex = 0;

            var seq = gCookbookRecipes.Columns["Sequence"];
            if (seq != null)
                seq.DisplayIndex = 1;

            var delCol = gCookbookRecipes.Columns[DeleteCol];
            if (delCol != null)
                delCol.DisplayIndex = gCookbookRecipes.Columns.Count - 1;

            int delIdx = delCol?.Index ?? -1;
            if (delIdx >= 0)
            {
                foreach (DataGridViewRow row in gCookbookRecipes.Rows)
                {
                    var drv = row.DataBoundItem as DataRowView;
                    bool canDelete = drv != null
                                     && drv.Row.RowState == DataRowState.Unchanged;

                    var cell = (DataGridViewButtonCell)row.Cells[delIdx];
                    cell.ReadOnly = !canDelete;
                    cell.Style.ForeColor =
                        canDelete ? Color.Black : Color.Gray;
                    cell.Style.BackColor =
                        canDelete
                          ? gCookbookRecipes.DefaultCellStyle.BackColor
                          : SystemColors.Control;
                    cell.Style.SelectionBackColor = cell.Style.BackColor;
                    cell.Value = canDelete ? "X" : "";
                }
            }
        }

        private void UpdateDeleteButtons()
        {
            int idx = gCookbookRecipes.Columns[DeleteCol].Index;

            foreach (DataGridViewRow row in gCookbookRecipes.Rows)
            {
                var drv = row.DataBoundItem as DataRowView;
                bool canDelete = drv != null
                                 && drv.Row.RowState == DataRowState.Unchanged;

                var cell = (DataGridViewButtonCell)row.Cells[idx];
                cell.ReadOnly = !canDelete;
                cell.Style.ForeColor = canDelete ? Color.Black : Color.Gray;
                cell.Style.BackColor = canDelete
                    ? gCookbookRecipes.DefaultCellStyle.BackColor
                    : SystemColors.Control;
                cell.Style.SelectionBackColor = cell.Style.BackColor;
                cell.Value = canDelete ? "X" : "";
            }
        }

        private void SaveAll_Click(object sender, EventArgs e)
        {
            try
            {
                // ─── 1) Save the cookbook header ───────────────────────────
                // if it’s new, let the proc set GETDATE()
                if (dtCookbook.Rows[0]["Created"] == DBNull.Value)
                    dtCookbook.Rows[0]["Created"] = DBNull.Value;

                cookbook.SaveCookbook(dtCookbook);       // will throw on failure
                dtCookbook.AcceptChanges();
                PrimaryKeyId = SQLUtility.GetValueFromFirstRowAsInt(
                                  dtCookbook, "CookbookId"
                              );

                // ─── 2) Stamp any new recipe rows with that FK ─────────────
                dtRecipes.Columns["CookbookId"].DefaultValue = PrimaryKeyId;
                foreach (DataRow r in dtRecipes.Rows
                                           .Cast<DataRow>()
                                           .Where(r => r.RowState == DataRowState.Added))
                {
                    r["CookbookId"] = PrimaryKeyId;
                }

                // ─── 3) Save the recipes ───────────────────────────────────
                CookbookRecipe.Save(dtRecipes);         // will throw on failure
                dtRecipes.AcceptChanges();
                UpdateDeleteButtons();

                // ─── 4) Reload everything and update UI ────────────────────
                LoadCookbook();
                LoadRecipesGrid();
                UpdateButtons();

                MessageBox.Show(
                    "Saved!",
                    "Save",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error saving data:\n" + ex.Message,
                    "Save Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void BtnDelete_Click(object s, EventArgs e)
        {
            MessageBox.Show(
                $"Delete “{GetTitle()}” and its recipes?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            ).OnlyIfYes(() =>
            {
                cookbook.DeleteCookbook(dtCookbook);
                Close();
            });
        }

        private void UpdateTitle() => Text = $"Cookbook - {GetTitle()}";
        private string GetTitle()
        {
            var name = (dtCookbook.Rows[0]["CookbookName"] as string)?.Trim();
            return string.IsNullOrEmpty(name) ? "New Cookbook" : name;
        }

        private void UpdateButtons()
        {
            bool isNew = PrimaryKeyId == 0 || GetTitle() == "New Cookbook";
            btnDelete.Enabled = !isNew;
            btnSaveRecipe.Enabled = !isNew;
        }

        protected override DataTable[] GetDataTablesForChangeCheck() =>
            new[] { dtCookbook, dtRecipes };

        protected override bool SaveData()
        {
            SaveAll_Click(this, EventArgs.Empty);
            return PrimaryKeyId != 0;
        }
    }
    static class DialogExtensions
    {
        public static void OnlyIfYes(this DialogResult r, Action yes)
        {
            if (r == DialogResult.Yes) yes();
        }
    }
}
