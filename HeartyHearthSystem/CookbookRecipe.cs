namespace HeartyHearthSystem
{
    public class CookbookRecipe
    {
        public static DataTable LoadByCookbookId(int cookbookid)
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSqlCommand("CookbookRecipeGet");
            SQLUtility.SetParamValue(cmd, "@CookbookId", cookbookid);
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static bool Save(DataTable dt)
        {
            
                SQLUtility.SaveDataTable(dt, "CookbookRecipeUpdate");
                return true;
          
        }

    }
}
