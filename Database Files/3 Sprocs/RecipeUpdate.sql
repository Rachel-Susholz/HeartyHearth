create or alter proc dbo.RecipeUpdate(
    @RecipeId int output,
    @CuisineId int,
    @RecipeName varchar(150),
    @Calories int,
    @Drafted datetime = null,
    @Published datetime = null,
    @Archived datetime = null,
    @StaffMemberId int,
    @message varchar(500) = '' output 
)
as 
begin 
    declare @return int = 0 

    select @RecipeId = isnull(@RecipeId, 0)
        
    if @RecipeId = 0 
    begin 
     if @Drafted is not null or @Published is not null or @Archived is not null
        begin
            select @return = 1,
            @message = 'Date columns must use default values when inserting.' 
            goto Finished;
        end

        insert Recipe(CuisineId, RecipeName, Calories, Drafted, Published, Archived, StaffMemberId)
        values (@CuisineId, @RecipeName, @Calories, getdate(), null, null, @StaffMemberId)  

        select @RecipeId = scope_identity()
    end 
    else 
    begin
     if exists (
            select 1
            from Recipe
            where RecipeId = @RecipeId
              and (
                   @Drafted is not null
                or @Published is not null
                or @Archived is not null
              )
        )
    begin
        select @return = 1, @message = 'Date columns cannot be modified.';
        goto Finished;
    end
        update recipe 
        set 
        CuisineId = @CuisineId, 
        RecipeName = @RecipeName, 
        Calories = @Calories, 
        StaffMemberId = @StaffMemberId
        where RecipeId = @RecipeId
    end

    finished:
    return @return
end 
go

--Test Script for Insert
declare @message varchar(500) = '', @Return int, @CuisineId int, @StaffMemberId int, @RecipeId int 

select top 1 @CuisineId = CuisineId from Cuisine
select top 1 @StaffMemberId = StaffMemberId from StaffMember


exec @Return = RecipeUpdate
    @RecipeId = @RecipeId output,
    @CuisineId = @CuisineId,
    @RecipeName = 'Smoothie',
    @Calories = 125,
    @Drafted = '2024-01-01',
    @Published = '2024-01-15',
    @Archived = null,
    @StaffMemberId = @StaffMemberId,
    @message = @Message output 

select @Return, @Message, @RecipeId

select top 1 * from Recipe r where RecipeId = @RecipeId

delete Recipe where RecipeId = @RecipeId 

--Test script for update
declare
    @RecipeName varchar(150),
    @Calories int,
    @Drafted datetime,
    @Published datetime,
    @Archived datetime


select top 1
@RecipeId = r.RecipeId,
@CuisineId = r.CuisineId, 
@RecipeName = RecipeName, 
@Calories = Calories,  
@Drafted = Drafted, 
@Published = Published, 
@Archived = Archived, 
@StaffMemberId = r.StaffMemberId
from Recipe r order by r.RecipeId

select @RecipeName = reverse(@RecipeName)

exec @Return = RecipeUpdate
    @RecipeId = @RecipeId output,
    @CuisineId = @CuisineId,
    @RecipeName = @RecipeName,
    @Calories = @Calories,
    @Drafted = @Drafted,
    @Published = @Published,
    @Archived = @Archived,
    @StaffMemberId = @StaffMemberId,
    @message = @Message output 

select @Return, @Message, @RecipeId

select * from Recipe r where RecipeId = @RecipeId
