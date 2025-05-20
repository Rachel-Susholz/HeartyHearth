create or alter procedure dbo.MeasurementDelete(@MeasurementId int, @Message varchar(500) = '' output)
as 
begin 
    declare @Return int = 0;
    if exists (select 1 from RecipeIngredient where MeasurementId = @MeasurementId)
    begin
        select @Message = 'Cannot delete measurement because it is used in one or more recipes.', @Return = 1;
        return @Return;
    end
--AS missing delete of related records.
    delete from Measurement where MeasurementId = @MeasurementId;
    return 0;
end 
go
