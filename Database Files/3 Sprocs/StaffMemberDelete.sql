create or alter procedure dbo.StaffMemberDelete(@StaffMemberId int, @Message varchar(500) = '' output)
as 
begin 
    declare @Return int = 0

    -- Check if staff member exists
    if not exists (select 1 from StaffMember where StaffMemberId = @StaffMemberId)
    begin
        select @Return = 1, @Message = 'Staff member does not exist.'
        return @Return
    end

    begin try 
        begin tran

        -- Delete related recipes
        delete from RecipeDirection where RecipeId in (select RecipeId from Recipe where StaffMemberId = @StaffMemberId);
        delete from RecipeIngredient where RecipeId in (select RecipeId from Recipe where StaffMemberId = @StaffMemberId);
        delete from Recipe where StaffMemberId = @StaffMemberId;

        -- Delete related meals
        delete from MealRecipe where MealId in (select MealId from Meal where StaffMemberId = @StaffMemberId);
        delete from Meal where StaffMemberId = @StaffMemberId;

        -- Delete related cookbooks
        delete from CookbookRecipe where CookbookId in (select CookbookId from Cookbook where StaffMemberId = @StaffMemberId);
        delete from Cookbook where StaffMemberId = @StaffMemberId;

        -- Finally, delete the staff member
        delete from StaffMember where StaffMemberId = @StaffMemberId;

        commit
    end try 
    begin catch 
        rollback;
        select @Return = 1, @Message = 'Error deleting staff member. Please try again.';
    end catch

    return @Return
end 
go
