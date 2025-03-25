create or alter procedure dbo.CookbookUpdate(
    @CookbookId int output,
    @CookbookName varchar(150),
    @Price decimal(10,2),
    @CookbookStatus bit,
    @Created datetime = null, 
    @StaffMemberId int, 
    @message varchar(500) = '' output 
)
as 
begin 
    set nocount on;
    declare @return int = 0;
    
    select @CookbookId = isnull(@CookbookId, 0);
        
    if @CookbookId = 0 
    begin 
        insert into Cookbook (CookbookName, Price, CookbookStatus, Created, StaffMemberId)
        values (@CookbookName, @Price, 0, getdate(), @StaffMemberId);  
        select @CookbookId = scope_identity();
    end 
    else
    begin 
        update Cookbook 
        set 
            CookbookName = @CookbookName, 
            Price = @Price, 
            CookbookStatus = @CookbookStatus, 
            StaffMemberId = @StaffMemberId
        where CookbookId = @CookbookId;
    end

    return @return;
end
go


exec dbo.CookbookUpdate @CookbookId = 0, @CookbookName = 'Test', @Price = 10, @CookbookStatus = 0, @Created = getdate(), @StaffMemberId = 1, @message = '' output



