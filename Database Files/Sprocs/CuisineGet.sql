create or alter procedure dbo.CuisineGet(@CuisineTypeId int = 0, @All bit = 0, @CuisineName varchar(50) = '')
as 
begin 
    select ct.CuisineTypeId, ct.CuisineName
    from CuisineType ct
    where ct.CuisineTypeId = @CuisineTypeId
    or @All = 1
    or (ct.CuisineName like '%' + @CuisineName + '%' and @CuisineName <> '')
    order by ct.CuisineName

end
go 


exec CuisineGet

exec CuisineGet @All = 1

exec CuisineGet @CuisineName = ''
exec CuisineGet @CuisineName = 'e'

declare @id int 
select top 1 @id = ct.CuisineTypeId from CuisineType ct


exec CuisineGet @CuisineTypeId = @id
