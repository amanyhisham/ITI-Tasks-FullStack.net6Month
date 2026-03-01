-- 1. Display all the employees Data.
SELECT * 
FROM Employee;

SELECT * 
FROM Project;

SELECT * 
FROM Departments;

SELECT * 
FROM Dependent;

SELECT * 
FROM  Works_for;


-- 2. Display the employee First name, last name, Salary and Department number.
SELECT FName, LName, Salary, Dno
FROM Employee;

-- 3. Display all the projects names, locations and the department which is responsible about it.
SELECT PName, PLocation, Dnum
FROM Project;

-- 4. Display each employee full name and his annual commission (10% of annual salary) as ANNUAL COMM.
SELECT 
    FName + ' ' + LName AS FullName,
    (Salary * 12 * 0.10) AS [ANNUAL COMM]
FROM Employee;

-- 5. Display the employees Id, name who earns more than 1000 LE monthly.
SELECT SSN, FName + ' ' + LName AS FullName, Salary
FROM Employee
WHERE Salary > 1000;

-- 6. Display the employees Id, name who earns more than 10000 LE annually.
SELECT SSN, FName + ' ' + LName AS FullName, Salary
FROM Employee
WHERE Salary * 12 > 10000;

-- 7. Display the names and salaries of the female employees.
SELECT FName + ' ' + LName AS FName, Salary
FROM Employee E Join  Dependent D
on E.SSN=D.ESSN
WHERE D.Sex = 'F';

-- 8. Display each department id, name which managed by a manager with id equals 968574.
SELECT MGRSSN, Dname
FROM Departments
WHERE MGRSSN = 968574;

-- 9. Display the ids, names and locations of the projects which controlled by department 10.
SELECT Pnumber, Pname, plocation
FROM Project P join Departments D
on p.Dnum=D.Dnum
WHERE  D.Dnum=10

