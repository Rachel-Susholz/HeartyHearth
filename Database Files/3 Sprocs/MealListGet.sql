create or alter procedure MealListGet
as
begin
    select 
         m.mealid,
         m.mealname,
         sm.username as [user],
         isnull((
             select sum(r.calories)
             from courserecipe cr
             join mealcourse mc on cr.mealcourseid = mc.mealcourseid
             join recipe r on cr.recipeid = r.recipeid
             where mc.mealid = m.mealid
         ), 0) as numcalories,
         isnull((
             select count(*) 
             from mealcourse mc 
             where mc.mealid = m.mealid
         ), 0) as numcourses,
         isnull((
             select count(*) 
             from courserecipe cr
             join mealcourse mc on cr.mealcourseid = mc.mealcourseid
             where mc.mealid = m.mealid
         ), 0) as numrecipes
    from meal m
    join staffmember sm on m.staffmemberid = sm.staffmemberid
    order by m.mealname;
end;
go

exec mealListget;

