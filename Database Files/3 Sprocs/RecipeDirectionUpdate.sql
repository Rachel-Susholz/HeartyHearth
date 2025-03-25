create or alter procedure dbo.RecipeDirectionUpdate
    @RecipeDirectionId int output,
    @RecipeId int,
    @Directions varchar(255),
    @DirectionSequence int,
    @Message varchar(500) = '' output
as
begin
    declare @return int = 0
    select @RecipeDirectionId = isnull(@RecipeDirectionId, 0)
    if @RecipeDirectionId = 0
    begin
        insert RecipeDirection(RecipeId, Directions, DirectionSequence)
        values (@RecipeId, @Directions, @DirectionSequence)
        select @RecipeDirectionId = scope_identity()
    end
    else
    begin
        update RecipeDirection
        set RecipeId = @RecipeId,
            Directions = @Directions,
            DirectionSequence = @DirectionSequence
        where RecipeDirectionId = @RecipeDirectionId
    end
    return @return
end
go
