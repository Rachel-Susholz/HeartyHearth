namespace HeartyHearthSystem
{
    public class recipe
    {
        public static DataTable SearchRecipes(string recipename)
        {
            DataTable dt = new();

            SqlCommand cmd = SQLUtility.GetSqlCommand("RecipeNameAndIdGet");

            SQLUtility.SetParamValue(cmd, "@RecipeName", recipename);
            if (recipename == "")
            {
                cmd.Parameters["@All"].Value = 1;
            }

            dt = SQLUtility.GetDataTable(cmd);

            return dt;
        }
        public static DataTable Load(int recipeid)
        {

            DataTable dt = new();

            SqlCommand cmd = SQLUtility.GetSqlCommand("RecipeGet");

            SQLUtility.SetParamValue(cmd, "@RecipeId", recipeid);

            dt = SQLUtility.GetDataTable(cmd);

            return dt;

        }
        public static DataTable GetCuisineList()
        {
            DataTable dt = new();

            SqlCommand cmd = SQLUtility.GetSqlCommand("CuisineGet");

            SQLUtility.SetParamValue(cmd, "@All", 1);

            dt = SQLUtility.GetDataTable(cmd);

            return dt;

        }
        public static DataTable GetUserList()
        {
            DataTable dt = new();

            SqlCommand cmd = SQLUtility.GetSqlCommand("StaffMemberGet");

            SQLUtility.SetParamValue(cmd, "@All", 1);

            dt = SQLUtility.GetDataTable(cmd);

            return dt;
        }
        public static void Save(DataTable dtRecipe)
        {
            //SQLUtility.DebugPrintDataTable(dtRecipe);
;            if (dtRecipe.Rows.Count == 0)
            {
                throw new Exception("Cannot call Recipe Save method because there are no rows in the table.");
            }
            DataRow r = dtRecipe.Rows[0];
            SQLUtility.SaveDataRow(r, "RecipeUpdate");      

        }
       public static void Delete(DataTable dtRecipe)
        {
            int id = (int)dtRecipe.Rows[0]["RecipeId"];
            SqlCommand cmd = SQLUtility.GetSqlCommand("RecipeDelete");
            SQLUtility.SetParamValue(cmd, "@RecipeId", id);
            SQLUtility.ExecuteSQL(cmd);
            
        }

    }

}
