create or alter procedure RecipeListGet
as 
begin 
    select 
        r.RecipeId,
        r.RecipeName,
        r.RecipeStatus,
        sm.UserName,
        r.Calories
    from Recipe r
    join StaffMember sm
    on sm.StaffMemberId = r.StaffMemberId
    order by RecipeName;
end;