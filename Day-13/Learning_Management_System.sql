create Database LMES_DB;
Go
use LMES_DB;
Go

--creating the students table
create table Students(
studentID int Identity(1,1) primary key,
fullName varchar(100) not null,
email varchar(100) unique not null,
phone varchar(15),
dob date
);

--To see column names in the table
SELECT COLUMN_NAME
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Trainers';

--To find the primary jey column name of the table.
SELECT c.name AS PrimaryKeyColumn
FROM sys.indexes i
JOIN sys.index_columns ic ON i.object_id = ic.object_id AND i.index_id = ic.index_id
JOIN sys.columns c ON ic.object_id = c.object_id AND ic.column_id = c.column_id
WHERE i.object_id = OBJECT_ID('dbo.Trainers')
  AND i.is_primary_key = 1;

DROP TABLE IF EXISTS Trainers;
GO

--creating the Trainers table
CREATE TABLE Trainers(
    TrainerId INT IDENTITY(1,1) PRIMARY KEY,
    FullName VARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL
);
GO

--creating the courses table.
CREATE TABLE Courses(
    CourseId INT IDENTITY(1,1) PRIMARY KEY,
    Title VARCHAR(100) NOT NULL,
    Fee DECIMAL(10,2) NOT NULL CHECK (Fee >= 0),
    DurationDays INT NOT NULL CHECK (DurationDays > 0),
    TrainerId INT NOT NULL,
    CONSTRAINT FK_Courses_trainers FOREIGN KEY (TrainerId)
        REFERENCES Trainers(TrainerId)
);
GO

--enrollment course
CREATE TABLE Enrollments
(
    EnrollmentId INT IDENTITY(1,1) PRIMARY KEY,
    StudentId INT NOT NULL,
    CourseId INT NOT NULL,
    EnrollDate DATETIME NOT NULL DEFAULT GETDATE(),
    Status VARCHAR(20) NOT NULL DEFAULT 'Active',
    CONSTRAINT FK_Enrollments_Students FOREIGN KEY (StudentId)
        REFERENCES Students(StudentId),
    CONSTRAINT FK_Enrollments_Courses FOREIGN KEY (CourseId)
        REFERENCES Courses(CourseId),
    CONSTRAINT UQ_Enrollments UNIQUE(StudentId, CourseId)
);

--insert (enrolling a student)
INSERT INTO Enrollments(StudentId, CourseId)
VALUES (1, 1);   --getting error as it voilates the foreign key relation

--student table values
INSERT INTO Students(FullName, Email, Phone, DOB)
VALUES ('Amit', 'amit@gmail.com', '9999999999', '2004-01-01');

--trainer table values
INSERT INTO Trainers(FullName, Email)
VALUES ('Trainer 1', 'trainer1@gmail.com');

--Insert Course
INSERT INTO Courses(Title, Fee, DurationDays, TrainerId)
VALUES ('SQL Basics', 2999, 20, 1);

--now inserting enrollments
INSERT INTO Enrollments(StudentId, CourseId)
VALUES (1, 1);

--report query:
SELECT 
    s.FullName AS StudentName,
    c.Title AS CourseName,
    e.EnrollDate,
    e.Status
FROM Enrollments e
JOIN Students s ON e.StudentId = s.StudentId
JOIN Courses c ON e.CourseId = c.CourseId;

--printing all the total enrollments:
SELECT 
    (SELECT COUNT(*) FROM Students) AS TotalStudents,
    (SELECT COUNT(*) FROM Courses) AS TotalCourses,
    (SELECT COUNT(*) FROM Enrollments) AS TotalEnrollments;