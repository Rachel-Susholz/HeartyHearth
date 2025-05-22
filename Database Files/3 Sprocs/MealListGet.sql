create or alter proc dbo.MealListGet
as
begin
    select
        m.MealId,
        m.MealName,
        sm.UserName as [User],
        sum(ISNULL(r.Calories, 0)) as NumCalories,
        count(distinct mc.MealCourseId) as NumCourses,
        count(distinct cr.RecipeId) as NumRecipes
    from dbo.Meal as m
    inner join dbo.StaffMember as sm
    on m.StaffMemberId = sm.StaffMemberId
    left join dbo.MealCourse as mc
    on mc.MealId = m.MealId
    left join dbo.CourseRecipe as cr
    on cr.MealCourseId = mc.MealCourseId
    left join dbo.Recipe as r
    on r.RecipeId = cr.RecipeId
    group by
        m.MealId,
        m.MealName,
        sm.UserName
    order by
        m.MealName;
end;
go

exec dbo.MealListGet;