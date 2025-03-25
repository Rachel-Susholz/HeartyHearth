create or alter proc dbo.CookbookRecipeUpdate(
    @CookbookRecipeId int output,
    @CookbookId int,
    @RecipeId int,  
    @Sequence int,
    @Message varchar(500) = '' output 
)
as 
begin 
declare @return int = 0

select @CookbookRecipeId = isnull(@CookbookRecipeId, 0)

if @CookbookRecipeId = 0
begin 
    insert CookbookRecipe(CookbookRecipeId, CookbookId, RecipeId, RecipeSequence)
    values(@CookbookRecipeId, @CookbookId, @RecipeId, @Sequence)

    select @CookbookRecipeId = scope_identity()
end 
else 
begin 
    update CookbookRecipe 
    set 
    CookbookId = @CookbookId,
    RecipeId = @RecipeId,
    RecipeSequence = @Sequence
    where CookbookRecipeId = @CookbookRecipeId
end 
return @return 
end 
go 



