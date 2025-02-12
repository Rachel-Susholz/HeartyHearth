using HeartyHearthSystem;

namespace HeartyHearthWinForm
{
    public partial class frmDataMaintenance : Form
    {
        private enum TableTypeEnum { StaffMember, Cuisine, Ingredient, Measurement, CourseType }
        DataTable dtlist = new();
        TableTypeEnum currenttabletype = TableTypeEnum.StaffMember;
        string deletecolumnname = "deletecolumn";
        public frmDataMaintenance()
        {
            InitializeComponent();
            btnSave.Click += BtnSave_Click;
            this.FormClosing += FrmDataMaintenance_FormClosing;
            gData.CellContentClick += GData_CellContentClick;
            SetUpRadioButtons();
            BindData(currenttabletype);
        }

       

        private void BindData(TableTypeEnum tabletype)
        {
            currenttabletype = tabletype;
            dtlist = DataMaintenance.GetDataList(currenttabletype.ToString());
            gData.Columns.Clear();
            gData.DataSource = dtlist;
            gData.Columns.Add(new DataGridViewButtonColumn() { Text = "X", HeaderText = "Delete", Name = deletecolumnname, UseColumnTextForButtonValue = true });
            WindowsFormsUtility.FormatGridForEdit(gData, currenttabletype.ToString());
        }

        private bool Save()
        {
            bool b = false;
            Cursor = Cursors.WaitCursor;
            try
            {
                DataMaintenance.SaveDataList(dtlist, currenttabletype.ToString());
                b = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            return b;
        }

        private void Delete(int rowindex)
        {
            int id = WindowsFormsUtility.GetIdFromGrid(gData, rowindex, currenttabletype.ToString() + "Id");

            if (id == 0 && rowindex < gData.Rows.Count)
            {
                gData.Rows.Remove(gData.Rows[rowindex]); 
                return;
            }

            if (id != 0)
            { }
                string message = "Are you sure you want to delete this record?";
                if (currenttabletype == TableTypeEnum.StaffMember)
                {
                    message = "Are you sure you want to delete this user and all related recipes, meals, and cookbooks?";
                }

                DialogResult result = MessageBox.Show(message, "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    return;
                }

                try
                {
                    DataMaintenance.DeleteRow(currenttabletype.ToString(), id); 
                    BindData(currenttabletype); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName);
                }
            }
        

        private void SetUpRadioButtons()
        {
            foreach (Control c in pnlOptionButtons.Controls)
            {
                if (c is RadioButton)
                {
                    c.Click += C_Click;
                }
            }
            optUsers.Tag = TableTypeEnum.StaffMember;
            optCuisines.Tag = TableTypeEnum.Cuisine;
            optIngredients.Tag = TableTypeEnum.Ingredient;
            optMeasurements.Tag = TableTypeEnum.Measurement;
            optCourses.Tag = TableTypeEnum.CourseType;
        }

        private void C_Click(object? sender, EventArgs e)
        {
            if (sender is Control && ((Control)sender).Tag is TableTypeEnum)
            {
                BindData((TableTypeEnum)((Control)sender).Tag);
            }
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            Save();
        }

        private void FrmDataMaintenance_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (SQLUtility.DoesTableHaveChanges(dtlist) == true)
            {
                var res = MessageBox.Show($"Do you want to save changes to {this.Text} before closing the form?", Application.ProductName, MessageBoxButtons.YesNoCancel);

                switch (res)
                {
                    case DialogResult.Yes:
                        bool b = Save();
                        if (b == false)
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
        private void GData_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (gData.Columns[e.ColumnIndex].Name == deletecolumnname)
            {
                Delete(e.RowIndex);
            }
        }
        
    }
}
