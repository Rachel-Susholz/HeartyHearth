create or alter procedure dbo.CuisineDelete(
    @CuisineId int,
    @Message varchar(500) = '' output
)
as 
begin 
    set nocount on
    declare @Return int = 0

    if not exists (select 1 from Cuisine where CuisineId = @CuisineId)
    begin
        select @Return = 1, @Message = 'Cuisine does not exist.'
        return @Return
    end

    begin try 
        begin tran

        delete from RecipeDirection
            where RecipeId in (select RecipeId from Recipe where CuisineId = @CuisineId)
        delete from RecipeIngredient
            where RecipeId in (select RecipeId from Recipe where CuisineId = @CuisineId)
        delete from CourseRecipe
            where RecipeId in (select RecipeId from Recipe where CuisineId = @CuisineId)
        delete from CookbookRecipe
            where RecipeId in (select RecipeId from Recipe where CuisineId = @CuisineId)
        delete from Recipe
            where CuisineId = @CuisineId
        delete from Cuisine
            where CuisineId = @CuisineId

        commit tran
    end try 
    begin catch 
        rollback
        select @Return = 1, 
               @Message = 'Error deleting cuisine. Please try again.' + error_Message()
    end catch

    return @Return
end 
go
