using CPUWindowFormsFramework;

namespace HeartyHearthSystem
{
    public class RecipeStep
    {
        public static DataTable LoadByRecipeId(int recipeId)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = SQLUtility.GetSqlCommand("RecipeDirectionGet");
            SQLUtility.SetParamValue(cmd, "@RecipeId", recipeId);
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static void Save(DataTable dt)
        { 
            SQLUtility.SaveDataTable(dt, "RecipeDirectionUpdate");
        }
        
    }
}
    

