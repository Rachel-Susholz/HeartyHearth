create or alter procedure dbo.RecipeIngredientDelete
    @RecipeIngredientId int,
    @Message varchar(500) = '' output
as
begin
    declare @return int = 0
    delete from RecipeIngredient where RecipeIngredientId = @RecipeIngredientId
    return @return
end
go
