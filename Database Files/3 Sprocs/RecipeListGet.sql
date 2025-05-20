--AS Try combining this sproc with the regular get sproc for improvement.
create or alter procedure RecipeListGet
as 
begin 
    select 
        r.RecipeId,
        r.RecipeName,
        r.RecipeStatus,
        sm.UserName,
        r.Calories,
        count(i.IngredientId) as NumIngredients
    from Recipe r
    left join dbo.RecipeIngredient ri on ri.RecipeId = r.RecipeId
    left join dbo.Ingredient i on i.IngredientId = ri.IngredientId 
    join StaffMember sm
    on sm.StaffMemberId = r.StaffMemberId
    group by r.RecipeId, r.RecipeName, r.RecipeStatus, sm.UserName, r.Calories
    order by 
  case 
    when RecipeStatus = 'published' then 1
    when RecipeStatus = 'drafted' then 2
    when RecipeStatus = 'archived' then 3
  end;
end;