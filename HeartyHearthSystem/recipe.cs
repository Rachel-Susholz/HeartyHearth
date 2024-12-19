using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPUFramework;

namespace HeartyHearthSystem
{
    public class recipe
    {
        public static DataTable SearchRecipes(string recipename)
        {
            DataTable dt = new();

            SqlCommand cmd = SQLUtility.GetSqlCommand("RecipeGet");

            cmd.Parameters["@RecipeName"].Value = recipename;

            dt = SQLUtility.GetDataTable(cmd);

            return dt;
        }
        public static DataTable Load(int recipeid)
        {
            DataTable dt = new();

            SqlCommand cmd = SQLUtility.GetSqlCommand("RecipeGet");

            cmd.Parameters["@RecipeId"].Value = recipeid;

            dt = SQLUtility.GetDataTable(cmd);

            return dt;

        }
        public static DataTable GetCuisineList()
        {
            DataTable dt = new();

            SqlCommand cmd = SQLUtility.GetSqlCommand("CuisineGet");

            cmd.Parameters["@All"].Value = 1;

            dt = SQLUtility.GetDataTable(cmd);

            return dt;

        }
        public static DataTable GetUserList()
        {
            DataTable dt = new();

            SqlCommand cmd = SQLUtility.GetSqlCommand("StaffMemberGet");

            cmd.Parameters["@All"].Value = 1;

            dt = SQLUtility.GetDataTable(cmd);

            return dt;
        }
        public static void Save(DataTable dtRecipe)
        {
            //SQLUtility.DebugPrintDataTable(dtRecipe);
            DataRow r = dtRecipe.Rows[0];
            int id = (int)(r["RecipeId"] ?? 0); // Default to 0 if RecipeId is null
            string sql = "";

            if (id > 0) // Update existing recipe
            {
                sql = $"update recipe set " +
                      $"RecipeName = '{r["RecipeName"] ?? ""}', " +
                      $"CuisineTypeId = {(r["CuisineTypeId"] == DBNull.Value ? "NULL" : r["CuisineTypeId"])}, " +
                      $"Calories = {(r["Calories"] == DBNull.Value ? 0 : r["Calories"])}, " +
                      $"Drafted = {(r["Drafted"] == DBNull.Value ? "NULL" : $"'{r["Drafted"]}'")}, " +
                      $"Published = {(r["Published"] == DBNull.Value ? "NULL" : $"'{r["Published"]}'")}, " +
                      $"Archived = {(r["Archived"] == DBNull.Value ? "NULL" : $"'{r["Archived"]}'")}, " +
                      $"StaffMemberId = {(r["StaffMemberId"] == DBNull.Value ? "NULL" : r["StaffMemberId"])} " +
                      $"where RecipeId = {id}";
            }
            else // Insert new recipe
            {
                sql = "insert into recipe (RecipeName, CuisineTypeId, Calories,  Drafted, Published, Archived, StaffMemberId) " +
                      $"values ('{r["RecipeName"] ?? ""}', " +
                      $"{(r["CuisineTypeId"] == DBNull.Value ? "NULL" : r["CuisineTypeId"])}, " +
                      $"{(r["Calories"] == DBNull.Value ? 0 : r["Calories"])}, " +
                      $"{(r["Drafted"] == DBNull.Value ? "NULL" : $"'{r["Drafted"]}'")}, " +
                      $"{(r["Published"] == DBNull.Value ? "NULL" : $"'{r["Published"]}'")}, " +
                      $"{(r["Archived"] == DBNull.Value ? "NULL" : $"'{r["Archived"]}'")}, " +
                      $"{(r["StaffMemberId"] == DBNull.Value ? "NULL" : r["StaffMemberId"])} )";
            }



            SQLUtility.ExecuteSQL(sql);

        }
       public static void Delete(DataTable dtRecipe)
        {
            int id = (int)dtRecipe.Rows[0]["RecipeId"];
            string sql = "delete recipe where RecipeId = " + id;
            SQLUtility.ExecuteSQL(sql);
            
        }

    }

}
