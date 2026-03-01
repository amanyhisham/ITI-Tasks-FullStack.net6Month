Create DataBase University;
Use University;
--table instructor---
create table instructor(
ID int Primary key IDENTITY,
Ename varchar(20),
salary money DEFAULT 3000,
address varchar(20) ,
over_time int UNIQUE,
Birth_data date,
Hire_data Date DEFAULT GETDATE(),
Age  AS (year(getdate())-year(Birth_data)) persisted,
NetSalary  AS (isnull(salary,0)+isnull(over_time,0))persisted,
 
constraint c1 check(address in('Cairo','Alex')),
constraint c2 check(salary between 1000 and 5000),
 
);


---table Course---
create table Course(
CID int Primary key IDENTITY,
Cname varchar(20),
Duration INT UNIQUE 
);



-- Table Lap ----
create table lap(
Lab_Id int ,
CID INT,
capcity int ,
location varchar(20),
constraint primary_Key primary key(Lab_Id,CID),
constraint forign_key FOREIGN KEY(CID) references Course(CID)
on delete set null on update cascade,
constraint c3 check(capcity <20)
);


---table MTOM relation----
create table Instructot_Course(
instructor_id int,
CID int,
constraint primary_key primary Key (instructor_id,CID),
constraint forign_key FOREIGN KEY(CID) references Course(CID)
on delete set null on update cascade,
constraint forign_key FOREIGN KEY(instructor_id) references instructor(ID)
on delete set null on update cascade,

);