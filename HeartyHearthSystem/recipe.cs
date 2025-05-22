namespace HeartyHearthSystem
{
    public class recipe
    {
        private static DataTable RunStoredProc(string procName, Action<SqlCommand> setParams = null)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = SQLUtility.GetSqlCommand(procName);
            setParams?.Invoke(cmd);
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static DataTable Load(int recipeid)
        {
            return RunStoredProc("RecipeGet", cmd =>
            {
                SQLUtility.SetParamValue(cmd, "@RecipeId", recipeid);
            });
        }

        public static DataTable GetRecipeList()
        {
            return RunStoredProc("RecipeListGet");
        }

        public static DataTable GetCuisineList()
        {
            return RunStoredProc("CuisineGet", cmd =>
            {
                SQLUtility.SetParamValue(cmd, "@All", 1);
            });
        }

        public static DataTable GetUserList()
        {
            return RunStoredProc("StaffMemberGet", cmd =>
            {
                SQLUtility.SetParamValue(cmd, "@All", 1);
            });
        }

        public static DataTable GetMealList()
        {
            return RunStoredProc("MealListGet");
        }

        public static DataTable GetDashboardCounts()
        {
            return RunStoredProc("DashboardCountsGet");
        }

        private static void SaveRow(DataTable dt, string sprocName)
        {
            if (dt.Rows.Count == 0)
                throw new Exception($"Cannot call {sprocName} because there are no rows in the table.");
            DataRow r = dt.Rows[0];
            SQLUtility.SaveDataRow(r, sprocName);
        }

        public static void Save(DataTable dtRecipe)
        {
            SaveRow(dtRecipe, "RecipeUpdate");
        }

        public static void Delete(DataTable dtRecipe)
        {
            int id = (int)dtRecipe.Rows[0]["RecipeId"];
            SqlCommand cmd = SQLUtility.GetSqlCommand("RecipeDelete");
            SQLUtility.SetParamValue(cmd, "@RecipeId", id);
            SQLUtility.ExecuteSQL(cmd);
        }


        public static void ChangeStatus(int recipeId, string newStatus)
        {
            DataTable dt = Load(recipeId);
            if (dt.Rows.Count == 0)
                throw new Exception("Recipe not found.");

            DataRow row = dt.Rows[0];
            DateTime now = DateTime.Now;

            if (newStatus.Equals("Drafted", StringComparison.OrdinalIgnoreCase))
            {
                row["Drafted"] = now;
                row["Published"] = DBNull.Value;
                row["Archived"] = DBNull.Value;
            }
            else if (newStatus.Equals("Published", StringComparison.OrdinalIgnoreCase))
            {
                row["Published"] = now;
                row["Archived"] = DBNull.Value;
            }
            else if (newStatus.Equals("Archived", StringComparison.OrdinalIgnoreCase))
            {
                row["Archived"] = now;
            }

            Save(dt);
        }
    }
}
