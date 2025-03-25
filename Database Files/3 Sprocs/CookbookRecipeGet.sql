create or alter procedure dbo.CookbookRecipeGet(@CookbookRecipeId int = 0, @CookbookId int = 0, @All bit = 0, @Message varchar(500) = '' output)
as 
begin 
    declare @return int = 0

    select @All = isnull(@All, 0), @CookbookRecipeId = isnull(@CookbookRecipeId,0), @CookbookId = isnull(@CookbookId,0)

    select cr.CookbookRecipeId, cr.CookbookId, cr.RecipeId, Sequence = cr.RecipeSequence 
    from CookbookRecipe cr
    where cr.CookbookRecipeId = @CookbookRecipeId
    or @All = 1
    or cr.CookbookId = @CookbookId
    order by cr.RecipeSequence
    
    return @return
end
go 

