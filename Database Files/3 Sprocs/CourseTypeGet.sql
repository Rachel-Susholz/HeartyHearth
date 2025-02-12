create or alter procedure dbo.CourseTypeGet(@CourseTypeId int = 0, @All bit = 0, @CourseTypeName varchar(50) = '')
as 
begin 
    select ct.CourseTypeId, ct.CourseTypeName, ct.CourseSequence
    from CourseType ct
    where ct.CourseTypeId = @CourseTypeId
    or @All = 1
    or (ct.CourseTypeName like '%' + @CourseTypeName + '%' and @CourseTypeName <> '')
    order by ct.CourseTypeName

end
go 