create or alter procedure dbo.CookbookUpdate
(
    @CookbookId      int output,
    @CookbookName    varchar(150),
    @Price           decimal(10,2),
    @CookbookStatus  bit,
    @Created         datetime = null,
    @StaffMemberId   int
)
as
begin
    set nocount on;
    select @CookbookId = isnull(@CookbookId, 0);

    if @CookbookId = 0
    begin
        insert into Cookbook
            (CookbookName, Price, CookbookStatus, Created, StaffMemberId)
        values
            (
              @CookbookName,
              @Price,
              @CookbookStatus,
              getdate(),
              @StaffMemberId
            );
        select @CookbookId = scope_identity();
    end
    else
    begin
        update Cookbook
        set
            CookbookName   = @CookbookName,
            Price          = @Price,
            CookbookStatus = @CookbookStatus,
            StaffMemberId  = @StaffMemberId
        where CookbookId = @CookbookId;
    end

    return 0;
end
go