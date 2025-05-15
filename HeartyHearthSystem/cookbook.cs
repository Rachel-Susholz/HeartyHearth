namespace HeartyHearthSystem
{
    public class cookbook
    {
        private static DataTable RunStoredProc(string procName, Action<SqlCommand> setParams = null)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = SQLUtility.GetSqlCommand(procName);
            setParams?.Invoke(cmd);
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }
        public static DataTable LoadCookbook(int cookbookid)
        {
            return RunStoredProc("CookbookGet", cmd =>
            {
                SQLUtility.SetParamValue(cmd, "@CookbookId", cookbookid);
            });
        }
        public static DataTable GetCookbookList()
        {
            return RunStoredProc("CookbookListGet");
        }

        private static void SaveRow(DataTable dt, string sprocName)
        {
            if (dt.Rows.Count == 0)
                throw new Exception($"Cannot call {sprocName} because there are no rows in the table.");
            DataRow r = dt.Rows[0];
            SQLUtility.SaveDataRow(r, sprocName);
        }
        public static bool SaveCookbook(DataTable dtCookbook)
        {
            try
            {
                SaveRow(dtCookbook, "CookbookUpdate");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool DeleteCookbook(DataTable dtCookbook)
        {
            int id = (int)dtCookbook.Rows[0]["CookbookId"];
            SqlCommand cmd = SQLUtility.GetSqlCommand("CookbookDelete");
            SQLUtility.SetParamValue(cmd, "@CookbookId", id);

            try
            {
                SQLUtility.ExecuteSQL(cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
