create or alter procedure dbo.StaffMemberDelete(@StaffMemberId int, @Message varchar(500) = '' output)
as 
begin 
    set nocount on
    declare @Return int = 0

    if not exists (select 1 from StaffMember where StaffMemberId = @StaffMemberId)
    begin
        select @Return = 1, @Message = 'Staff member does not exist.'
        return @Return
    end

    begin try 
        begin tran

        delete from RecipeDirection where RecipeId in (select RecipeId from Recipe where StaffMemberId = @StaffMemberId)
        delete from RecipeIngredient where RecipeId in (select RecipeId from Recipe where StaffMemberId = @StaffMemberId)
        delete from CourseRecipe where RecipeId in (select RecipeId from Recipe where StaffMemberId = @StaffMemberId)
        delete from CookbookRecipe where RecipeId in (select RecipeId from Recipe where StaffMemberId = @StaffMemberId)
        or CookbookId in (select CookbookId from Cookbook where StaffMemberId = @StaffMemberId)
        delete from Recipe where StaffMemberId = @StaffMemberId
        delete from CourseRecipe where MealCourseId in (select MealCourseId from MealCourse where MealId in (select MealId from Meal where StaffMemberId = @StaffMemberId))
        delete from MealCourse where MealId in (select MealId from Meal where StaffMemberId = @StaffMemberId)
        delete from Meal where StaffMemberId = @StaffMemberId 
        delete from Cookbook where StaffMemberId = @StaffMemberId

        delete from StaffMember where StaffMemberId = @StaffMemberId

        commit tran
    end try 
    begin catch 
        rollback
        select @Return = 1, @Message = 'Error deleting staff member. Please try again.' + error_Message()
    end catch

    return @Return
end 
go
