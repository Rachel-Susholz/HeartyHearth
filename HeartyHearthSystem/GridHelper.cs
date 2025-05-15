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

    }
}

