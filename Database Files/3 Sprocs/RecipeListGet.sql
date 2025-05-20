--AS Try combining this sproc with the regular get sproc for improvement.
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
    order by 
  case 
    when RecipeStatus = 'published' then 1
    when RecipeStatus = 'drafted' then 2
    when RecipeStatus = 'archived' then 3
  end;
end;