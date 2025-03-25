create or alter procedure dbo.RecipeDirectionDelete
    @RecipeDirectionId int,
    @Message varchar(500) = '' output
as
begin
    declare @return int = 0
    delete from RecipeDirection where RecipeDirectionId = @RecipeDirectionId
    return @return
end
go
