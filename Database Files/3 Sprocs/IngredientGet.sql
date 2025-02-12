create or alter procedure dbo.IngredientGet(@IngredientId int = 0, @All bit = 0, @IngredientName varchar(50) = '')
as 
begin 
    select i.IngredientId, i.IngredientName
    from Ingredient i
    where i.IngredientId = @IngredientId
    or @All = 1
    or (i.IngredientName like '%' + @IngredientName + '%' and  @IngredientName <> '')
    order by i.IngredientName

end
go 