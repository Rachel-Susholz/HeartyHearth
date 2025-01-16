create or alter function dbo.RecipeDesc(@RecipeId int)
returns varchar(235)
as 
begin 
    declare @value varchar(250) = ''

    select @value = concat(r.RecipeName, ' (', c.CuisineName, ') ', 'has ', 
        (select count(*) 
         from RecipeIngredient ri 
         where ri.RecipeId = r.RecipeId), 
        ' ingredients and ', 
        (select count(*) 
         from RecipeDirection rd 
         where rd.RecipeId = r.RecipeId), 
        ' steps.')
    from recipe r
    join Cuisine c 
    on r.CuisineId = c.CuisineId
    where r.RecipeId = @RecipeId

    return @value
end 
go 
select RecipeDesc = dbo.RecipeDesc(r.RecipeId)
from recipe r