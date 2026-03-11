---Lap7---Part2------------------
------Procedure&Trigger----------
---Q1--Lap7--------------------------
USE ITI
GO
CREATE PROCEDURE StudentCountDepartment 
as
begin
select Count(st_id) as [Student Num],Dept_Name
from Student S join Department D
on S.Dept_Id=D.Dept_Id
group by Dept_Name
end
GO
EXEC StudentCountDepartment
---Q2--Lap7--------------------------
GO
create procedure Even_NUM @num1 int, @num2 int
as
begin
while @num1<=@num2
begin
if (@num1%2=0)
begin
select @num1 as [Even-Num]
end
set @num1=@num1+1
end
end
go
exec Even_Num 3,10
---Q3--Lap7--------------------------
 
use Company_SD
Go
create procedure Check_Project_P1
as
begin
declare @Num_EMP int  
select @Num_EMP=Count(SSN)
from HumanResource.Employee E join Works_for W
on W.ESSn=E.SSN
join Project P
on P.Pnumber=W.Pno
where pname='p1'
if (@Num_EMP>3)
begin
select 'The number of employees in the project p1 is 3 or more'
end
else if(@Num_EMP<=3)
begin
select 'The following employees work for the project p1' ,
concat(Fname,' ',Lname) As FullName
from HumanResource.Employee E join Works_for W
on W.ESSn=E.SSN
join Project P
on P.Pnumber=W.Pno
where pname='p1'
end
end
Go
exec Check_Project_P1
GO
---Q4&5--Lap7--(Funcation But (اتشرحت فى سيشن8))--------------------------
Go
create Function  GetName (@name varchar(50))
returns @t table (Name_table varchar(100))
as
Begin
if(@name='first name')
insert into @t
select isnull(Fname,'No FirstName') 
from Employee
 
else if(@name='last name')
insert into @t
select isnull(Lname,'No LastName') 
from Employee

else if(@name='Full name')
insert into @t
select isnull(concat(Fname,' ',Lname),'No FullName') 
from Employee
RETURN
end
Go
-->Call multi-statements Funcation:
SELECT * 
FROM dbo.GetName('first name')

SELECT * 
FROM dbo.GetName('last name')

SELECT * 
FROM dbo.GetName('full name')
go
---Q6--Lap7----------------------------
create procedure REplaceEmployee @numOld int,@numNew int ,@projectNum int
as
begin
update Works_for
set ESSn=@numNew
where Essn=@numOld and pno=@projectNum
end
go
EXEC REplaceEmployee 112233,709,1
---Q7--Lap7----------------------------
alter table Project add Budget money
create table AudioTable
(ProjectNo  int,
UserName  varchar(50),
ModifiedDate  date,
Budget_Old  money,
Budget_New money  
);
go
create Trigger Budget_Updata on project 
after update
as
begin
if update(Budget)
insert into AudioTable
select d.Pnumber,
SUSER_NAME(),
GETDATE(),
d.Budget,
i.Budget
FROM deleted d
JOIN inserted i
on d.Pnumber=i.Pnumber
end
go
--->Test Trigger :
UPDATE Project
SET Budget = 200000
WHERE Pnumber = 1

SELECT *
FROM AudioTable
---Q8--Lap7----------------------------
USE [ITI];
GO
create trigger prevent_insert_into_Department on Department
instead of insert
as
begin
select 'You cannot insert a new record into the Department table.'
end
GO
INSERT INTO Department (Dept_Id, Dept_Name) VALUES (10, 'AI');
Go
---Q9--Lap7----------------------------
USE [Company_SD];
GO
create trigger prevent_insert_into_Employee on Employee
instead of insert
as
begin
if Month(Getdate())=3
begin 
select 'You cannot insert a new record into the Employee table In March.'
RETURN
end
else
begin
insert into Employee 
SELECT * FROM inserted;
end
end
GO
INSERT INTO Employee
VALUES ('Ali','Hassan',999,'1995-01-01','Cairo','M',4000,NULL,1)
---Q10--Lap7----------------------------
use[ITI]
create table student_Audio(
Server_User_Name  varchar(100),
Data_Insert DATETIME,
Note varchar(200)
)
GO
create trigger insertion_Now on Student
after insert
as
begin
insert into student_Audio
select SYSTEM_USER, GETDATE(),
Concat( SYSTEM_USER ,  'Insert New Row with Key= ',St_Id, ' in table Student') AS Note
from inserted
end 
GO
------test: 
INSERT INTO Student (St_Id,St_Fname,St_Lname,Dept_Id)
VALUES (999,'Ali','Hassan',10)

SELECT *
FROM student_Audio
------Q11--Lap7----------------------------
GO
create trigger  Student_Delete_Audit on student
instead of delete
as
begin
insert into  student_Audio
select   SYSTEM_USER, GETDATE(),
Concat( SYSTEM_USER ,  'Try to delete Row with Key = ',St_Id, ' in table Student') AS Note
from deleted
end
GO
-----Test:
INSERT INTO Student (St_Id, St_Fname, St_Lname, St_Address, St_Age, Dept_Id, St_super)
VALUES (101, 'Amany', 'Hisham', 'Shibin al Kawm', 22, 10, NULL);
DELETE FROM Student WHERE St_Id = 101;
SELECT *
FROM student_Audio

