using System;
using System.Collections.Generic;
using System.Data;
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
            string sql = "select RecipeId, RecipeName from Recipe r where r.RecipeName like '%" + recipename + "%'";
            DataTable dt = SQLUtility.GetDataTable(sql);
            return dt;
        }
        public static DataTable Load(int recipeid)
        {
            string sql = "select r.RecipeId, r.RecipeName, ct.CuisineTypeId, ct.CuisineName, r.Calories,  r.RecipeStatus, r.Drafted, r.Archived, " +
            "r.Published, sm.StaffMemberId, sm.UserName " +
            "from Recipe r join CuisineType ct on r.CuisineTypeId = ct.CuisineTypeId join StaffMember sm on r.StaffMemberId = sm.StaffMemberId where r.RecipeId = " + recipeid.ToString();
            return SQLUtility.GetDataTable(sql);
           
        }
        public static DataTable GetCuisineList()
        {
             return SQLUtility.GetDataTable("Select CuisineTypeId, CuisineName from CuisineType");
            
        }
        public static DataTable GetUserList()
        {
             return SQLUtility.GetDataTable("Select StaffMemberId, UserName from StaffMember");
        }
        public static void Save(DataTable dtRecipe)
        {
            SQLUtility.DebugPrintDataTable(dtRecipe);
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
