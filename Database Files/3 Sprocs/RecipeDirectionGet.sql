create or alter procedure dbo.RecipeDirectionGet
    @RecipeDirectionId int = 0,
    @RecipeId int = 0,
    @All bit = 0,
    @Message varchar(500) = '' output
as
begin
    declare @return int = 0
    select @All = isnull(@All, 0), @RecipeDirectionId = isnull(@RecipeDirectionId, 0), @RecipeId = isnull(@RecipeId, 0)
    select RecipeDirectionId, RecipeId, Directions, DirectionSequence
    from RecipeDirection
    where RecipeDirectionId = @RecipeDirectionId
       or @All = 1
       or RecipeId = @RecipeId
    order by DirectionSequence
    return @return
end
go
