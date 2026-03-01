select *
from Employee
--question1 lap4---
SELECT SUM(Salary) AS Total_Salary
FROM Employee
WHERE Dno = 10;
--OR--
select sum(salary) 
from Employee
where Dno=( select Dnum from Departments where Dnum=10);

--question2 lap4---
select sum(salary)/count(*)
from Employee
--OR--
select avg(isnull(salary,0))
from Employee

--question3 lap4---
select avg(isnull(salary,0))
from Employee
where Dno=10
--or---
select avg(isnull(salary,0))
from Employee E join Departments D
on E.Dno=D.Dnum
where Dno=10

--question4 lap4---
select count(SSN) AS 'Total Emplyee'
from Employee E Join Works_for W
On E.SSN=W.ESSn
JOIN Project P
on P.Pnumber=W.Pno
where P.Pnumber=100
 
--OR--
SELECT COUNT( Essn)  as'Total Emplyee'
FROM Works_for
WHERE Pno = 100;

SELECT *
FROM Works_for
WHERE Pno = 100;
 
--question5 lap4---
select Dno,count(ssn) as'Total_Emplyee'
from Employee
group by Dno
 
 --or--
select  Dnum,count(ssn) as'Total_Emplyee'
from Employee E join Departments D
on D.Dnum=E.Dno
group by Dnum
 

--question6 lap4---
select  Pname, sum(Hours) as 'Total_Hours '
from Works_for W join Project P
on W.Pno= P.Pnumber
group by Pname 

 --or--
SELECT Pno, SUM(Hours) AS 'Total_Hours'
FROM Works_for
GROUP BY Pno;

---question7 lap4---
select Fname+' '+Lname as 'full_name' ,Pname
from Employee E join Works_for W
on W.ESSn=E.ssn and E.Address LIKE  '%Giza%'
join Project P
on W.Pno=P.Pnumber and P.City ='Cairo'

select *
from Project
where City='Cairo'

select *
from Employee
where Address LIKE  '%Giza%'

---question8 lap4---
select Fname+' '+Lname as'Full_Name',Salary
from Employee E
where E.Salary >
(select AVG(isnull(Salary,0))
From Employee
)
---question9 lap4---
select DISTINCT Super.Superssn ,Super.Fname+' '+Super.Lname as'Full_Name'
From Employee E join Employee Super 
on E.Superssn=Super.SSN
 
