CREATE TABLE Employees(
	emp_id int PRIMARY KEY,
	emp_name VARCHAR(50),
	department VARCHAR(50),
	salary int
);

create table Courses1(
	course_id INT PRIMARY KEY,
	Course_name VARCHAR(50),
	Category VARCHAR(50)
);

CREATE TABLE Enrollments(
	enroll_id int PRIMARY KEY,
	emp_id INT,
	course_id INT,
	score int,
	foreign key (emp_id) REFERENCES Employees(emp_id),
	foreign key (course_id) REFERENCES Courses1(course_id)
);

INSERT INTO Employees (emp_id, emp_name, department, salary) VALUES
(1, 'Amit', 'IT', 60000),
(2, 'Sneha', 'HR', 45000),
(3, 'Rahul', 'Finance', 55000),
(4, 'Priya', 'IT', 70000),
(5, 'Karan', 'Marketing', 40000),
(6, 'Neha', 'IT', 50000);

INSERT INTO Courses1(course_id, course_name, category) VALUES
(101, 'SQL Basics', 'Database'),
(102, 'Advanced Excel', 'Analytics'),
(103, 'Cyber Security', 'Security'),
(104, 'Python Programming', 'Programming');

INSERT INTO Enrollments (enroll_id, emp_id, course_id, score) VALUES
(1, 1, 101, 85),
(2, 1, 104, 90),
(3, 2, 102, 75),
(4, 3, 101, 60),
(5, 3, 103, 70),
(6, 4, 104, 95),
(7, 4, 101, 88),
(8, 5, 102, 65),
(9, 6, 103, 80);

--joins:
select 
	e.emp_id,
	e.emp_name,
	c.course_id
from 
	Employees e
join 
	Enrollments c 
on e.emp_id = c.emp_id;

select * from Employees;
select * from Courses1;
select * from Enrollments;

select 
	e.emp_id,
	e.emp_name,
	c.course_name
from 
	Employees e
LEFT JOIN 
	Enrollments en 
ON e.emp_id = en.emp_id
left join 
	Courses1 c ON en.course_id = c.course_id;	

--group by 
--avg score per course
select 
	count(e.enroll_id) as total_students,
	avg(e.score) as avg_score,
	c.course_name
from 
	Enrollments e
JOIN 
	Courses1 c
on 
	e.course_id = c.course_id
GROUP BY 
	c.course_name;

--subqueries
--who scored above avg score

SELECT emp_id, score
FROM Enrollments
WHERE score > (
    SELECT AVG(score) FROM Enrollments
);

select 
	emp_id, avg_score 
from (select 
	emp_id, avg(score) as avg_score
from 
	Enrollments
group by 
	emp_id
) as emp_avg
where avg_score >80;

--highest salary employee
select 
	emp_id,
	salary 
from 
	Employees
where 
	salary = (select max(salary) from Employees);

select course_id, count(emp_id) as total_students
from
	Enrollments
group by 
	course_id
having count(emp_id)>(select avg(course_count)
from(select count(emp_id)as course_count
from Enrollments
group by course_id) as avg_table
);

--enrolled in both sql basics and python.
select 
	emp_id 
from
	Enrollments
where 
	course_id = 101
and 
	emp_id in(
	select emp_id 
	from Enrollments
	where course_id=104
	);
--sub query
select emp_name, department, salary 
from employees e 
where salary >( select avg(salary) from employees where department = e.department);

select max(salary) as max_Salary
from Employees
where salary < (select max(salary) from Employees);

select emp_name
from Employees
where emp_id not in (select emp_id from Enrollments);

select e.emp_name, e.department,c.course_name,en.score
from Employees e 
join Enrollments en on e.emp_id = en.emp_id
join Courses1 c on en.course_id = c.course_id;

select e.department, avg(en.score) as avg_score
from Employees e
join Enrollments en on e.emp_id = en.emp_id
group by e.department;

--stored procedures
create procedure Getemployeesbydept
	@dept VARCHAR(50)
as
BEGIN
	SELECT * from Employees
	where department = @dept;
end;

exec Getemployeesbydept 'IT';
go
create procedure getemployeesaldetails
	@salary int
as
begin
	select * from Employees
	where salary = @salary;
end;
go
exec getemployeesaldetails 70000;

drop procedure if exists getemployeesaldetails;
go 
create procedure getemployeesaldetails
	@salary int 
as 
BEGIN 
	select * from Employees
	where salary = @salary;
end;
go
exec getemployeesaldetails 70000;

drop procedure if exists getempbydeptandsalary;
go
create procedure getempbydeptandsalary
	@dept varchar(50),
	@minsalary int
as
begin
	select emp_id,emp_name,department, salary
	from employees
	where department = @dept
	and salary >= @minsalary;
end;
go

exec getempbydeptandsalary 'IT',60000;

DROP PROCEDURE IF EXISTS ADDEMPLOYEE;
GO

CREATE PROCEDURE ADDEMPLOYEE
	@emp_id int,
	@emp_name varchar(30),
	@department varchar(50),
	@salary int
AS
BEGIN 
	INSERT INTO Employees(emp_id,emp_name,department,salary)
	values (@emp_id,@emp_name, @department, @salary);
END;
GO
EXEC ADDEMPLOYEE 7,'rOHIT','FINANCE',53000;

--functions:
create function GetEmployeesByDept (@dept varchar(50))
returns table
as 
return 
(
	select emp_name, department, salary 
	from Employees
	where salary >= @minsalary
);
select * from dbo.gethighsalaryemployees(55000);

--triggers:
create table scorelog(
	log_id int identity(1,1) primary key,
	emp_id int,
	course_id int,
	score int,
	log_Date datetime default getdate()
);

--creating on the enrollments:
create trigger trg_Afterinsertenrollment
on enrollments
after insert 
as 
begin 
	insert into scorelog (emp_id,course_id,score)
	select emp_id, course_id,score 
	from inserted;
end;

--test:
INSERT INTO Enrollments VALUES (12, 2, 101, 88);
select * from scorelog;

--cursors
--processes rows one at a time
DECLARE @emp_id INT;

DECLARE bonus_cursor CURSOR FOR
SELECT emp_id
FROM Enrollments
WHERE score > 90;

OPEN bonus_cursor;

FETCH NEXT FROM bonus_cursor INTO @emp_id;

WHILE @@FETCH_STATUS = 0
BEGIN
    UPDATE Employees
    SET salary = salary + 2000
    WHERE emp_id = @emp_id;

    FETCH NEXT FROM bonus_cursor INTO @emp_id;
END;

CLOSE bonus_cursor;
DEALLOCATE bonus_cursor;
--before cursor
SELECT emp_id, emp_name, salary
FROM Employees
ORDER BY emp_id;
--after cursor:
DECLARE @emp_id INT;

DECLARE bonus_cursor CURSOR FOR
SELECT emp_id
FROM Enrollments
WHERE score > 90;

OPEN bonus_cursor;

FETCH NEXT FROM bonus_cursor INTO @emp_id;

WHILE @@FETCH_STATUS = 0
BEGIN
    UPDATE Employees
    SET salary = salary + 2000
    WHERE emp_id = @emp_id;

    FETCH NEXT FROM bonus_cursor INTO @emp_id;
END;

CLOSE bonus_cursor;
DEALLOCATE bonus_cursor;
