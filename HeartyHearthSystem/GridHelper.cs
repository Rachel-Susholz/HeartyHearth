namespace CPUWindowFormsFramework
{
    public static class GridHelper
    {
        public static void AttachNumericKeyPressHandler(DataGridView grid, params string[] columnNames)
        {
            grid.EditingControlShowing += (sender, e) =>
            {
                if (grid.CurrentCell != null)
                {
                    string colName = grid.Columns[grid.CurrentCell.ColumnIndex].Name;
                    if (columnNames.Contains(colName) && e.Control is TextBox tb)
                    {
                        tb.KeyPress += NumericKeyPress;
                    }
                }
            };
        }

        private static void NumericKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        public static void AttachCellBeginEditHandler(DataGridView grid, string[] targetColumns, Func<DataGridViewRow, bool> canEditFunc, string errorMessage)
        {
            grid.CellBeginEdit += (sender, e) =>
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
                string colName = grid.Columns[e.ColumnIndex].Name;
                if (targetColumns.Contains(colName))
                {
                    DataGridViewRow row = grid.Rows[e.RowIndex];
                    if (!canEditFunc(row))
                    {
                        MessageBox.Show(errorMessage, "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                    }
                }
            };
        }
        public static void AttachDeleteButtonHandler(DataGridView grid, string deleteColumnName, string confirmMessage, Func<int, bool> canDelete, Action<int> deleteAction)
        {
            grid.CellContentClick += (sender, e) =>
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;
                if (grid.Columns[e.ColumnIndex].Name == deleteColumnName)
                {
                    // Check if the row can be deleted.
                    if (!canDelete(e.RowIndex))
                    {
                        MessageBox.Show("Cannot delete placeholder row", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    var res = MessageBox.Show(confirmMessage, "Confirm Delete", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        deleteAction(e.RowIndex);
                    }
                }
            };
        }

    }
}

