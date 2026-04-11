---After taken Updata SubQuery ---------
-----بعد شرح الابديت فى سيشن7 ---------
------------Lap7--Part1---------------------------
use[Company_SD]
go
select * from Dependent
select * from Company.Departments
select * from HumanResource.Employee
select * from Works_for
select * from Project
go
--Lap7--Q5----------------------------
ALTER TABLE Project ADD Budget money
UPDATE project
set Budget = Budget*1.1
where Pnumber in(
select pno
from Works_for
where Essn=669955
)
-----Lap7--Q6-----------------------
update Company.Departments
set Dname='Sales'
where Dnum =(
select Dno
from HumanResource.Employee
where Fname='amany'
)
-------Lap7--Q7-----------------------
Update Dependent
set Bdate='12.12.2007'
where Essn=(
select SSN 
from Employee E join Works_for W
on W.ESSn=E.SSN
join Project P
on W.Pno=p.Pnumber
join Departments D
on D.Dnum=p.Dnum
where Dname='Sales' and Pname='p1'
)
------Lap7--Q8----------------------
ALTER TABLE Company.Departments ADD Dlocation varchar(40)
delete from Works_for
where pno in(select  pnumber 
from project p join  Company.Departments D
on D.Dnum=p.Dnum
where Dlocation='KW')