using HeartyHearthSystem;
using System.Data;

namespace RecipeTest
{
    public class Tests
    {
        [SetUp]
        public void SetConnectionString()
        {
            DBManager.SetConnectionString("Server=tcp:dev-rochelsusholz.database.windows.net,1433; Initial Catalog=HeartyHearthDB;Persist Security Info=False;User ID=rsadmin;Password=Rochel@9225; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30");
        }

            [Test]
            public void TestSearchRecipes()
            {
                // Arrange
                string searchKeyword = "muffin";
                Console.WriteLine("Before Test: Search for recipes with keyword: " + searchKeyword);

                // Act
                DataTable dt = recipe.SearchRecipes(searchKeyword);

                // Assert
                Console.WriteLine("After Test: Number of recipes found: " + dt.Rows.Count);
                Assert.IsTrue(dt.Rows.Count > 0, "Desired Outcome: Recipes should be found.");
                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine($"RecipeId: {row["RecipeId"]}, RecipeName: {row["RecipeName"]}");
                }
            }

            [Test]
        public void TestLoadRecipe()
        {
            // Arrange

            int recipeId = TestHelper.GetMaxRecipeId();
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
            row["CuisineTypeId"] = TestHelper.GetValidCuisineTypeId();
            row["Calories"] = 200;
            row["Drafted"] = DateTime.Now;
            row["StaffMemberId"] = TestHelper.GetValidStaffMemberId();

            // Act
            recipe.Save(dt);

            // Reload the most recent recipe
            DataTable allRecipes = recipe.Load(TestHelper.GetMaxRecipeId());

            // Assert
            DataRow insertedRow = allRecipes.Rows[0]; 
            Assert.IsTrue(insertedRow != null, "The inserted recipe should exist in the database.");
            Assert.IsTrue(insertedRow["RecipeName"].ToString() == uniqueName, "Recipe name should match the unique name.");
            TestContext.WriteLine($"Successfully inserted RecipeName: {uniqueName}");
        }




        [Test]
        public void TestDeleteRecipe()
        
        {
            // Arrange
            int recipeId = TestHelper.GetMaxRecipeId();
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
                    Console.WriteLine($"CuisineTypeId: {row["CuisineTypeId"]}, CuisineName: {row["CuisineName"]}");
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
            int recipeId = TestHelper.GetMaxRecipeId(); 
            DataTable dtRecipe = recipe.Load(recipeId);
            string originalRecipeName = dtRecipe.Rows[0]["RecipeName"].ToString();
            string updatedRecipeName = originalRecipeName + "_Updated";

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
        public void ChangeCuisineTypeTest()
        {
            // Arrange
            int recipeId = TestHelper.GetMaxRecipeId();
            DataTable dtRecipe = recipe.Load(recipeId);
            int originalCuisineTypeId = (int)dtRecipe.Rows[0]["CuisineTypeId"];
            int newCuisineTypeId = 2; // Assuming 2 is a valid CuisineTypeId.

            // Log current state
            TestContext.WriteLine($"Before Test: Original CuisineTypeId: {originalCuisineTypeId}");

            // Act
            dtRecipe.Rows[0]["CuisineTypeId"] = newCuisineTypeId;
            recipe.Save(dtRecipe);

            // Assert
            DataTable updatedRecipe = recipe.Load(recipeId);
            int updatedCuisineTypeId = (int)updatedRecipe.Rows[0]["CuisineTypeId"];
            TestContext.WriteLine($"After Test: Updated CuisineTypeId: {updatedCuisineTypeId}");
            Assert.IsTrue(updatedCuisineTypeId == newCuisineTypeId, "Cuisine type was not updated correctly.");
        }

        [Test]
        public void ChangeCaloriesTest()
        {
            // Arrange
            int recipeId = TestHelper.GetMaxRecipeId();
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
            int recipeId = TestHelper.GetMaxRecipeId();
            DataTable dtRecipe = recipe.Load(recipeId);
            int originalStaffMemberId = (int)dtRecipe.Rows[0]["StaffMemberId"];
            int newStaffMemberId = 2; // Assuming 2 is a valid StaffMemberId.

            // Log current state
            TestContext.WriteLine($"Before Test: Original StaffMemberId: {originalStaffMemberId}");

            // Act
            dtRecipe.Rows[0]["StaffMemberId"] = newStaffMemberId;
            recipe.Save(dtRecipe);

            // Assert
            DataTable updatedRecipe = recipe.Load(recipeId);
            int updatedStaffMemberId = (int)updatedRecipe.Rows[0]["StaffMemberId"];
            TestContext.WriteLine($"After Test: Updated StaffMemberId: {updatedStaffMemberId}");
            Assert.IsTrue(updatedStaffMemberId == newStaffMemberId, "Cuisine type was not updated correctly.");
        }

    }
}



