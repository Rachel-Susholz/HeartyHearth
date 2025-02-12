
create or alter procedure dbo.MeasurementGet(@MeasurementId int = 0, @All bit = 0, @MeasurementType varchar(50) = '')
as 
begin 
    select mt.MeasurementId, mt.MeasurementType
    from Measurement mt
    where @All = 1
    or mt.MeasurementId = @MeasurementId
    or (mt.MeasurementType like '%' + @MeasurementType + '%' and @MeasurementType <> '')
    order by mt.MeasurementType

end
go 

exec MeasurementGet

exec MeasurementGet @All = 1






