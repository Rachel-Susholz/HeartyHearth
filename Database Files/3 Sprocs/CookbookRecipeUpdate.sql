create or alter procedure dbo.CookbookRecipeUpdate
(
    @CookbookRecipeId int     output,
    @CookbookId       int,
    @RecipeId         int,
    @Sequence         int
)
as
begin
    set nocount on;

    select @CookbookRecipeId = isnull(@CookbookRecipeId, 0);

    if @CookbookRecipeId = 0
    begin
        insert into CookbookRecipe
            (CookbookId, RecipeId, RecipeSequence)
        values
            (@CookbookId, @RecipeId, @Sequence);

        select @CookbookRecipeId = scope_identity();
    end
    else
    begin
        update CookbookRecipe
        set
            RecipeId       = @RecipeId,
            RecipeSequence = @Sequence
        where CookbookRecipeId = @CookbookRecipeId;
    end
end
go