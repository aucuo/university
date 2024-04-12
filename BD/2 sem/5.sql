-- НЕОБНОВЛЯЕМЫЕ 

-- 1 
CREATE VIEW ProjectsAndManagers AS
SELECT p.Name AS ProjectName, e.Name AS ManagerName
FROM Projects p
JOIN Employees e ON p.ProjectManagerID = e.EmployeeID
JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE d.DepartmentID > 1;

-- 2
CREATE VIEW EmployeeDetails AS
SELECT e.Name, e.Email, e.Phone, d.Name AS DepartmentName
FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE e.PositionID > 1;

-- ОБНОВЛЯЕМЫЕ
-- 1
CREATE VIEW DepartmentEmployees AS
SELECT EmployeeID, Name, Email
FROM Employees
WHERE DepartmentID = 2;

-- 2
CREATE VIEW PositionSalaries AS
SELECT EmployeeID, Name, p.SalaryGrade
FROM Employees e
JOIN Positions p ON e.PositionID = p.PositionID;

-- 3
CREATE VIEW HighBudgetProjects AS
SELECT ProjectID, Name, Budget
FROM Projects
WHERE Budget > (SELECT AVG(Budget) FROM Projects);


ALTER VIEW DepartmentEmployees AS
SELECT EmployeeID, Name, Email
FROM Employees;

DROP VIEW HighBudgetProjects;

UPDATE DepartmentEmployees
SET Email = 'new_email@example.com'
WHERE EmployeeID = 1;

-- доп.задание

CREATE TEMPORARY TABLE TempEmployees (
    EmployeeID INT,
    Name VARCHAR(100),
    Email VARCHAR(100),
    Phone VARCHAR(20)
);

INSERT INTO TempEmployees (EmployeeID, Name, Email, Phone)
SELECT EmployeeID, Name, Email, Phone
FROM Employees
WHERE DepartmentID = 2;

SELECT * FROM TempEmployees;