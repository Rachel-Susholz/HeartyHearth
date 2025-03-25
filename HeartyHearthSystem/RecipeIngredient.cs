using CPUWindowFormsFramework;

namespace HeartyHearthSystem
{
    public class RecipeIngredient
    {
        public static DataTable LoadByRecipeId(int recipeid)
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSqlCommand("RecipeIngredientGet");
            SQLUtility.SetParamValue(cmd, "@RecipeId", recipeid);
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static void Save(DataTable dt)
        {
            if (dt.Columns.Contains("Quantity") && !dt.Columns.Contains("Amount"))
            {
                dt.Columns["Quantity"].ColumnName = "Amount";
            }
            if (dt.Columns.Contains("Sequence") && !dt.Columns.Contains("IngredientSequence"))
            {
                dt.Columns["Sequence"].ColumnName = "IngredientSequence";
            }

            SQLUtility.SaveDataTable(dt, "RecipeIngredientUpdate");
        }  
    }
}

