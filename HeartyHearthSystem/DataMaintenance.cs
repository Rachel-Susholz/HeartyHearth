using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeartyHearthSystem
{
    public static class DataMaintenance
    {
        public static DataTable GetDataList(string tablename)
        {
            DataTable dt = new();

            SqlCommand cmd = SQLUtility.GetSqlCommand(tablename + "Get");

            SQLUtility.SetParamValue(cmd, "@All", 1);

            dt = SQLUtility.GetDataTable(cmd);

            return dt;
        }
        
        public static void SaveDataList(DataTable dt, string tablename)
        {
            SQLUtility.SaveDataTable(dt, tablename + "Update");
        }

        public static void DeleteRow(string tablename, int id)
        {
            SqlCommand cmd = SQLUtility.GetSqlCommand(tablename + "Delete");
            SQLUtility.SetParamValue(cmd, $"@{tablename}Id", id);
            SQLUtility.ExecuteSQL(cmd);
        }
    }
}
