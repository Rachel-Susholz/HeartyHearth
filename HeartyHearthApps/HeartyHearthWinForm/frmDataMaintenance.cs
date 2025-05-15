using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Data;
using System.Drawing;

namespace HeartyHearthWinForm
{
    public partial class frmDataMaintenance : Form
    {
        private enum TableTypeEnum { StaffMember, Cuisine, Ingredient, Measurement, CourseType }
        DataTable dtlist = new();
        TableTypeEnum currenttabletype = TableTypeEnum.StaffMember;
        string deleteColumnName = "deletecolumn";
        private BindingSource bsData = new BindingSource();

        public frmDataMaintenance()
        {
            InitializeComponent();
            btnSave.Click += BtnSave_Click;
            this.FormClosing += FrmDataMaintenance_FormClosing;
            gData.CellContentClick += GData_CellContentClick;
            SetUpRadioButtons();
            BindData(currenttabletype);
        }

        private void BindData(TableTypeEnum tableType)
        {
            currenttabletype = tableType;
            dtlist = DataMaintenance.GetDataList(tableType.ToString());
            dtlist.AcceptChanges();

            bsData.DataSource = dtlist;
            bsData.ListChanged -= BsData_ListChanged;
            bsData.ListChanged += BsData_ListChanged;

            gData.DataSource = bsData;

            if (gData.Columns.Contains(deleteColumnName))
                gData.Columns.Remove(deleteColumnName);
            WindowsFormsUtility.AddDeleteButtonToGrid(gData, deleteColumnName);
            WindowsFormsUtility.FormatGridForEdit(gData, tableType.ToString());

            gData.EditingControlShowing += gData_EditingControlShowing;

            btnSave.Enabled = false;
        }

        private void BsData_ListChanged(object sender, ListChangedEventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void gData_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox oldTb)
                oldTb.KeyPress -= NumericKeyPress;
            if (gData.CurrentCell.OwningColumn.Name == "CourseSequence"
             && e.Control is TextBox tb)
            {
                tb.KeyPress += NumericKeyPress;
            }
        }

        private void NumericKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private bool Save()
        {
            bool success = false;
            Cursor = Cursors.WaitCursor;
            try
            {
                DataMaintenance.SaveDataList(dtlist, currenttabletype.ToString());
                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            return success;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!Save()) return;    
            MessageBox.Show("Saved!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dtlist.AcceptChanges();     
            btnSave.Enabled = false;
        }

        private void Delete(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= gData.Rows.Count)
                return;

            int id = WindowsFormsUtility.GetIdFromGrid(gData, rowIndex, currenttabletype.ToString() + "Id");

            string msg = (currenttabletype == TableTypeEnum.StaffMember)
                ? "Are you sure you want to delete this user and all related recipes, meals, and cookbooks?"
                : "Are you sure you want to delete this record?";

            if (MessageBox.Show(msg, "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    DataMaintenance.DeleteRow(currenttabletype.ToString(), id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Delete error: " + ex.Message, Application.ProductName);
                    return;
                }
                BindData(currenttabletype);
                btnSave.Enabled = true;
            }
        }

        private void GData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (gData.Columns[e.ColumnIndex].Name != deleteColumnName) return;

            var row = gData.Rows[e.RowIndex];
            var drv = row.DataBoundItem as DataRowView;
            bool isUnsaved = row.IsNewRow
                || (drv != null && drv.Row.RowState == DataRowState.Added);
            if (isUnsaved)
            {
                return;
            }

            Delete(e.RowIndex);
        }

        private void SetUpRadioButtons()
        {
            foreach (Control c in pnlOptionButtons.Controls)
            {
                if (c is RadioButton rb)
                {
                    rb.Click += (s, e) =>
                    {
                        if (rb.Tag is TableTypeEnum type)
                            BindData(type);
                    };
                }
            }
            optUsers.Tag = TableTypeEnum.StaffMember;
            optCuisines.Tag = TableTypeEnum.Cuisine;
            optIngredients.Tag = TableTypeEnum.Ingredient;
            optMeasurements.Tag = TableTypeEnum.Measurement;
            optCourses.Tag = TableTypeEnum.CourseType;
        }

        private void FrmDataMaintenance_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SQLUtility.DoesTableHaveChanges(dtlist))
            {
                var res = MessageBox.Show($"Do you want to save changes to {this.Text} before closing?",
                    Application.ProductName, MessageBoxButtons.YesNoCancel);
                if (res == DialogResult.Yes)
                {
                    if (!Save())
                    {
                        e.Cancel = true;
                        this.Activate();
                    }
                }
                else if (res == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    this.Activate();
                }
            }
        }
    }
}
