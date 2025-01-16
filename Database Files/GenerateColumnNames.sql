declare @tablename varchar(50) = 'Recipe'

select
 concat ('@', c.column_name, ' ', c.data_type,
 case when c.character_maximum_length is null then '' else concat ('(', c.character_maximum_length, ')') end,
 case when c.table_name + 'Id' = c.column_name then ' output' else '' end,
 ',' )
from information_schema.columns c 
where c.table_name = @tablename

declare @insertlist varchar(5000) = ''

select @insertlist = @insertlist + concat(c.column_name, ', ')
from information_schema.columns c 
where c.table_name = @tablename 
and c.column_name <> c.table_name + 'Id'

select @insertlist
 

select @insertlist = ''

select @insertlist = @insertlist + concat('@', c.column_name, ', ')
from information_schema.columns c 
where c.table_name = @tablename 
and c.column_name <> c.table_name + 'Id'

select @insertlist

select concat(c.column_name, ' = ', '@', c.column_name, ', ')
from information_schema.columns c 
where c.table_name = @tablename 
and c.column_name <> c.table_name + 'Id'

