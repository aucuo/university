-- 1 скалярная SELECT GetEmployeeCountByDepartment(1) AS EmployeeCount;
DELIMITER //
CREATE FUNCTION GetEmployeeCountByDepartment(departmentID INT)
RETURNS INT
DETERMINISTIC
BEGIN
    DECLARE empCount INT;
    SELECT COUNT(*) INTO empCount FROM Employees WHERE DepartmentID = departmentID;
    RETURN empCount;
END //
DELIMITER ;


-- 2 возвр. табл CALL GetEmployeesByDepartment(1);

DELIMITER //
CREATE PROCEDURE GetEmployeesByDepartment(departmentID INT)
BEGIN
    SELECT Name, Email, Phone FROM Employees WHERE DepartmentID = departmentID;
END //
DELIMITER ;

-- 3 многооператорная
DELIMITER //
CREATE PROCEDURE GetProjectsByManager(managerID INT)
BEGIN
    SELECT ProjectID, Name, StartDate, EndDate, Budget FROM Projects WHERE ProjectManagerID = managerID;
END //
DELIMITER ;


-- 4 скалярная (ур. зарплаты по должности) SELECT GetSalaryGradeByPosition(1) AS Salary;

DELIMITER $$

CREATE FUNCTION GetSalaryGradeByPosition(positionID INT) 
RETURNS INT
DETERMINISTIC
BEGIN
    RETURN (SELECT SalaryGrade FROM Positions WHERE PositionID = positionID LIMIT 1);
END$$

DELIMITER ;

-- 5 макс бюджет SELECT GetMaxProjectBudget() AS MaxBudget;
DELIMITER $$

CREATE FUNCTION GetMaxProjectBudget() 
RETURNS DECIMAL(10,2)
DETERMINISTIC
BEGIN
    RETURN (SELECT MAX(Budget) FROM Projects);
END$$

DELIMITER ;

-- 6 кол-во проектов у менеджера SELECT GetTotalProjectsByManager(1) AS ProjectCount;

DELIMITER $$

CREATE FUNCTION GetTotalProjectsByManager(managerID INT) 
RETURNS INT
DETERMINISTIC
BEGIN
    RETURN (SELECT COUNT(*) FROM Projects WHERE ProjectManagerID = managerID);
END$$

DELIMITER ;
