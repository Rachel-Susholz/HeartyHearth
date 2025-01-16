create or alter procedure dbo.StaffMemberGet(@StaffMemberId int = 0, @All bit = 0, @UserName varchar(50) = '')
as 
begin 
    select sm.StaffMemberId, sm.UserName
    from StaffMember sm
    where sm.StaffMemberId = @StaffMemberId
    or @All = 1
    or (sm.UserName like '%' + @UserName + '%' and @UserName <> '')
    order by sm.UserName

end
go 


exec StaffMemberGet

exec StaffMemberGet @All = 1

exec StaffMemberGet @UserName = ''
exec StaffMemberGet @UserName = 'j'

declare @id int 
select top 1 @id = sm.StaffMemberId from StaffMember sm


exec StaffMemberGet @StaffMemberId = @id
