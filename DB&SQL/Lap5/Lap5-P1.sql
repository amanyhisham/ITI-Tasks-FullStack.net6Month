--Lap5 Q1-Part1---------
 select  count(St_Id)  
 from Student
 where St_Age IS NOT NULL;
 --Q2-Part1----------
select distinct Ins_Name
from Instructor
--Q3-Part1----------
select 
isNull (St_Id ,'NO ID') AS [Student ID], 
isNull (concat(St_Fname,' ',St_Lname),'No Name') as [Student FullName]  ,
isNull (Dept_Name,'NODepartment') as [Department name]
from Student S join Department D
on S.Dept_Id=D.Dept_Id
--Q4-Part1----------
select Ins_Name ,Dept_Name  
from Instructor I left join Department D
on I.Dept_Id=D.Dept_Id
---Q5-Part1-----------
select
concat(St_Fname,' ',St_Lname) as [Student FullName]  ,
Crs_Name as[Name Course],Grade as[Grade Course]
from Student S join Stud_Course SC
on S.St_Id=SC.St_Id
join Course C
on C.Crs_Id=SC.Crs_Id
Where Grade IS NOT NULL
---Q6-Part1-----------
select Top_Name , count(C.Crs_Id) as [Number of Courses]
from Topic T join Course C
on T.Top_Id = C.Top_Id
group by Top_Name
---Q7-Part1-----------
select min(Salary) as[Min Salary] ,max(Salary) as[Max Salary]  
from Instructor
---Q8-Part1-----------
select Salary ,Ins_Name
from Instructor
where salary < (select avg(isnull(salary,0))
                from Instructor )
---Q9-Part1-----------
select Salary ,Ins_Name ,Dept_Name
from Instructor I join Department D
on I.Dept_Id = D.Dept_Id
where  salary = (select min(salary) from Instructor)
---Q10-Part1-----------
select  Top(2) Salary   
from Instructor 
order by salary desc
---Q11-Part1-----------
select Ins_Name,coalesce(cast(Salary as varchar(20)),'bonus') As [Salary]
from Instructor 
---Q12-Part1-----------
select avg(isnull(salary,0)) as[Avarge Salary]
from Instructor
---Q13-Part1-----------
select  stud.St_Fname AS [name Student],
concat(super.St_Fname,' ',super.St_Lname)AS [Supervisor name] 
,super.St_Address AS [Supervisor address]
,super.St_Age AS [Supervisor Age],super.Dept_Id AS [Supervisor Dept_ID]
from student stud join student super
on stud.St_super=super.St_Id
---Q14-Part1-----------
select *
from 
(
select salary,Dept_Name ,D.Dept_Id,
row_number() over(Partition BY Dept_Name  order by salary desc) as SalRank
from instructor I join Department D
on I.Dept_Id=D.Dept_Id) t 
where SalRank <=2   
order by Dept_Id
---Q15-Part1-----------
select * 
from
(
select concat(St_Fname,' ',St_Lname) as[Fullname Student],Dept_Name,D.Dept_Id,
row_number() over(Partition by Dept_Name   order by NEWID()) as RowRank
from Department D join Student S
on D.Dept_Id = S.Dept_Id
)t
where RowRank = 1
-------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------
 
   
 
