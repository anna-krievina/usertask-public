Use [usertask]

CREATE TABLE priority_level (
    t_id int IDENTITY(1,1) PRIMARY KEY,
    t_status VARCHAR(100) NOT NULL
);

CREATE TABLE task_status (
    t_id int IDENTITY(1,1) PRIMARY KEY,
    t_status VARCHAR(100) NOT NULL
);

CREATE TABLE users (
    t_id int IDENTITY(1,1) PRIMARY KEY,
    t_username VARCHAR(100) NOT NULL,
    t_password VARCHAR(100) NOT NULL
);

CREATE TABLE task (
    t_id int IDENTITY(1,1) PRIMARY KEY,
    t_title VARCHAR(100) NOT NULL,
    t_description VARCHAR(200),
    t_due_date DATE DEFAULT NULL,
    t_priority_level int NOT NULL,
    t_status int NOT NULL,
    t_user_id int NOT NULL,
    FOREIGN KEY (t_priority_level) REFERENCES priority_level(t_id),
    FOREIGN KEY (t_status) REFERENCES task_status(t_id),
    FOREIGN KEY (t_user_id) REFERENCES users(t_id)
);

INSERT INTO [dbo].[priority_level] (t_status)
VALUES ('low');
INSERT INTO [dbo].[priority_level] (t_status)
VALUES ('medium');
INSERT INTO [dbo].[priority_level] (t_status)
VALUES ('high');
INSERT INTO [dbo].[priority_level] (t_status)
VALUES ('maximum');

INSERT INTO [dbo].[task_status] (t_status)
VALUES ('created');
INSERT INTO [dbo].[task_status] (t_status)
VALUES ('in progress');
INSERT INTO [dbo].[task_status] (t_status)
VALUES ('completed');

USE [usertask]
GO

CREWATE PROCEDURE SelectAllTasks @Priority int
AS
SELECT t.t_title, t.t_description, t.t_due_date, p.t_status FROM [Task] t
JOIN [Priority_level] p ON t.t_priority_level = p.t_id
WHERE t.t_priority_level = @Priority;

CREATE PROCEDURE PrintNumbers1To10
AS
BEGIN
    DECLARE @Counter INT
    SET @Counter = 1
    
    WHILE @Counter <= 10
    BEGIN
        PRINT @Counter
        SET @Counter = @Counter + 1
    END
END

--How can I iterate over a recordset within a stored procedure?
CREATE TABLE Customers
(
    CustomerId INT NOT NULL PRIMARY KEY IDENTITY(1,1)
    ,FirstName Varchar(50) 
    ,LastName VARCHAR(40)
)

INSERT INTO Customers VALUES('jane', 'doe')
INSERT INTO Customers VALUES('bob', 'smith')

DECLARE @CustomerId INT, @FirstName VARCHAR(30), @LastName VARCHAR(50)

DECLARE @MessageOutput VARCHAR(100)

DECLARE Customer_Cursor CURSOR FOR 
    SELECT CustomerId, FirstName, LastName FROM Customers


OPEN Customer_Cursor 

FETCH NEXT FROM Customer_Cursor INTO
    @CustomerId, @FirstName, @LastName

WHILE @@FETCH_STATUS = 0
BEGIN
    SET @MessageOutput = @FirstName + ' ' + @LastName



    RAISERROR(@MessageOutput,0,1) WITH NOWAIT

    FETCH NEXT FROM Customer_Cursor INTO
    @CustomerId, @FirstName, @LastName
END
CLOSE Customer_Cursor
DEALLOCATE Customer_Cursor