create or alter procedure dbo.CuisineGet(@CuisineId int = 0, @All bit = 0, @CuisineName varchar(50) = '')
as 
begin 
    select ct.CuisineId, ct.CuisineName
    from Cuisine ct
    where ct.CuisineId = @CuisineId
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
select top 1 @id = ct.CuisineId from Cuisine ct


exec CuisineGet @CuisineId = @id
