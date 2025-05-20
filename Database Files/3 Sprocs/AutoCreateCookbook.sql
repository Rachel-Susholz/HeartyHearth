
create or alter procedure dbo.AutoCreateCookbook
    @StaffMemberId int,
    @NewCookbookId int output
as 
begin 
    set nocount on

    declare @FirstName varchar(50),
            @LastName varchar(50),
            @CookbookName varchar(100),
            @RecipeCount int,
            @Price decimal;

    select @FirstName = FirstName, @LastName = LastName
    from StaffMember
    where StaffMemberId = @StaffMemberId;

--AS This case will never happen since a cookbook always has a user and firstname and lastname can't be null in the user table.
    if @FirstName is null or @LastName is null 
    begin 
        raiserror ('User not found.', 16, 1);
        return;
    end

    set @CookbookName = 'Recipes by ' + @FirstName + ' ' + @LastName;

    select @RecipeCount = count(*)
    from Recipe
    where StaffMemberId = @StaffMemberId;

--AS We want to allow creating a cookbook for a user even if they don't have any recipes, then just create the book without the recipes.
    if @RecipeCount = 0
    begin
        raiserror('No recipes found for this user.', 16, 1);
        return;
    end

    set @Price = @RecipeCount * 1.33;

    insert into Cookbook (CookbookName, Price, CookbookStatus, Created, StaffMemberId)
    values (@CookbookName, @Price, 1, GETDATE(), @StaffMemberId);

    set @NewCookbookId = SCOPE_IDENTITY();

    ;
    with OrderedRecipes as (
        select RecipeId,
               ROW_NUMBER() over (order by RecipeName) as RecipeSequence
        from Recipe
        where StaffMemberId = @StaffMemberId
    )
    insert into CookbookRecipe (CookbookId, RecipeId, RecipeSequence)
    select @NewCookbookId, RecipeId, RecipeSequence
    from OrderedRecipes;
end
GO
