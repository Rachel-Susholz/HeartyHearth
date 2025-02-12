create or alter proc dbo.CourseTypeUpdate(
    @CourseTypeId int output,
    @CourseTypeName varchar(50),
    @CourseSequence int,
    @message varchar(500) = '' output 
)
as 
begin 
    declare @return int = 0 

    select @CourseTypeId = isnull(@CourseTypeId, 0)
        
    if @CourseTypeId = 0 
    begin 
        insert CourseType(CourseTypeName, CourseSequence)
        values (@CourseTypeName, @CourseSequence)  

        select @CourseTypeId = scope_identity()
    end 
    else
    begin
        update CourseType
        set  
        CourseTypeName = @CourseTypeName,
        CourseSequence = @CourseSequence
        where CourseTypeId = @CourseTypeId
    end

    finished:
    return @return
end 
go