--------Q1--Lap6----------------------
GO
Create view Student_Grade as
select 
concat(St_Fname ,' ',St_Lname) as[Full Name]
,Crs_Name as [Course Name],Grade as[Grade]
from Student S join Stud_Course Sc
on S.St_Id=Sc.St_Id
join Course C
on C.Crs_Id=Sc.Crs_Id
where Grade>50
Go
---To Ensure has Created view--
select * from Student_Grade
--------Q2--Lap6----------------------
--test db-------------------
select * from Department
select * from Instructor
select * from Ins_Course
select * from Course
select * from Topic
select * from Student
UPDATE Department
SET Dept_Manager = 5
WHERE Dept_Manager is  null;
-----------------------------
GO
create view Manger_Name_and_Topics
with encryption
as
select Ins_Name,Top_Name 
from Department D join Instructor I
on D.Dept_Manager= I.Ins_Id
join Ins_Course IC
on IC.Ins_Id=I.Ins_Id
join Course C
on C.Crs_Id=IC.Crs_Id
join Topic T
on T.Top_Id=C.Top_Id
GO
select * from Manger_Name_and_Topics
--------Q3--Lap6----------------------
Go
create view name_instructor_Department
as
select Ins_Name ,Dept_Name
from Instructor I join Department D
on I.Dept_Id= D.Dept_Id
where D.Dept_Name in ('SD','Java')
Go
select * from name_instructor_Department
--------Q4--Lap6----------------------
GO
create view v1 as
select * 
from Student
Where St_Address in ('Alex','Cairo')
WITH CHECK OPTION --->>> Whata prevent any updata or insert in view Block----
GO
Update V1
set st_address='tanta'
where st_address='alex'
 