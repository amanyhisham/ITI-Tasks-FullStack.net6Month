---Use Company DataBase--------------
--------Q5--Lap6----------------------
select * from Project
select * from Works_for
go
create view  v2 as
select Pname as[project Nmae],
Count(Essn) as [Number Employee],
P.Pnumber as [Number Project]
from Project P left join Works_for W
on P.Pnumber= W.Pno
group by Pname ,P.Pnumber
go
--------Q6--Lap6----------------------
create Clustered index index_on_depterment on Departments ([MGRStart Date]);
create nonclustered index index_Department_MgrStart on Departments([MgrStart Date]);
/*
what happen ??
-> error as index clustered on department created before and,
you can create 1 clustered index on table
I use command:
DROP INDEX PK_Departments ON Departments;
But Not allow to drop return this massage:
"An explicit DROP INDEX is not allowed on index 'Departments.PK_Departments'.
It is being used for PRIMARY KEY constraint enforcement."

->If you want to create another clustered index, you must first drop the existing one.
so i created 
nonclustered -->This will make searching faster without affecting the primary key
*/
--------Q7--Lap6---------------------------------------------------------
create unique index unique_index_Projectname on project(Pname)
/* what happen??
->if you try to updata or insert project has name already in project name will apperar Error
->inser and updata only project name wasnot in Projectname column
*/
----------------Q8-Part2-Lap6------------------------------------------
go
Create schema Company
go
create schema HumanResource
go
Alter schema Company transfer dbo.Departments
Alter Schema HumanResource transfer dbo.Employee
----------------Q9-Part2-Lap6------------------------------------------
select * 
from INFORMATION_SCHEMA.TABLE_CONSTRAINTS 
where  TABLE_NAME ='Employee'
--------------Q10--Part2--Lap6------------------------------------------
go
create Synonym  EmPP for HumanResource.Employee

Select * from Employee
----> Give strueter table emplayyee but empty without data as it search in defult schema dpo and it in HumanResource schema
Select * from HumanResource.Employee --------------->Run 
Select * from EmPP----------------------->Run
Select * from HumanResource.EmPP------->Error As it no table Empp in schema HumanResource
