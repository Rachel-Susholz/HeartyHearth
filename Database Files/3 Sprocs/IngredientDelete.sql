create or alter procedure dbo.IngredientDelete(@IngredientId int, @Message varchar(500) = '' output)
as 
begin 
    declare @Return int = 0;
    if exists (select 1 from RecipeIngredient where IngredientId = @IngredientId)
    begin
        select @Message = 'Cannot delete ingredient because it is used in one or more recipes.', @Return = 1;
        return @Return;
    end
--AS missing delete of all it's related records.
    delete from Ingredient where IngredientId = @IngredientId;
    return 0;
end 
go
