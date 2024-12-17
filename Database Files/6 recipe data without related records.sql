use HeartyHearthDB
go

--Sample Data
;
with x as (union select 'Italian', 'Garlic Knots', 200, 'jdoe', '2024-12-15', null, null
    union select 'American', 'Apple Pie', 450, 'asmith', '2023-12-15', '2024-02-07', null
    )
insert RecipesForDelete(CuisineTypeId, RecipeName, Calories, StaffMemberId, Drafted,Published, Archived)
select ct.CuisineTypeId, x.RecipeName, x.Calories, sm.StaffMemberId, x.Drafted, x.Published, x.Archived
from x
join CuisineType ct 
on x.CuisineName = ct.CuisineName
join StaffMember sm 
on x.UserName = sm.UserName