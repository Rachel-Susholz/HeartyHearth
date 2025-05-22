Script to create login and user is excluded from this repo.
Create a file called create-login.sql. (This file is ignored by git ignore in this repo).
Add the following to that file: 

--IMPORTANT create login in MASTER 
-- use MASTER
create login [login name] with password = '[password]'
--IMPORTANT switch to HeartyHearthDB 
create user [user name] from login [login name]