------Q1---Lap8----------
use Company_SD
declare c1 cursor
for

select ssn,salary
from Employee

declare @salary int
declare @id int

open c1
fetch next from c1 into @id , @salary
while @@FETCH_STATUS=0
begin
if (@salary>=3000)
update Employee
set Salary=Salary*1.2
where ssn=@id

else if(@salary<3000)
update Employee
set Salary=Salary*1.1
where ssn=@id

fetch next from c1 into @salary , @id
end
close c1
deallocate c1
------Q2---Lap8----------
use ITI

select * from Department
select * from Instructor

declare c2 cursor
for
select  Dept_Name,Ins_Name
from Department D join Instructor I
on D.Dept_Manager=I.Ins_Id
 
declare @DepName varchar(50),@MangeName varchar(50)

open c2

fetch next from c2 into @DepName,@MangeName
while @@FETCH_STATUS=0
begin 
select @DepName as [Department name],@MangeName as[Manger Deparment]
fetch next from c2 into @DepName,@MangeName
end
close c2
deallocate c2
------Q3---Lap8----------
declare @name varchar(50)
declare @allname varchar(max)=''
declare c3 cursor
for 
select st_fname
from student

open c3 

fetch next from c3 into @name
while @@FETCH_STATUS=0
begin
set @allname=@allname+ISNULL(@name,'')+' , '
fetch next from c3 into @name
end
close c3
deallocate c3
SELECT @allname AS StudentNames
------Q4---Lap8----------
--->>هناك طريقه اخرى تم شرحها فى سيشن  الى هو بعمل بدون كود  
BACKUP DATABASE Company_SD
TO DISK = 'D:\Courses\ITI6Month-FullStack.net\DB&SQL\Day8\Company_SD_full_Backup.bak'
WITH INIT

BACKUP DATABASE Company_SD
TO DISK = 'D:\Courses\ITI6Month-FullStack.net\DB&SQL\Day8\Company_SD_differential_Backup.bak'
WITH DIFFERENTIAL
------Q5---Lap8----------
CREATE LOGIN Hesham WITH PASSWORD = 'Password123';
USE ITI;
CREATE USER Hesham FOR LOGIN Hesham;
grant select on department to Hesham
grant update on department to Hesham
grant select on Course to Hesham
grant update on Course to Hesham
------Q6---Lap8----------
create table Work 
( EmpID INT,
  ProjectID INT,
    Hours INT
);
insert into Work ( EmpID ,ProjectID, Hours ) values
(1, 101, 5),
(1, 101, 3),
(1, 102, 2),
(2, 101, 4),
(2, 103, 6),
(3, 104, 7),
(3, 104, 1);
select * from Work

select  EmpID ,  sum(Hours)
from Work
group by EmpID
with rollup

select * from Work
select  EmpID,ProjectID ,  sum(Hours)
from Work
group by EmpID,ProjectID
with rollup