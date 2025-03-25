create or alter procedure dbo.RecipeIngredientGet(@RecipeIngredientId int = 0, @RecipeId int = 0, @All bit = 0, @Message varchar(500) = '' output)
as 
begin 
    declare @return int = 0

    select @All = isnull(@All, 0), @RecipeIngredientId = isnull(@RecipeIngredientId,0), @RecipeId = isnull(@RecipeId,0)

    select ri.RecipeIngredientId, ri.RecipeId, ri.IngredientId, ri.MeasurementId, Quantity = ri.Amount, Sequence = ri.IngredientSequence
    from RecipeIngredient ri
    where ri.RecipeIngredientId = @RecipeIngredientId
    or @All = 1
    or ri.RecipeId = @RecipeId
    order by ri.IngredientSequence
    
    return @return
end
go 

