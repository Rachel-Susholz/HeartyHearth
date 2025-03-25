create or alter procedure dbo.CourseTypeDelete(@CourseTypeId int, @Message varchar(500) = '' output)
as 
begin 
    declare @Return int = 0;
    if exists (select 1 from MealCourse where CourseTypeId = @CourseTypeId)
    begin
        select @Message = 'Cannot delete course because it is assigned to one or more meals.', @Return = 1;
        return @Return;
    end

    delete from Course where CourseTypeId = @CourseTypeId;
    return 0;
end 
go
