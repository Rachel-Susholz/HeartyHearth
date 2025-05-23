using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace RecipeTest
{
    public class Tests
    {
        string connstring = ConfigurationManager.ConnectionStrings["liveconn"].ConnectionString;
        string testconnstring = ConfigurationManager.ConnectionStrings["unittestconn"].ConnectionString;
        //"Server=.\SQLExpress;Database=HeartyHearthDB;Trusted_Connection=true"

        [SetUp]
        public void SetConnectionString()
        {
           
           DBManager.SetConnectionString(connstring, true);

        }

        private DataTable GetDataTable(string sql)
        {
            DataTable dt = new();
            DBManager.SetConnectionString(testconnstring, false);
            dt = SQLUtility.GetDataTable(sql);
            DBManager.SetConnectionString(connstring, false);
            return dt;
        }

            [Test]
        public void TestLoadRecipe()
        {
            // Arrange

            int recipeId = GetMaxRecipeId();
            Console.WriteLine($"Before Test: Load recipe with RecipeId: {recipeId}");

            // Act
            DataTable dt = recipe.Load(recipeId);

            // Assert
            Assert.IsTrue(dt.Rows.Count > 0, $"Desired Outcome: Recipe should be found for RecipeId {recipeId}");
            Console.WriteLine("After Test: Recipe details:");
            DataRow r = dt.Rows[0];
            Console.WriteLine($"RecipeId: {r["RecipeId"]}");
            Console.WriteLine($"RecipeName: {r["RecipeName"]}");
            Assert.IsTrue((int)r["RecipeId"] == recipeId, "State After Test: RecipeId should match " + recipeId);
        }

        [Test]
        public void InsertRecipe_WithUniqueName()
        {
            // Arrange
            string uniqueName = "TestRecipe_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            TestContext.WriteLine($"Inserting recipe with unique name: {uniqueName}");

            DataTable dt = recipe.Load(0); // Load an empty DataTable for a new recipe.
            dt.Rows.Add();
            DataRow row = dt.Rows[0];
            row["RecipeName"] = uniqueName;
            row["CuisineId"] = GetValidCuisineId();
            row["Calories"] = 200;
            row["Drafted"] = DateTime.Now;
            row["StaffMemberId"] = GetValidStaffMemberId();

            // Act
            recipe.Save(dt);

            // Reload the most recent recipe
            DataTable allRecipes = recipe.Load(GetMaxRecipeId());

            // Assert
            DataRow insertedRow = allRecipes.Rows[0]; 
            Assert.IsTrue(insertedRow != null, "The inserted recipe should exist in the database.");
            Assert.IsTrue(insertedRow["RecipeName"].ToString() == uniqueName, "Recipe name should match the unique name.");
            TestContext.WriteLine($"Successfully inserted RecipeName: {uniqueName}");
        }

        [Test]
        public void InsertRecipe_WithExistingName()
        {
            // Arrange
   
            string existingName = GetFirstColumnFirstRowValueAsString("select top 1 r.RecipeName from recipe r");
            TestContext.WriteLine($"Inserting recipe with existing name: {existingName}");

            DataTable newdt = recipe.Load(0); // Load an empty DataTable for a new recipe.
            newdt.Rows.Add();
            DataRow row = newdt.Rows[0];
            row["RecipeName"] = existingName;
            row["CuisineId"] = GetValidCuisineId();
            row["Calories"] = 200;
            row["Drafted"] = DateTime.Now;
            row["StaffMemberId"] = GetValidStaffMemberId();


            //Assert
            Exception ex = Assert.Throws<Exception>(() => recipe.Save(newdt));

            Console.WriteLine(ex.Message);
        }




        [Test]
        public void TestDeleteRecipe()
        
        {
            // Arrange
            int recipeId = GetMaxRecipeId();
            //this may fail if there are related tables but it does work. you can first run the test to
            //insert a record with a unique name and then run the delete and it should work.
            Console.WriteLine($"Before Test: Delete recipe with RecipeId: {recipeId}");
            DataTable dt = recipe.Load(recipeId);
            Assert.IsTrue(dt.Rows.Count > 0, "Before Test: Recipe not found for deletion.");

            // Act
            recipe.Delete(dt);

            // Assert
            DataTable checkdt = recipe.Load(recipeId); // Load again to check if it was deleted
            Console.WriteLine($"After Test: Recipe deleted with RecipeId: {recipeId}");
            Assert.IsTrue(checkdt.Rows.Count == 0, "State After Test: Recipe should be deleted.");
        }

        [Test]
        public void TestDeleteRecipeWithRelatedRecords()

        {
            // Arrange
            DataTable dt = GetDataTable("select top 1 r.RecipeId, r.RecipeName from Recipe r join RecipeIngredient ri on r.RecipeId = ri.RecipeId");
            int recipeId = GetMaxRecipeId();
            string recipename = "";
            if (dt.Rows.Count > 0)
            {
                recipeId = (int)dt.Rows[0]["RecipeId"];
                recipename = dt.Rows[0]["RecipeName"].ToString();
            }
            Assume.That(recipeId > 0, "no recipes with ingredients in DB, can't run test");
            Console.WriteLine($"Ensure that cannot delete recipe with RecipeId: {recipeId}");
            

            //Assert
            Exception ex = Assert.Throws<Exception>(() => recipe.Delete(dt));
         
            Console.WriteLine(ex.Message);
          
        }

        [Test]
        public void TestDeleteRecipeWithBusinessRule()
        {
            // Arrange
            DataTable dt = GetDataTable(
                "select top 1 * from recipe r  where" +
                "((r.RecipeStatus = 'Archived' and datediff(day, r.Archived, getdate()) < 30) or r.RecipeStatus = 'Published')");

            int recipeId = 0;
            string recipeName = "";
            string status = "";
            DateTime? statusDate = null;

            if (dt.Rows.Count > 0)
            {
                recipeId = (int)dt.Rows[0]["RecipeId"];
                recipeName = dt.Rows[0]["RecipeName"].ToString();
                status = dt.Rows[0]["RecipeStatus"].ToString();
                if (status == "Archived")
                {
                    // Only retrieve ArchivedDate if the status is Archived
                    statusDate = dt.Rows[0]["Archived"] as DateTime?;
                }
            }

            Assume.That(recipeId > 0, "No recipes found in the database, cannot run the test.");
            Console.WriteLine($"Attempting to delete recipe with RecipeId: {recipeId}, RecipeName: {recipeName}, Status: {status}, StatusDate: {statusDate?.ToShortDateString()}.");

            // Act & Assert
           

            Exception ex = Assert.Throws<Exception>(() => recipe.Delete(dt));
            
            Console.WriteLine($"Test passed: {ex.Message}");
        }



        [Test]
            public void TestGetCuisineList()
            {
                // Arrange
                Console.WriteLine("Before Test: Retrieve cuisine list.");

                // Act
                DataTable dt = recipe.GetCuisineList();

                // Assert
                Console.WriteLine("After Test: Number of cuisines available: " + dt.Rows.Count);
                Assert.IsTrue(dt.Rows.Count > 0, "Desired Outcome: There should be cuisines available.");
                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine($"CuisineId: {row["CuisineId"]}, CuisineName: {row["CuisineName"]}");
                }
            }

            [Test]
            public void TestGetUserList()
            {
                // Arrange
                Console.WriteLine("Before Test: Retrieve user list.");

                // Act
                DataTable dt = recipe.GetUserList();

                // Assert
                Console.WriteLine("After Test: Number of users available: " + dt.Rows.Count);
                Assert.IsTrue(dt.Rows.Count > 0, "Desired Outcome: There should be staff members available.");
                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine($"StaffMemberId: {row["StaffMemberId"]}, UserName: {row["UserName"]}");
                }
            }
        [Test]
        public void UpdateRecipeNameTest()
        {
            // Arrange
            int recipeId = GetMaxRecipeId(); 
            DataTable dtRecipe = recipe.Load(recipeId);
            string originalRecipeName = dtRecipe.Rows[0]["RecipeName"].ToString();
            string updatedRecipeName =  originalRecipeName + "_updated";

            // Log current state
            TestContext.WriteLine($"Original Recipe Name Before Test: {originalRecipeName}");

            // Act
            dtRecipe.Rows[0]["RecipeName"] = updatedRecipeName;
            recipe.Save(dtRecipe);

            // Assert
            DataTable updatedRecipe = recipe.Load(recipeId);
            string newRecipeName = updatedRecipe.Rows[0]["RecipeName"].ToString();
            TestContext.WriteLine($"Updated Recipe Name After Test: {newRecipeName}");
            Assert.IsTrue(newRecipeName == updatedRecipeName, "Recipe name was not updated correctly.");
        }

        [Test]
        public void UpdateRecipeNameToBlankTest()
        {
           
            int recipeId = GetMaxRecipeId();
            DataTable dtRecipe = recipe.Load(recipeId);
            string originalRecipeName = dtRecipe.Rows[0]["RecipeName"].ToString();
            string updatedRecipeName = "";

            // Log current state
            TestContext.WriteLine($"Original Recipe Name Before Test: {originalRecipeName}");
            TestContext.WriteLine($"Change Name To: {updatedRecipeName}");

            dtRecipe.Rows[0]["RecipeName"] = updatedRecipeName;
            Exception ex = Assert.Throws<Exception>(() => recipe.Save(dtRecipe));

            Console.WriteLine(ex.Message);
        }

        [Test]
        public void ChangeCuisineTypeTest()
        {
            // Arrange
            int recipeId = GetMaxRecipeId();
            DataTable dtRecipe = recipe.Load(recipeId);
            int originalCuisineId = (int)dtRecipe.Rows[0]["CuisineId"];
            int newCuisineId = GetValidCuisineId();

            // Log current state
            TestContext.WriteLine($"Before Test: Original CuisineId: {originalCuisineId}");

            // Act
            dtRecipe.Rows[0]["CuisineId"] = newCuisineId;
            recipe.Save(dtRecipe);

            // Assert
            DataTable updatedRecipe = recipe.Load(recipeId);
            int updatedCuisineId = (int)updatedRecipe.Rows[0]["CuisineId"];
            TestContext.WriteLine($"After Test: Updated CuisineId: {updatedCuisineId}");
            Assert.IsTrue(updatedCuisineId == newCuisineId, "Cuisine was not updated correctly.");
        }

        [Test]
        public void ChangeCaloriesTest()
        {
            // Arrange
            int recipeId = GetMaxRecipeId();
            DataTable dtRecipe = recipe.Load(recipeId);
            int originalCalories = (int)dtRecipe.Rows[0]["Calories"];
            int newCalories = originalCalories + 50; 

            // Log current state
            TestContext.WriteLine($"Original Calories Before Test: {originalCalories}");

            // Act
            dtRecipe.Rows[0]["Calories"] = newCalories;
            recipe.Save(dtRecipe);

            // Assert
            DataTable updatedRecipe = recipe.Load(recipeId);
            int updatedCalories = (int)updatedRecipe.Rows[0]["Calories"];
            TestContext.WriteLine($"Updated Calories After Test: {updatedCalories}");
            Assert.IsTrue(updatedCalories == newCalories, "Calories were not updated correctly.");
        }

       
        [Test]
        public void ChangeUserNameTest()
        {
            // Arrange
            int recipeId = GetMaxRecipeId();
            DataTable dtRecipe = recipe.Load(recipeId);
            int originalStaffMemberId = (int)dtRecipe.Rows[0]["StaffMemberId"];
            int newStaffMemberId = GetValidStaffMemberId(); 

            // Log current state
            TestContext.WriteLine($"Before Test: Original StaffMemberId: {originalStaffMemberId}");

            // Act
            dtRecipe.Rows[0]["StaffMemberId"] = newStaffMemberId;
            recipe.Save(dtRecipe);

            // Assert
            DataTable updatedRecipe = recipe.Load(recipeId);
            int updatedStaffMemberId = (int)updatedRecipe.Rows[0]["StaffMemberId"];
            TestContext.WriteLine($"After Test: Updated StaffMemberId: {updatedStaffMemberId}");
            Assert.IsTrue(updatedStaffMemberId == newStaffMemberId, "User name was not updated correctly.");
        }

        //Helper functions 
        public int GetMaxId(string tableName, string columnName)
        {
            DBManager.SetConnectionString(testconnstring, false);
            string sql = $"select max({columnName}) from {tableName}";
            DataTable result = SQLUtility.ExecuteSQL(sql);

            if (result.Rows.Count > 0 && result.Rows[0][0] != DBNull.Value)
            {
                return (int)result.Rows[0][0];
            }
            else
            {
                return 0; 
            }
            DBManager.SetConnectionString(connstring, false);
        }

        public int GetMaxRecipeId()
        {
            return GetMaxId("recipe", "recipeid");
        }

        public int GetValidCuisineId()
        {
            return GetMaxId("recipe", "CuisineId");
        }

        public int GetValidStaffMemberId()
        {
            return GetMaxId("recipe", "StaffmemberId");
        }
        private string GetFirstColumnFirstRowValueAsString(string query)
        {
            SQLUtility.ConnectionString = testconnstring;

            DataTable dt = GetDataTable(query);

            SQLUtility.ConnectionString = connstring;

            return (dt.Rows.Count > 0)
                 ? dt.Rows[0][0]?.ToString() ?? ""
                 : "";
        }



    }
}



