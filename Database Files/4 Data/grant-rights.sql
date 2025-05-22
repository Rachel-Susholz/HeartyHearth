--use HeartyHearthDB
--go 
--select concat('grant execute on ', r.routine_name,' to approle')
--from information_schema.routines r 
--where r.routine_name not like '%GetDashboardCounts%'

grant execute on DashboardCountsGet to approle
grant execute on IngredientDelete to approle
grant execute on IngredientGet to approle
grant execute on IngredientUpdate to approle
grant execute on MealListGet to approle
grant execute on MeasurementDelete to approle
grant execute on MeasurementGet to approle
grant execute on MeasurementUpdate to approle
grant execute on RecipeDelete to approle
grant execute on RecipeDirectionDelete to approle
grant execute on RecipeDirectionGet to approle
grant execute on RecipeDirectionUpdate to approle
grant execute on RecipeIngredientDelete to approle
grant execute on RecipeIngredientGet to approle
grant execute on RecipeIngredientUpdate to approle
grant execute on RecipeListGet to approle
grant execute on RecipeUpdate to approle
grant execute on StaffMemberDelete to approle
grant execute on StaffMemberGet to approle
grant execute on StaffMemberUpdate to approle
grant execute on RecipeNameAndIdGet to approle
grant execute on CourseDelete to approle
grant execute on RecipeGet to approle
grant execute on TotalMealCalories to approle
grant execute on RecipeDesc to approle
grant execute on AutoCreateCookbook to approle
grant execute on CloneARecipe to approle
grant execute on CookbookDelete to approle
grant execute on CookbookGet to approle
grant execute on CookbookListGet to approle
grant execute on CookbookRecipeGet to approle
grant execute on CookbookRecipeUpdate to approle
grant execute on CookbookUpdate to approle
grant execute on CourseTypeDelete to approle
grant execute on CourseTypeGet to approle
grant execute on CourseTypeUpdate to approle
grant execute on CuisineDelete to approle
grant execute on CuisineGet to approle
grant execute on CuisineUpdate to approle