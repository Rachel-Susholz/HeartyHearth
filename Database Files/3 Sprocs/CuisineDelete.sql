create or alter procedure dbo.CuisineDelete(@CuisineId int, @Message varchar(500) = '' output)
as 
begin
    declare @Return int = 0; 
    if exists (select 1 from Recipe where CuisineId = @CuisineId)
    begin
        select @Message = 'Cannot delete cuisine because it is assigned to one or more recipes.', @Return = 1;
        return @Return;
    end

    delete from Cuisine where CuisineId = @CuisineId;
    return 0;
end 
go
