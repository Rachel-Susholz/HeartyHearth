create or alter procedure DashboardCountsGet
as
begin
    select
        (select count(*) from Recipe) as NumRecipes,
        (select count(*) from Meal) as NumMeals,
        (select count(*) from Cookbook) as NumCookbooks
end;
