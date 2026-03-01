--Question1 lap3---
select Dname,Dnum ,Fname ,SSN
from Departments D join Employee E
on E.SSN=D.MGRSSN;

--Question2 lap3----
select Dname,Pname
from Departments D ,Project P
where D.Dnum=P.Dnum

--Question3 lap3----
select D.* ,Fname , Lname as 'full name'
from Dependent D join Employee E
on D.ESSN=E.SSN

--Question4 lap3----
select Pnumber,Pname,Plocation,City
from Project
where City ='Cairo' or City = 'Alex'

--OR--
SELECT Pnumber, Pname, Plocation ,City
FROM Project
WHERE City IN ('Cairo', 'Alex');

--question5 lap3----
select P.*
from Project P
where Pname like'a%'

--question6 lap3----
select E.* ,Dnum
from Employee E ,Departments
where Dnum=30 and (Salary between 1000 and 2000)

--question7 lap3----
select Fname +' '+Lname as 'full name' ,D.Dnum ,Hours ,Pname
from Employee E join Departments D
on E.Dno=D.Dnum and Dnum=10
join Project P
on P.Dnum=D.Dnum and Pname='AL Rabwah'
join Works_for W
on W.Pno=P.Pnumber and Hours >=10
 
--QuestioN8 lap3----
select E.Fname + ' ' +E.Lname as'Employee_Name'
, Super.Fname + ' ' +Super.Lname as'Supervisor_Name'
from Employee E Join Employee Super
on E.Superssn=Super.SSN
where Super.Fname='Kamel' and Super.Lname='Mohamed'

--question9 lap3----
select E.Fname + ' ' +E.Lname as'Employee_Name'
,P.Pname as 'Project_name'
from Employee E join Works_for W
on E.SSN=W.ESSn
join Project P
on P.Pnumber=W.Pno
order by Pname

---question10 lap3---
select Pname,Plocation,Dname,Fname+' '+Lname as'Manger',Address,Bdate
from Project P join Departments D
on P.Dnum =D.Dnum
Join Employee E
on E.SSN=D.MGRSSN
where City='Cairo'

---question11 lap3---
SELECT   E.*
FROM Employee E
JOIN Departments D
ON E.SSN = D.MGRSSN;

--question12 lap3----
select E.*,D.*
from Employee E left join Dependent D
on E.SSN=D.ESSN

--question13 lap3---
INSERT INTO Employee (Fname,Lname,Bdate,Address,Sex,Dno, Superssn, SSN, Salary)
VALUES ('Amany','Hesham','1-1-2004','Cairo', 'F',30, 112233, 102672, 3000);
--question14 lap3---
INSERT INTO Employee (Fname,Lname,Dno, SSN)
VALUES ('Amal','Mohmed',30, 102660);

--qyestion15 lap3---
UPDATE  Employee
set Salary+=0.2*salary
where Fname ='Amany' and SSN='102672'
SELECT *
FROM Employee
WHERE SSN = '102672'

 