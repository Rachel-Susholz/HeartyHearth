create or alter proc dbo.CloneARecipe
(
    @BaseRecipeId int,
    @RecipeId int output,
    @Message varchar(1000) output
)
as
begin
    set nocount on
    
    begin try 
        declare @OriginalRecipeName varchar(255);
        declare @NewRecipeName varchar(255);

        select @OriginalRecipeName = RecipeName
        from  Recipe
        where RecipeId = @BaseRecipeId;
        
        if (@OriginalRecipeName is null)
        begin
            set @Message = 'Original recipe not found.';
            return -1;
        end
        
        set @NewRecipeName = @OriginalRecipeName + ' - clone';
        
        -- Insert the cloned recipe.
        insert into Recipe (RecipeName, StaffMemberId, CuisineId, Drafted, Calories)
        select @NewRecipeName, StaffMemberId, CuisineId, Drafted, Calories
        from Recipe
        where RecipeId = @BaseRecipeId;
        
        set @RecipeId = SCOPE_IDENTITY();
        
        -- Clone the recipe ingredients.
        insert into RecipeIngredient (RecipeId, Amount, MeasurementId, IngredientId, IngredientSequence)
        select @RecipeId, Amount, MeasurementId, IngredientId, IngredientSequence
        from RecipeIngredient
        where RecipeId = @BaseRecipeId;
        
        -- Clone the recipe directions.
        insert into RecipeDirection (RecipeId, DirectionSequence, Directions)
        select @RecipeId, DirectionSequence, Directions
        from RecipeDirection
        where RecipeId = @BaseRecipeId;
        
        set @Message = 'Clone successful.'
        return 0;
    end try
    begin catch 
        set @Message = ERROR_MESSAGE();
        return -1;
    end catch
end
go
