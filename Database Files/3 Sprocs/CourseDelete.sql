create or alter procedure dbo.CourseTypeDelete(
    @CourseTypeId int,
    @Message varchar(500) = '' output
)
as 
begin 
    set nocount on
    declare @Return int = 0

    if not exists (select 1 from CourseType where CourseTypeId = @CourseTypeId)
    begin
        select @Return = 1, @Message = 'Course type does not exist.'
        return @Return
    end

    begin try 
        begin tran

        delete from CourseRecipe
            where MealCourseId in (
                select MealCourseId 
                  from MealCourse 
                 where CourseTypeId = @CourseTypeId
            )
        delete from MealCourse
            where CourseTypeId = @CourseTypeId
        delete from CourseType
            where CourseTypeId = @CourseTypeId

        commit tran
    end try 
    begin catch 
        rollback
        select @Return = 1, 
               @Message = 'Error deleting course type. Please try again.' + error_Message()
    end catch

    return @Return
end 
go