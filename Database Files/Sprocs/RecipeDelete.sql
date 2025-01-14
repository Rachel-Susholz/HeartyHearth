create or alter procedure dbo.RecipeDelete(@RecipeId int, @Message varchar(500) = '' output)
as 
begin 
    declare @Return int = 0

    if not exists (select * from recipe r where r.RecipeId = @RecipeId and 
    ((r.RecipeStatus = 'Archived' and datediff(day, r.Archived, getdate()) > 30) or r.RecipeStatus = 'Drafted'))
    begin
        select @Return = 1, @Message = 'Cannot delete recipe that has a status of published or that is archived for 30 days or less'
        goto finished
    end

    begin try 
        begin tran
        delete RecipeDirection where RecipeId = @RecipeId
        delete RecipeIngredient where RecipeId = @RecipeId
        delete Recipe where RecipeId = @RecipeId
        commit
    end try 
    begin catch 
        rollback;
        throw
    end catch

    finished: 
    return @return
end 
go

--Test 1
set nocount on;
declare @recipeid int;


-- Identify a single record that does not match the business rule
select top 1 @recipeid = r.RecipeId
from Recipe r
where not (
    r.RecipeStatus = 'drafted'
   or (r.RecipeStatus = 'archived' and datediff(day, r.Archived, getdate()) > 30)
   )
and r.RecipeName = 'Apple Pie'
order by r.RecipeId;

-- Display the record to be deleted
select *
from Recipe r
where r.RecipeId = @recipeid;

-- Delete the record
declare @Return int, @Message varchar(500)
exec @Return = RecipeDelete @RecipeId = @recipeid, @Message = @Message output

select @Return, @Message
-- Display records matching the business rule AFTER deletion
select *
from Recipe r

--Test 2
set nocount on;
declare @recipeid int;


-- Identify a single record that matches the business rule
select top 1 @recipeid = r.RecipeId
from Recipe r
where (r.RecipeStatus = 'drafted'
   or (r.RecipeStatus = 'archived' and datediff(day, r.Archived, getdate()) > 30))
and r.RecipeName = 'Garlic Knots'
order by r.RecipeId;

-- Display the record to be deleted
select *
from Recipe r
where r.RecipeId = @recipeid;

-- Delete the record
declare @Return int, @Message varchar(500)
exec @Return = RecipeDelete @RecipeId = @recipeid, @Message = @Message output

select @Return, @Message

-- Display records matching the business rule AFTER deletion
select *
from Recipe r


