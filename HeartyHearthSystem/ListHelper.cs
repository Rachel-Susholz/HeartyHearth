using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using CPUWindowFormsFramework;

namespace HeartyHearthWinForm
{
    public static class ListHelper
    {
        public static void LoadGrid(DataGridView grid, DataTable dt, string hiddenColumn, Dictionary<string, string> headerOverrides)
        {
            grid.DataSource = dt;
            if (grid.Columns.Contains(hiddenColumn))
            {
                grid.Columns[hiddenColumn].Visible = false;
            }
            foreach (var pair in headerOverrides)
            {
                if (grid.Columns.Contains(pair.Key))
                {
                    grid.Columns[pair.Key].HeaderText = pair.Value;
                }
            }
            WindowsFormsUtility.FormatDataGrid(grid);
        }
    }
}
