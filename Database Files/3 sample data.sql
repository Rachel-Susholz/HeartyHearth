--AS Great job, 97%
--AS -3 This file cannot be run repeatedly. The delete is not in the correct order.
--RS it was in the correct order. It just was missing the courserecipe delete. I mistakenly saved the work before inserting it, but I did notice it before submitting.

go
delete CookbookRecipe
delete Cookbook
delete CourseRecipe
delete MealCourse
delete Meal
delete CourseType
delete RecipeDirection
delete RecipeIngredient
delete Measurement
delete Recipe
delete Ingredient
delete CuisineType
delete StaffMember
go

-- 1) Staff Members
insert StaffMember(UserName, FirstName, LastName)
select 'jdoe', 'John', 'Doe'
union select 'asmith', 'Alice', 'Smith'
union select 'mjohnson', 'Michael', 'Johnson'

-- 2) Cuisine Types
insert CuisineType(CuisineName)
select 'American'
union select 'French'
union select 'English'
union select 'Italian'
union select 'Mexican'

-- 3) Ingredients
insert Ingredient(IngredientName)
select 'sugar'
union select 'oil'
union select 'eggs'
union select 'flour'
union select 'vanilla sugar'
union select 'baking powder'
union select 'baking soda'
union select 'chocolate chips'
union select 'granny smith apples'
union select 'vanilla yogurt'
union select 'orange juice'
union select 'honey'
union select 'ice cubes'
union select 'club bread'
union select 'butter'
union select 'shredded cheese'
union select 'garlic'
union select 'black pepper'
union select 'salt'
union select 'vanilla pudding'
union select 'whipped cream cheese'
union select 'sour cream cheese'
union select 'onion'
union select 'spaghetti'
union select 'parmesan cheese'
union select 'marinated beef'
union select 'tortillas'
union select 'cilantro'
union select 'lime'
union select 'fresh mozzarella'
union select 'tomatoes'
union select 'basil'
union select 'olive oil'
union select 'balsamic vinegar'

-- 4) Recipes
;
with x as (
    select CuisineName = 'American', RecipeName = 'Chocolate Chip Cookies', Calories = 200, UserName = 'jdoe', Drafted = '2024-01-01', Published = '2024-01-15', Archived = null
    union select 'French', 'Apple Yogurt Smoothie', 150, 'asmith', '2024-01-05', '2024-01-20', null
    union select 'English', 'Cheese Bread', 300, 'jdoe', '2024-01-10', null, null
    union select 'American', 'Butter Muffins', 250, 'asmith', '2024-01-15', '2024-02-01', null
    union select 'Italian', 'Spaghetti Carbonara', 400, 'jdoe', '2024-01-20', '2024-02-05', null
    union select 'Mexican', 'Tacos al Pastor', 350, 'asmith', '2024-01-25', null, null
    union select 'Italian', 'Caprese Salad', 200, 'mjohnson', '2024-02-01', null, '2024-02-15'
)
insert Recipe(CuisineId, RecipeName, Calories, StaffMemberId, Drafted,Published, Archived)
select ct.CuisineId, x.RecipeName, x.Calories, sm.StaffMemberId, x.Drafted, x.Published, x.Archived
from x
join CuisineType ct 
on x.CuisineName = ct.CuisineName
join StaffMember sm 
on x.UserName = sm.UserName

-- 5) Measurements
insert Measurement(MeasurementType)
select 'cup'
union select 'tbsp'
union select 'tsp'
union select 'oz'
union select 'stick'
union select 'clove'
union select 'pinch'
union select 'unit'

-- 6) Recipe Ingredients
;
with x as (
    select RecipeName = 'Chocolate Chip Cookies', IngredientName = 'sugar', MeasurementType = 'cup', Amount = 1, IngredientSequence = 1
    union select 'Chocolate Chip Cookies', 'oil', 'cup', 0.5, 2
    union select 'Chocolate Chip Cookies', 'eggs', 'unit', 3, 3
    union select 'Chocolate Chip Cookies', 'flour', 'cup', 2, 4
    union select 'Chocolate Chip Cookies', 'vanilla sugar', 'tsp', 1, 5
    union select 'Chocolate Chip Cookies', 'baking powder', 'tsp', 2, 6
    union select 'Chocolate Chip Cookies', 'baking soda', 'tsp', 0.5, 7
    union select 'Chocolate Chip Cookies', 'chocolate chips', 'cup', 1, 8
    union select 'Apple Yogurt Smoothie', 'granny smith apples', 'unit', 3, 1
    union select 'Apple Yogurt Smoothie', 'vanilla yogurt', 'cup', 2, 2
    union select 'Apple Yogurt Smoothie', 'sugar', 'tsp', 2, 3
    union select 'Apple Yogurt Smoothie', 'orange juice', 'cup', 0.5, 4
    union select 'Apple Yogurt Smoothie', 'honey', 'tbsp', 2, 5
    union select 'Apple Yogurt Smoothie', 'ice cubes', 'unit', 6, 6
    union select 'Cheese Bread', 'club bread', 'unit', 1, 1
    union select 'Cheese Bread', 'butter', 'oz', 4, 2
    union select 'Cheese Bread', 'shredded cheese', 'oz', 8, 3
    union select 'Cheese Bread', 'garlic', 'clove', 2, 4
    union select 'Cheese Bread', 'black pepper', 'tsp', 0.25, 5
    union select 'Cheese Bread', 'salt', 'pinch', 1, 6
    union select 'Butter Muffins', 'butter', 'stick', 1, 1
    union select 'Butter Muffins', 'sugar', 'cup', 1, 2
    union select 'Butter Muffins', 'eggs', 'unit', 2, 3
    union select 'Butter Muffins', 'flour', 'cup', 2, 4
    union select 'Butter Muffins', 'baking powder', 'tsp', 1, 5
    union select 'Butter Muffins', 'vanilla pudding', 'oz', 1, 6
    union select 'Spaghetti Carbonara', 'spaghetti', 'oz', 8, 1
    union select 'Spaghetti Carbonara', 'onion', 'oz', 16, 2
    union select 'Spaghetti Carbonara', 'eggs', 'unit', 3, 3
    union select 'Spaghetti Carbonara', 'parmesan cheese', 'oz', 1, 4
    union select 'Spaghetti Carbonara', 'black pepper', 'tsp', 1, 5
    union select 'Tacos al Pastor', 'marinated beef', 'oz', 6, 1
    union select 'Tacos al Pastor', 'tortillas', 'unit', 8, 2
    union select 'Tacos al Pastor', 'cilantro', 'tbsp', 2, 3
    union select 'Tacos al Pastor', 'lime', 'unit', 1, 4
    union select 'Caprese Salad', 'fresh mozzarella', 'oz', 8, 1
    union select 'Caprese Salad', 'tomatoes', 'unit', 3, 2
    union select 'Caprese Salad', 'basil', 'tbsp', 1, 3
    union select 'Caprese Salad', 'olive oil', 'tbsp', 2, 4
    union select 'Caprese Salad', 'balsamic vinegar', 'tbsp', 1, 5
)
insert RecipeIngredient(RecipeId, IngredientId, MeasurementId, Amount, IngredientSequence)
select r.RecipeId, i.IngredientId, m.MeasurementId, x.Amount, x.IngredientSequence
from x
join Recipe r 
on r.RecipeName = x.RecipeName
join Ingredient i 
on i.IngredientName = x.IngredientName
join Measurement m 
on m.MeasurementType = x.MeasurementType

-- 7) Insert Recipe Directions
;
with x as (
    select RecipeName = 'Chocolate Chip Cookies', Directions = 'First combine sugar, oil and eggs in a bowl', DirectionSequence = 1
    union select 'Chocolate Chip Cookies', 'Mix well', 2
    union select 'Chocolate Chip Cookies', 'Add flour, vanilla sugar, baking powder and baking soda', 3
    union select 'Chocolate Chip Cookies', 'Beat for 5 minutes', 4
    union select 'Chocolate Chip Cookies', 'Add chocolate chips', 5
    union select 'Chocolate Chip Cookies', 'Freeze for 1-2 hours', 6
    union select 'Chocolate Chip Cookies', 'Roll into balls and place spread out on a cookie sheet', 7
    union select 'Chocolate Chip Cookies', 'Bake on 350 for 10 min.', 8
    union select 'Apple Yogurt Smoothie', 'Peel the apples and dice', 1
    union select 'Apple Yogurt Smoothie', 'Combine all ingredients in bowl except for apples and ice cubes', 2
    union select 'Apple Yogurt Smoothie', 'Mix until smooth', 3
    union select 'Apple Yogurt Smoothie', 'Add apples and ice cubes', 4
    union select 'Apple Yogurt Smoothie', 'Pour into glasses.', 5
    union select 'Cheese Bread', 'Slit bread every 3/4 inch', 1
    union select 'Cheese Bread', 'Combine all ingredients in bowl', 2
    union select 'Cheese Bread', 'Fill slits with cheese mixture', 3
    union select 'Cheese Bread', 'Wrap bread into a foil and bake for 30 minutes.', 4
    union select 'Butter Muffins', 'Cream butter with sugars', 1
    union select 'Butter Muffins', 'Add eggs and mix well', 2
    union select 'Butter Muffins', 'Slowly add rest of ingredients and mix well', 3
    union select 'Butter Muffins', 'Fill muffin pans 3/4 full and bake for 30 minutes.', 4
    union select 'Spaghetti Carbonara', 'Cook spaghetti according to package instructions', 1
    union select 'Spaghetti Carbonara', 'Fry onion in a pan', 2
    union select 'Spaghetti Carbonara', 'Beat eggs with cheese in a bowl', 3
    union select 'Spaghetti Carbonara', 'Combine spaghetti, onion, and egg mixture', 4
    union select 'Spaghetti Carbonara', 'Serve hot and sprinkle with black pepper.', 5
    union select 'Tacos al Pastor', 'Prepare the meat in advance', 1
    union select 'Tacos al Pastor', 'Warm the tortillas in a pan', 2
    union select 'Tacos al Pastor', 'Fill tortillas with beef and top with cilantro and lime', 3
    union select 'Tacos al Pastor', 'Serve with lime wedges', 4
    union select 'Caprese Salad', 'Slice mozzarella and tomatoes', 1
    union select 'Caprese Salad', 'Layer mozzarella and tomatoes', 2
    union select 'Caprese Salad', 'Drizzle with olive oil and balsamic vinegar', 3
)
insert RecipeDirection(RecipeId, Directions, DirectionSequence)
select r.RecipeId, x.Directions, x.DirectionSequence
from x
join Recipe r 
on r.RecipeName = x.RecipeName

-- 8) Meal
;
with x as (
    select MealName = 'Breakfast Bash', MealStatus = 1, Created = '2024-10-01', UserName = 'jdoe'
    union select 'Healthy Snacks', 1, '2024-10-05', 'asmith'
    union select 'Dinner Delight', 1, '2024-10-10', 'mjohnson'
)
insert Meal(MealName, MealStatus, Created, StaffMemberId)
select x.MealName, x.MealStatus, x.Created, sm.StaffMemberId
from x 
join StaffMember sm 
on x.UserName = sm.UserName

--9) CourseType
insert CourseType(CourseTypeName, CourseSequence)
select 'Appetizer', 1
union select 'Main Course', 2
union select 'Side Dish', 3

--10) MealCourse
;
with x as (
     select MealName = 'Breakfast Bash', CourseTypeName = 'Appetizer'
     union select 'Breakfast Bash', 'Main Course'
     union select 'Healthy Snacks', 'Appetizer'
     union select 'Healthy Snacks', 'Main Course'
     union select 'Dinner Delight', 'Main Course'
     union select 'Dinner Delight', 'Side Dish'
     )
insert MealCourse(MealId, CourseTypeId)
select m.MealId, ct.CourseTypeId
from x 
join Meal m 
on x.MealName = m.MealName
join CourseType ct 
on x.CourseTypeName = ct.CourseTypeName

--11) CourseRecipe
; 
with x as (
    select CourseTypeName = 'Appetizer', MealName = 'Breakfast Bash', RecipeName = 'Apple Yogurt Smoothie', IsMainDish = 0
    union select 'Main Course', 'Healthy Snacks', 'Cheese Bread', 1
    union select 'Side Dish', 'Dinner Delight', 'Caprese Salad', 0
)
insert CourseRecipe (MealCourseId, RecipeId, IsMainDish)
select mc.MealCourseId, r.RecipeId, x.IsMainDish
from x
join Meal m 
on m.MealName = x.MealName
join CourseType ct 
on ct.CourseTypeName = x.CourseTypeName
join Recipe r 
on r.RecipeName = x.RecipeName
join MealCourse mc 
on mc.MealId = m.MealId 
and mc.CoursetypeId = ct.CourseTypeId

--12) Cookbook
;
with x as (
    select CookbookName = 'Quick Breakfast Recipes', Price = 15.99, CookbookStatus = 1, UserName = 'jdoe'
    union select 'Healthy Snack Ideas', 12.50, 1, 'asmith'
    union select 'Dinner Done', 18.25, 1, 'mjohnson'
)
insert Cookbook (CookbookName, Price, CookBookStatus, StaffMemberId)
select x.CookbookName, x.Price, x.CookbookStatus, sm.StaffMemberId
from x
join StaffMember sm on sm.UserName = x.UserName

--13) CookbookRecipe
;
with x as (
    select CookbookName = 'Quick breakfast recipes', RecipeName = 'Chocolate Chip Cookies', RecipeSequence = 1
    union select 'Quick Breakfast Recipes', 'Butter Muffins', 2
    union select 'Healthy Snack Ideas', 'Apple Yogurt Smoothie', 1
    union select 'Dinner Done', 'Spaghetti Carbonara', 1
    union select 'Dinner Done', 'Tacos al Pastor', 2
)
insert into CookbookRecipe (CookbookId, RecipeId, RecipeSequence)
select c.CookbookId, r.RecipeId, x.RecipeSequence
from x
join Cookbook c
on c.CookbookName = x.CookbookName
join Recipe r 
on r.RecipeName = x.RecipeName