create or alter procedure dbo.IngredientDelete(
    @IngredientId int,
    @Message varchar(500) = '' output
)
as 
begin 
    set nocount on
    declare @Return int = 0

    if not exists (select 1 from Ingredient where IngredientId = @IngredientId)
    begin
        select @Return = 1, @Message = 'Ingredient does not exist.'
        return @Return
    end

    begin try 
        begin tran

        delete from RecipeIngredient
            where IngredientId = @IngredientId
        delete from Ingredient
            where IngredientId = @IngredientId

        commit tran
    end try 
    begin catch 
        rollback
        select @Return = 1, @Message = 'Error deleting ingredient. Please try again.' + error_Message()
    end catch

    return @Return
end 
go