--ddl create table [class]:
CREATE TABLE Students (
    StudentId INT PRIMARY KEY,
    Email VARCHAR(100) UNIQUE,
    Age INT CHECK (Age >= 18),
    CourseId INT
);
INSERT INTO Students VALUES (1, 'rahul@gmail.com', 20, 101);
INSERT INTO Students VALUES (2, 'neha@gmail.com', 22, 102);
INSERT INTO Students VALUES (3, 'amit@gmail.com', 19, 101);

select * from Students;

--aggregate function
select count(*) as total_student
from Students;

select avg(age) as avg_Age_student
from Students;

--scalar functions
select StudentId, len(Email) as email_length, GETDATE() as currentdate
from Students

--grouping 
select courseID, count(*) as studentcount
from students
group by CourseId;

--transactions
begin transaction;
update students 
set age = age+1
where CourseId=101;

select * from Students;

rollback;
select * from Students;

commit;

BEGIN TRANSACTION;

UPDATE Students
SET Age = 25
WHERE StudentId = 2;
SAVE TRANSACTION s1;   -- savepoint created here

UPDATE Students
SET Age = 30
WHERE StudentId = 1;
ROLLBACK TRANSACTION s1;  -- rollback only changes after savepoint
COMMIT;

select * from Students;

--grant and revoke:
grant select, insert on students to user1; --user1 is allowed to perform these operations.
revoke insert in students from user1; --user1 is not allowed to perform the insertion

--doc alter
alter table students
add phone varchar(50);

select * from Students;
--create a function to just display the table
CREATE FUNCTION dbo.fn_DisplayStudents_Table()
RETURNS TABLE
AS
RETURN
(
    SELECT StudentId, Email, Age, CourseID
    FROM dbo.Students
);
GO
select * from dbo.fn_DisplayStudents_Table();

create function dbo.fn_GET_STUDENTByCourseID(@courseID INT)
returns TABLE
as
return 
(
    select studentID, Email, AGE FROM Students
    where CourseId = @courseID
);

select * from dbo.fn_GET_STUDENTByCourseID(101);


--foreign key implementation
--PARENT TABLE
CREATE TABlE Courses(
courseid int primary key,
courseName varchar(100) not null,
durationMonths int check (durationMonths > 0)
);
--there can be a student without values of course
--first we have to insert values for a course table we will insert students in wipro university only.
--second i can have students in wipro university

insert into courses values (101,'fullstack dev using .net',6);
insert into courses values (102,'Data engineering using Azure',8);
insert into courses values (103,'block chain development',9);
insert into courses values (104,'cloud and devops',8);

select * from Courses;

--child table
create table wiproUniversity
(
studentID int primary key,
email varchar(100) unique,
age int check (age>=18),
courseId int,
Constraint FK_students_Courses
foreign key (courseID)
references courses(courseID)
);

INSERT INTO wiproUniversity VALUES (1, 'rahul@gmail.com', 20, 101);
INSERT INTO wiproUniversity VALUES (2, 'neha@gmail.com', 22, 102);
INSERT INTO wiproUniversity VALUES (3, 'amit@gmail.com', 19, 101);
INSERT INTO wiproUniversity VALUES (3, 'amit@gmail.com', 19, 109); --this cannot be excecuted as it is violating the rule of the foreign key that we have created the relation.

--to delete course (ex fromcgt)


--joins
-- Courses( Master table )
-- Students ( transaction Table)
-- Trainers( Self Join use cases)

CREATE TABLE MyCourses (
    CourseId INT PRIMARY KEY,
    CourseName VARCHAR(100)
);

CREATE TABLE My_Students (
    StudentId INT PRIMARY KEY,
    StudentName VARCHAR(50),
    CourseId INT
);
CREATE TABLE Trainers (
    TrainerId INT PRIMARY KEY,
    TrainerName VARCHAR(50),
    ManagerId INT
);

INSERT INTO MyCourses (CourseId, CourseName)
VALUES
(101, 'SQL Basics'),
(102, 'C# .NET Fundamentals'),
(103, 'ASP.NET Core'),
(104, 'React JS'),
(105, 'Cybersecurity Fundamentals');

INSERT INTO My_Students (StudentId, StudentName, CourseId)
VALUES
(1, 'Amit', 101),
(2, 'Priya', 102),
(3, 'Rahul', 103),
(4, 'Sneha', 104),
(5, 'John', 101),
(6, 'Kiran', 102),
(7, 'Neha', 104),
(8, 'Varun', 105),
(9, 'Meena', NULL),   -- not enrolled
(10, 'Suresh', NULL); -- not enrolled

INSERT INTO Trainers (TrainerId, TrainerName, ManagerId)
VALUES
(1, 'Ravi', NULL),    -- top level manager
(2, 'Anita', 1),
(3, 'Karthik', 1),
(4, 'Divya', 2),
(5, 'Sanjay', 2),
(6, 'Naveen', 3);

select * from MyCourses,My_Students,Trainers;

--inner join 
select s.StudentId,s.StudentName,c.coursename
from My_Students s
inner join MyCourses c
on s.CourseId = c.CourseId;

SELECT s.StudentId, s.StudentName, c.CourseName
FROM My_Students s
LEFT JOIN MyCourses c
ON s.CourseId = c.CourseId;

SELECT s.StudentId, s.StudentName, c.CourseName
FROM My_Students s
RIGHT JOIN MyCourses c
ON s.CourseId = c.CourseId;

SELECT s.StudentId, s.StudentName, c.CourseName
FROM My_Students s
FULL OUTER JOIN MyCourses c
ON s.CourseId = c.CourseId;

--cross join
select s.studentname, c.coursename
from My_Students s
cross join MyCourses c;

--self join
SELECT 
    t.TrainerId,
    t.TrainerName AS Trainer,
    m.TrainerName AS Manager
FROM Trainers t
LEFT JOIN Trainers m
ON t.ManagerId = m.TrainerId;
