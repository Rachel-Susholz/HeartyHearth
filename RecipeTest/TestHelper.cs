using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeTest
{
    public static class TestHelper
    {
        public static int GetMaxId(string tableName, string columnName)
        {
            string sql = $"select max({columnName}) from {tableName}";
            DataTable result = SQLUtility.ExecuteSQL(sql);

            if (result.Rows.Count > 0 && result.Rows[0][0] != DBNull.Value)
            {
                return (int)result.Rows[0][0];
            }
            else
            {
                return 0; // Return 0 if no rows or the max value is NULL
            }
        }

        public static int GetMaxRecipeId()
        {
            return GetMaxId("recipe", "recipeid");
        }

        public static int GetValidCuisineId()
        {
            return GetMaxId("recipe", "CuisineId");
        }

        public static int GetValidStaffMemberId()
        {
            return GetMaxId("recipe", "StaffmemberId");
        }

        

    }
    }

