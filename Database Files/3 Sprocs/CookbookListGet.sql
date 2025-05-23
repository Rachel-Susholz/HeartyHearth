create or alter procedure CookbookListGet
as
begin
    select 
         c.CookbookId,
         c.CookbookName,
         sm.Username as Author,
         count(r.recipeid) as NumRecipes,
         Price
    from Cookbook c
    left join CookbookRecipe cr 
    on cr.CookbookId = c.CookbookId
    left join Recipe r 
    on r.RecipeId = cr.RecipeId
    join staffmember sm 
    on sm.staffmemberid = c.staffmemberid
    group by 
         c.cookbookid, 
         c.cookbookname, 
         sm.username,
         c.cookbookstatus,
         c.price
end;

 