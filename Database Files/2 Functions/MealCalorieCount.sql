create or alter function dbo.TotalMealCalories(@MealId int)
returns int
as
begin
    declare @TotalCalories int = 0;

    select @TotalCalories = sum(r.Calories)
    from Meal m
    join MealCourse mc
        on m.MealId = mc.MealId
    join CourseRecipe cr
        on mc.MealCourseId = cr.MealCourseId
    join Recipe r
        on cr.RecipeId = r.RecipeId
    where m.MealId = @MealId;

    return @TotalCalories;
end
go

select dbo.TotalMealCalories(m.MealId) as TotalCalories
from Meal m
