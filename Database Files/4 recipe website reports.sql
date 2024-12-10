--AS Amazing job, 95% See comments
/*
Our website development is underway! 
Below is the layout of the pages on our website, please provide the SQL to produce the necessary result sets.

Note: 
a) When the word 'specific' is used, pick one record (of the appropriate type, recipe, meal, etc.) for the query. 
    The way the website works is that a list of items are displayed and then the user picks one and navigates to the "details" page.
b) Whenever you have a record for a specific item include the name of the picture for that item. That is because the website will always show a picture of the item.
*/

/*
Home Page
    One result set with the number of recipes, meals, and cookbooks. Each row should have a column with the item name (Ex: Recipes) and a column with the count.
*/
    select
        Item = 'Recipes',
        Amount = count(*)
    from Recipe

union all

    select
        Item = 'Meals',
        Amount = count(*)
    from Meal

union all

    select
        Item = 'Cookbooks',
        Amount = count(*)
    from Cookbook

/*
Recipe list page:
    List of all Recipes that are either published or archived, published recipes should appear at the top. 
	Archived recipes should appear gray. Surround the archived recipe with <span style="color:gray">recipe name</span>
    In the resultset show the Recipe with its status, dates it was published and archived in mm/dd/yyyy format (blank if not archived), user, number of calories and number of ingredients.
    Tip: You'll need to use the convert function for the dates
*/
select RecipeName = 
    case 
        when r.RecipeStatus = 'published' then r.RecipeName 
        else '<span style="color:gray">' + r.RecipeName + '</span>'
    end,
    r.RecipeStatus,
    PublishedDate = convert(varchar(10), r.Published, 101),
    ArchivedDate = isnull(convert(varchar(10), r.Archived, 101), ''),
    sm.UserName,
    r.Calories,
    NumberOfIngredients = (select count(*)
    from RecipeIngredient ri
    where ri.RecipeId = r.RecipeId)
from Recipe r
join StaffMember sm
on r.StaffMemberId = sm.StaffMemberId
where r.RecipeStatus in ('published', 'archived')
order by r.RecipeStatus desc, r.RecipeName

/*
Recipe details page:
    Show for a specific recipe (three result sets):
        a) Recipe header: recipe name, number of calories, number of ingredients and number of steps.
        b) List of ingredients: show the measurement quantity, measurement type and ingredient in one column, sorted by sequence. Ex. 1 Teaspoon Salt  
        c) List of prep steps sorted by sequence.
*/
--A)
--AS While this works, there is no need for a subquery in the count. You can group it by the recipe and then cound distinct ingredients and steps
select
    r.RecipeName,
    r.Calories,
    NumberOfIngredients = (select count(*)
    from RecipeIngredient ri
    where ri.RecipeId = r.RecipeId),
    NumberOfSteps = (select max(DirectionSequence)
    from RecipeDirection rd
    where rd.RecipeId = r.RecipeId)
from Recipe r
where r.RecipeName = 'Cheese Bread'
--B)
select ListOfIngredients = concat(ri.Amount, ' ', m.MeasurementType, ' ', i.IngredientName)
from RecipeIngredient ri
join Measurement m
on ri.MeasurementId = m.MeasurementId
join Ingredient i
on ri.IngredientId = i.IngredientId
join Recipe r
on ri.RecipeId = r.RecipeId
where r.RecipeName = 'Cheese Bread'
order by ri.IngredientSequence
--C)
select ListOfPrepSteps = rd.Directions
from RecipeDirection rd
join Recipe r
on rd.RecipeId = r.RecipeId
where r.RecipeName = 'Cheese Bread'
order by rd.DirectionSequence
/*
Meal list page:
    For all active meals, show the meal name, user that created the meal, number of calories for the meal, number of courses, and number of recipes per each meal, sorted by name of meal
*/
select
    m.MealName,
    CreatedBy = sm.UserName,
    TotalCalories= sum(r.Calories),
    NumberOfCourses= count(mc.CourseTypeId),
    NumberOfRecipes = count(cr.RecipeId)
from Meal m
join StaffMember sm
on m.StaffMemberId = sm.StaffMemberId
join MealCourse mc
on m.MealId = mc.MealId
join CourseRecipe cr
on mc.MealCourseId = cr.MealCourseId
join Recipe r
on cr.RecipeId = r.RecipeId
where m.MealStatus = 1
group by m.MealName, sm.UserName
order by m.MealName


/*
Meal details page:
    Show for a specific meal:
        a) Meal header: meal name, user, date created.
        b) List of all recipes: Result set should have one column, including the course type, whether the dish is serverd as main/side (if it's the main course), and recipe name. 
			Format for main course: CourseType: Main/Side dish - Recipe Name. 
            Format for non-main course: CourseType: Recipe Name
            Main dishes of the main course should be bold, using the bold tags as shown below
                ex: 
                    Appetizer: Mixed Greens
                    <b>Main: Main dish - Onion Pastrami Chicken</b>
					Main: Side dish - Roasted cucumbers with mustard
*/
--A)
select m.MealName, CreatedBy = sm.UserName, DateCreated = m.Created
from Meal m
join StaffMember sm
on m.StaffMemberId = sm.StaffMemberId
where 
m.MealName = 'Breakfast Bash'
--B)
select RecipeDetails =  
case 
    when ct.CourseTypeName = 'Main Course' and cr.IsMainDish = 1 then '<b>Main Course: Main dish - ' + r.RecipeName + '</b>' 
    when ct.CourseTypeName = 'Main Course' and cr.IsMainDish = 0 then 'Main Course: Side dish - ' + r.RecipeName
    else ct.CourseTypeName + ': ' + r.RecipeName 
end
from MealCourse mc
join CourseRecipe cr
on mc.MealCourseId = cr.MealCourseId
join Recipe r
on cr.RecipeId = r.RecipeId
join CourseType ct
on mc.CourseTypeId = ct.CourseTypeId
join Meal m
on mc.MealId = m.MealId
where m.MealName = 'Breakfast Bash'

/*
Cookbook list page:
    Show all active cookbooks with author and number of recipes per book. Sorted by book name.
*/
select c.cookbookname, Author = sm.username, NumberOfRecipes = count(cr.RecipeId)
from Cookbook c
join StaffMember sm
on c.StaffMemberId = sm.StaffMemberId
join CookbookRecipe cr
on c.CookBookId = cr.CookBookId
where c.CookbookStatus = 1
group by c.CookbookName, sm.UserName
order by c.CookbookName

/*
Cookbook details page:
    Show for specific cookbook:
    a) Cookbook header: cookbook name, user, date created, price, number of recipes.
    b) List of all recipes in the correct order. Include recipe name, cuisine and number of ingredients and steps.  
        Note: User will click on recipe to see all ingredients and steps.
*/
--A) 
select c.CookbookName, Author = sm.FirstName + ' '+ sm.LastName, CreatedDate = c.Created, c.Price, NumberOfRecipes = count(cr.RecipeId)
from Cookbook c
join Staffmember sm
on c.StaffMemberId = sm.StaffMemberId
join CookbookRecipe cr
on c.CookbookId = cr.CookbookId
where c.CookbookName = 'Quick Breakfast Recipes'
group by c.CookbookName, sm.UserName, c.Created, c.Price


--B)
select r.RecipeName, ct.CuisineName, NumOfIngredients = count(distinct ri.IngredientId), NumOfSteps = count(distinct rd.RecipeDirectionId)
from Cookbook c
join CookbookRecipe cr
on c.CookbookId = cr.CookbookId
join Recipe r
on cr.RecipeId = r.RecipeId
join CuisineType ct
on r.CuisineId = ct.CuisineId
join RecipeIngredient ri
on r.RecipeId = ri.RecipeId
join RecipeDirection rd
on r.recipeid = rd.recipeid
where c.CookbookName = 'Quick Breakfast Recipes'
group by r.RecipeName, ct.CuisineName, cr.RecipeSequence
order by cr.RecipeSequence

/*
April Fools Page:
    On April 1st we have a page with a joke cookbook. For that page provide the following.
    a) A list of all the recipes that are in all cookbooks. The recipe name should be the reverse of the real name with the first letter capitalized and all others lower case.
        There are matching pictures for those names, include the reversed picture names so that we can show the joke pictures.
        Note: ".jpg" file extension must be at the end of the reversed picture name EX: Recipe_Seikooc_pihc_etalocohc.jpg
    b) When the user clicks on any recipe they should see a spoof steps lists showing the step instructions for the LAST step of EACH recipe in the system. No sequence required.
        Hint: Use CTE
*/
--A) 
select ReversedRecipeName = concat(upper(substring(reverse(r.RecipeName), 1, 1)), lower(substring(reverse(r.RecipeName), 2, len(r.RecipeName) - 1))),
    ImagePath = concat('Recipe_', replace(concat(upper(substring(reverse(r.RecipeName), 1, 1)), lower(substring(reverse(r.RecipeName), 2, len(r.RecipeName) - 1))), ' ', '_'), '.jpg')
from Recipe r
join CookbookRecipe cr
on r.RecipeId = cr.RecipeId
--B)
--AS Could be the question wasn't clear, but what is needed is to show ALL last steps from all recipes in the system when selecting any recipe
;
with x as
    (
    select RecipeId, MaxSequence = max(DirectionSequence)
    from RecipeDirection
    group by RecipeId  
    )

select
    r.RecipeName,
    rd.Directions
from Recipe r
join x
on x.RecipeId = r.RecipeId
join RecipeDirection rd 
on r.RecipeId = rd.RecipeId
where rd.DirectionSequence = x.MaxSequence
 
/*
For site administration page:
5 seperate reports
    a) List of how many recipes each user created per status. Show 0 if user has no recipes at all.
    b) List of how many recipes each user created and average amount of days that it took for the user's recipes to be published.
    c) For each user, show three columns: Total number of meals, Total Active meals, Total Inactive meals. Show 0 if none
        Hint: For active/inactive columns, use SUM function with CASE to only include in sum if active/inactive 
    d) For each user, show three columns: Total number of cookbooks, Total Active cookbooks, Total Inactive cookbooks. Show 0 if none
        Hint: For active/inactive columns, use SUM function with CASE to only include in sum if active/inactive 
    e) List of archived recipes that were never published, and how long it took for them to be archived.
*/

--A) 
select sm.FirstName, sm.LastName,
    PublishedRecipes = sum(case when r.RecipeStatus = 'published' then 1 else 0 end),
    ArchivedRecipes = sum(case when r.RecipeStatus = 'archived' then 1 else 0 end),
    DraftedRecipes = sum(case when r.RecipeStatus = 'drafted' then 1 else 0 end)
from StaffMember sm
left join Recipe r
on sm.StaffMemberId = r.StaffMemberId
group by sm.FirstName, sm.LastName
--B)
--AS What are you accomplishing with the case clause?
--RS I was just assuming that the question is only asking about published recipes and did it as a cases statement, but I switched it to a where clause.
select sm.FirstName, sm.LastName,
    TotalRecipes = count(r.RecipeId),
    AverageDaysToPublish = avg(datediff(day, r.Drafted, r.Published))
from StaffMember sm
join Recipe r
on sm.StaffMemberId = r.StaffMemberId
where r.Published is not null
group by sm.FirstName, sm.LastName

--C)
select sm.FirstName, sm.LastName, TotalMeals = count(m.MealId),
    TotalActiveMeals = sum(case when m.MealStatus = 1 then 1 else 0 end),
    TotalInactiveMeals = sum(case when m.MealStatus = 0 then 1 else 0 end)
from StaffMember sm
left join Meal m
on sm.StaffMemberId = m.StaffMemberId
group by sm.FirstName, sm.LastName
--D)
select sm.FirstName, sm.LastName, TotalCookbooks = count(c.CookbookId),
    TotalActiveCookbooks = sum(case when c.CookbookStatus = 1 then 1 else 0 end),
    TotalInactiveCookbooks = sum(case when c.CookbookStatus = 0 then 1 else 0 end)
from StaffMember sm
left join Cookbook c
on sm.StaffMemberId = c.StaffMemberId
group by sm.FirstName, sm.LastName
--E)
select r.RecipeName, r.Drafted, r.Archived, DaysToArchive = datediff(day, r.Drafted, r.Archived)
from Recipe r
where r.RecipeStatus = 'archived'
and r.Published is null

/*
For user dashboard page:
    a) For a specific user, show one result set with the number of recipes, meals, and cookbooks. Each row should have a column with the item name (Ex: Recipes) and a column with the count.
        Tip: If you would like, you can use a CTE to get the User Id once instead of in each union select
    b) List of the user's recipes, display the status and the number of hours between the status it's in and the one before that. Omit recipes in drafted status.
*/
--A)
;
with
    x
    as
    (
        select StaffMemberId
        from StaffMember
        where FirstName = 'John'
            and LastName = 'Doe'
    )

    select StaffMember = x.StaffMemberId, ItemName = 'Recipes', Count = count(*)
    from x
    left join Recipe r
    on x.StaffMemberId = r.StaffMemberId
    group by x.StaffMemberId

union all

    select StaffMember = x.StaffMemberId, ItemName = 'Meals', Count = count(*)
    from x
    left join Meal m
    on x.StaffMemberId = m.StaffMemberId
    group by x.StaffMemberId

union all

    select StaffMember = x.StaffMemberId, ItemName = 'Cookbooks', Count = count(*)
    from x
    left join Cookbook c
    on x.StaffMemberId = c.StaffMemberId
    group by x.StaffMemberId

--B)
select
    sm..StaffMemberId,
    r.RecipeName,
    r.RecipeStatus,
    HoursBtwnStatuses = 
    case 
        when r.RecipeStatus = 'published' then datediff(hour, r.drafted, r.published)
        when r.RecipeStatus = 'archived' then isnull(datediff(hour, r.published, r.archived), (datediff(hour, r.drafted, r.archived)))
    end
from Recipe r
join StaffMember sm
on r.StaffMemberId = sm.StaffMemberId
where r.recipestatus in ('published', 'archived')
and sm.FirstName = 'John'
and sm.LastName = 'Doe'









   
  
