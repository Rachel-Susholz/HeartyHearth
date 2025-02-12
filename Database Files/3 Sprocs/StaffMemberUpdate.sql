create or alter proc dbo.StaffMemberUpdate(
    @StaffMemberId int output,
    @UserName varchar(50),
    @FirstName varchar(50),
    @LastName varchar(50),
    @message varchar(500) = '' output 
)
as 
begin 
    declare @return int = 0 

    select @StaffMemberId = isnull(@StaffMemberId, 0)
        
    if @StaffMemberId = 0 
    begin 
        insert StaffMember(UserName, FirstName, LastName)
        values (@UserName, @FirstName, @LastName)  

        select @StaffMemberId = scope_identity()
    end 
    else
    begin
        update StaffMember 
        set  
        UserName = @UserName, 
        FirstName = @FirstName, 
        LastName = @LastName
        where StaffMemberId = @StaffMemberId
    end

    finished:
    return @return
end 
go