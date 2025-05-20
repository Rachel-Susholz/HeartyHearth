create or alter procedure dbo.RecipeGet(@RecipeId int = 0, @All bit = 0, @RecipeName varchar(150) = '')
as 
begin 
    select r.RecipeId, r.RecipeName, r.CuisineId, r.Calories, r.RecipeStatus, r.Drafted, r.Published, r.Archived, r.StaffMemberId
    from recipe r
    where r.RecipeId = @RecipeId
    or @All = 1
    or (r.RecipeName like '%' + @RecipeName + '%' and @RecipeName <> '')
    order by r.RecipeName, r.RecipeStatus

end
go 

exec RecipeGet

exec RecipeGet @All = 1

exec RecipeGet @RecipeName = ''
exec RecipeGet @RecipeName = 'm'

declare @id int 
select top 1 @id = r.RecipeId from recipe r


exec RecipeGet @RecipeId = @id
