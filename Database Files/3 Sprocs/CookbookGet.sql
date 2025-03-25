create or alter procedure dbo.CookbookGet(@CookbookId int = 0, @All bit = 0, @CookbookName varchar(150) = '')
as 
begin 
    select c.CookbookId, c.CookbookName, c.StaffMemberId, c.Price, c.Created,  CookbookStatus = c.CookbookStatus
    from Cookbook c
    where c.CookbookId = @CookbookId
    or @All = 1
    or (c.CookbookName like '%' + @CookbookName + '%' and @CookbookName <> '')

end
go 



