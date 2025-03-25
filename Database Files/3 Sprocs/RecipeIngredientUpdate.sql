create or alter proc dbo.RecipeIngredientUpdate(
    @RecipeIngredientId int output,
    @RecipeId int,
    @IngredientId int,
    @MeasurementId int,
    @Amount decimal(6, 2),
    @IngredientSequence int,
    @Message varchar(500) = '' output 
)
as 
begin 
declare @return int = 0

select @RecipeIngredientId = isnull(@RecipeIngredientId, 0)

if @RecipeIngredientId = 0
begin 
    insert RecipeIngredient(RecipeId, IngredientId, MeasurementId, Amount, IngredientSequence)
    values(@RecipeId, @IngredientId, @MeasurementId, @Amount, @IngredientSequence)

    select @RecipeIngredientId = scope_identity()
end 
else 
begin 
    update RecipeIngredient 
    set 
    RecipeId = @RecipeId,
    IngredientId = @IngredientId,
    MeasurementId = @MeasurementId,
    Amount = @Amount,
    IngredientSequence = @IngredientSequence
    where RecipeIngredientId = @RecipeIngredientId
end 
return @return 
end 
go 




