/*
--AS You didn't put in any nulls or not blank constraints. You don't have to, just make sure you put it in the actual tables. From experience I would recommend that you do put it in here.

User
    UserId int, primary key 
    Username varchar(50), unique
    FirstName varchar(50)
    LastName varchar(50)

CuisineType
    CuisineId int, primary key
    CuisineName varchar(50), unique

Ingredient
    IngredientId int, primary key
    IngredientName varchar(100), unique
    ImagePath

Recipe
    RecipeId int, primary key
    CuisineId (fk - CuisineType)
    RecipeName varchar(150), unique
    --AS Should be more then 0
    Calories int
    --AS Status should be computed of the dates columns
    Status as case (
        when archived is not null then archived
        when published is not null and archived is null then published
        else drafted
        end )
    Drafted datetime default getdate not null 
    Published datetime
    Archived datetime
    --AS You need to add constraints to ensure that the dates make sense. What comes first, and ensure nothing is a future date.
    ImagePath 
    UserId (fk - User)

Measurement
    MeasurementId int primary key 
    MeasurementType varchar(50)

RecipeIngredient
    RecipeIngredientId int, primary key
    RecipeId (fk - Recipe)
    IngredientId (fk - Ingredient)
    MeasurementId (fk - Measurement)
    Amount decimal (6, 2)
    Sequence int 
    --AS This constraint will allow one recipe to have 2 ingredients by the 1 sequence as long as the ingredientid is diffrent. That shouldn't be allowed
    --AS Better, but you should also make sure that the ingredient cannot be repeated in the recipe twice
    Unique RecipeId, Sequence

RecipeDirection
    RecipeDirectionId int, primary key
    RecipeId (fk - Recipe)
    Directions text
    Sequence int
    Unique RecipeId, Sequence

Meal
    MealId int, primary key
    MealName varchar(100), unique
    Status bit
    ImagePath 
    Created datetime default getdate
    UserId (fk - User)

CourseType
    CourseTypeId int, primary key
    CourseTypeName varchar(50), unique
    --AS Make sure its greater then 0
    Sequence int 


MealCourse
    MealCourseId int, primary key
    MealId (fk - Meal)
    CourseTypeId (fk - CourseType)
    Unique MealId, CourseTypeId  


CourseRecipe
    CourseRecipeId int, primary key
    MealCourseId (fk -> MealCourse)
    RecipeId (fk -> Recipe)
    IsMainDish bit
    Unique MealCourseId, RecipeId

Cookbook
    CookbookId int, primary key
    CookbookName varchar(100), unique
    Price decimal(10,2)
    Status bit
    ImagePath
    Created datetime
    UserID (fk - User)

CookbookRecipe
    CookbookRecipeId int, primary key
    CookbookId (fk - Cookbook)
    RecipeId (fk - Recipe)
    Sequence int
    Unique CookbookId, RecipeId
    Unique CookbookId, Sequence
/*