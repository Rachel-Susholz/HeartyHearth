--AS This sproc should not be needed. Use regular get sproc.
create or alter procedure dbo.RecipeNameAndIdGet(@RecipeId int = 0, @All bit = 0, @RecipeName varchar(150) = '')
as 
begin 
    select r.RecipeId, r.RecipeName
    from recipe r
    where r.RecipeId = @RecipeId
    or @All = 1
    or (r.RecipeName like '%' + @RecipeName + '%' and @RecipeName <> '')
    order by r.RecipeName, r.RecipeStatus

end
go 


exec RecipeNameAndIdGet

exec RecipeNameAndIdGet @All = 1

exec RecipeNameAndIdGet @RecipeName = ''
exec RecipeNameAndIdGet @RecipeName = 'm'

declare @id int 
select top 1 @id = r.RecipeId from recipe r


exec RecipeNameAndIdGet @RecipeId = @id
