-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.2:3306
-- Время создания: Апр 11 2024 г., 09:50
-- Версия сервера: 8.0.24
-- Версия PHP: 7.4.21

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `aucusoft`
--

DELIMITER $$
--
-- Процедуры
--
CREATE DEFINER=`root`@`127.0.0.1` PROCEDURE `AddMeeting` (IN `p_ProjectID` INT, IN `p_MeetingDate` DATE, IN `p_Agenda` TEXT)  BEGIN
    -- Проверяем условие перед выполнением операций
    IF p_ProjectID > 0 THEN
        -- Если условие истинно, выполняем транзакцию
        START TRANSACTION;
        INSERT INTO meetings (ProjectID, MeetingDate, Agenda) VALUES (p_ProjectID, p_MeetingDate, p_Agenda);
        COMMIT;
    ELSE
        -- Если ProjectID некорректен, возвращаем ошибку
        SELECT 'Error: ProjectID must be greater than 0';
    END IF;
END$$

CREATE DEFINER=`root`@`127.0.0.1` PROCEDURE `GetEmployeesByDepartment` (`departmentID` INT)  BEGIN
    SELECT Name, Email, Phone FROM Employees WHERE DepartmentID = departmentID;
END$$

CREATE DEFINER=`root`@`127.0.0.1` PROCEDURE `GetProjectsByManager` (`managerID` INT)  BEGIN
    SELECT ProjectID, Name, StartDate, EndDate, Budget FROM Projects WHERE ProjectManagerID = managerID;
END$$

--
-- Функции
--
CREATE DEFINER=`root`@`127.0.0.1` FUNCTION `GetEmployeeCountByDepartment` (`departmentID` INT) RETURNS INT BEGIN
    DECLARE empCount INT;
    SELECT COUNT(*) INTO empCount FROM Employees WHERE DepartmentID = departmentID;
    RETURN empCount;
END$$

CREATE DEFINER=`root`@`127.0.0.1` FUNCTION `GetMaxProjectBudget` () RETURNS DECIMAL(10,2) BEGIN
    RETURN (SELECT MAX(Budget) FROM Projects);
END$$

CREATE DEFINER=`root`@`127.0.0.1` FUNCTION `GetSalaryGradeByPosition` (`positionID` INT) RETURNS INT BEGIN
    RETURN (SELECT SalaryGrade FROM Positions WHERE PositionID = positionID LIMIT 1);
END$$

CREATE DEFINER=`root`@`127.0.0.1` FUNCTION `GetTotalProjectsByManager` (`managerID` INT) RETURNS INT BEGIN
    RETURN (SELECT COUNT(*) FROM Projects WHERE ProjectManagerID = managerID);
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Структура таблицы `clientfeedback`
--

CREATE TABLE `clientfeedback` (
  `FeedbackID` int NOT NULL,
  `ProjectID` int DEFAULT NULL,
  `ClientID` int DEFAULT NULL,
  `Date` date DEFAULT NULL,
  `Text` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `clientfeedback`
--

INSERT INTO `clientfeedback` (`FeedbackID`, `ProjectID`, `ClientID`, `Date`, `Text`) VALUES
(1, 1, 1, '2024-02-15', 'Updated feedback text due to client review.'),
(2, 2, 2, '2024-03-15', 'The project was delivered on time, but there were some issues with the initial deployment.'),
(3, 3, 3, '2024-04-15', 'Excellent communication and project management.'),
(6, 1, 5, '2024-02-15', 'Updated feedback text due to client review.'),
(7, 1, 1, '2024-02-15', 'Updated feedback text due to client review.'),
(8, 4, 2, '2024-07-01', 'This is a newly added feedback.');

-- --------------------------------------------------------

--
-- Структура таблицы `clients`
--

CREATE TABLE `clients` (
  `ClientID` int NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Industry` varchar(255) DEFAULT NULL,
  `ContactPerson` varchar(255) DEFAULT NULL,
  `Email` varchar(255) DEFAULT NULL,
  `Phone` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `clients`
--

INSERT INTO `clients` (`ClientID`, `Name`, `Industry`, `ContactPerson`, `Email`, `Phone`) VALUES
(1, 'Alpha Corp', 'Technology', 'John Doe', 'johndoe@alphacorp.com', '80293284224'),
(2, 'Beta LLC', 'Finance', 'Jane Smith', 'janesmith@betallc.com', '80293284224'),
(3, 'Gamma Inc', 'Healthcare', 'Mike Brown', 'mikebrown@gammainc.com', '80293284224'),
(4, 'Delta Technologies', 'Education', 'Susan Clark', 'susanclark@deltatech.com', '80293284224'),
(5, 'Epsilon Services', 'Retail', 'Alex Johnson', 'alexjohnson@epsilonservices.com', '80293284224'),
(6, 'Aucusoft', 'Finance', 'Egor Shikovets', 'Egor Shikovets@example.com', '80293284224');

--
-- Триггеры `clients`
--
DELIMITER $$
CREATE TRIGGER `trg_DeleteClients` BEFORE DELETE ON `clients` FOR EACH ROW BEGIN
    IF OLD.Industry = 'Retail' THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Удаление клиентов из индустрии Retail запрещено';
    END IF;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `trg_InsertClients` BEFORE INSERT ON `clients` FOR EACH ROW BEGIN
    IF NEW.Email IS NULL OR NEW.Email = '' THEN
        SET NEW.Email = CONCAT(NEW.ContactPerson, '@example.com');
    END IF;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Дублирующая структура для представления `departmentemployees`
-- (См. Ниже фактическое представление)
--
CREATE TABLE `departmentemployees` (
`Email` varchar(255)
,`EmployeeID` int
,`Name` varchar(255)
);

-- --------------------------------------------------------

--
-- Структура таблицы `departments`
--

CREATE TABLE `departments` (
  `DepartmentID` int NOT NULL,
  `Name` varchar(255) NOT NULL,
  `ManagerID` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `departments`
--

INSERT INTO `departments` (`DepartmentID`, `Name`, `ManagerID`) VALUES
(1, 'Development', 4),
(2, 'Sales', 1),
(3, 'HR', 3),
(4, 'Marketing', 2),
(5, 'Finance', 5),
(6, 'IT', 1);

-- --------------------------------------------------------

--
-- Дублирующая структура для представления `employeedetails`
-- (См. Ниже фактическое представление)
--
CREATE TABLE `employeedetails` (
`DepartmentName` varchar(255)
,`Email` varchar(255)
,`Name` varchar(255)
,`Phone` varchar(50)
);

-- --------------------------------------------------------

--
-- Структура таблицы `employees`
--

CREATE TABLE `employees` (
  `EmployeeID` int NOT NULL,
  `Name` varchar(255) NOT NULL,
  `PositionID` int DEFAULT NULL,
  `DepartmentID` int DEFAULT NULL,
  `Email` varchar(255) DEFAULT NULL,
  `Phone` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `employees`
--

INSERT INTO `employees` (`EmployeeID`, `Name`, `PositionID`, `DepartmentID`, `Email`, `Phone`) VALUES
(1, 'Ivan Ivanov', 1, 1, 'new_email@example.com', '1234567890'),
(2, 'Petr Petrov', 2, 2, 'petrov@example.com', '0987654321'),
(3, 'Sidor Sidorov', 3, 3, 'sidorov@example.com', '1122334455'),
(4, 'Anna Annanova', 4, 4, 'annanova@example.com', '2233445566'),
(5, 'Olga Olganova', 5, 5, 'olganova@example.com', '3344556677');

-- --------------------------------------------------------

--
-- Структура таблицы `employeetasks`
--

CREATE TABLE `employeetasks` (
  `EmployeeTaskID` int NOT NULL,
  `TaskID` int DEFAULT NULL,
  `EmployeeID` int DEFAULT NULL,
  `TimeSpent` int DEFAULT NULL,
  `Date` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `employeetasks`
--

INSERT INTO `employeetasks` (`EmployeeTaskID`, `TaskID`, `EmployeeID`, `TimeSpent`, `Date`) VALUES
(1, 1, 1, 8, '2024-02-01'),
(2, 2, 2, 6, '2024-02-12'),
(3, 3, 1, 7, '2024-02-06'),
(4, 4, 3, 8, '2024-02-17'),
(5, 5, 2, 5, '2024-02-27');

-- --------------------------------------------------------

--
-- Дублирующая структура для представления `highbudgetprojects`
-- (См. Ниже фактическое представление)
--
CREATE TABLE `highbudgetprojects` (
`Budget` decimal(10,2)
,`Name` varchar(255)
,`ProjectID` int
);

-- --------------------------------------------------------

--
-- Структура таблицы `managers`
--

CREATE TABLE `managers` (
  `ManagerID` int NOT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `Position` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `managers`
--

INSERT INTO `managers` (`ManagerID`, `Name`, `Position`) VALUES
(1, 'Alexey Petrov', 'Senior Project Manager'),
(2, 'Maria Ivanova', 'Project Manager'),
(3, 'Igor Sidorov', 'IT Manager'),
(4, 'Elena Popova', 'Development Manager'),
(5, 'Dmitry Kuznetsov', 'Product Manager'),
(8, 'Egor Shikovets', 'Помощник грузчика'),
(9, 'Jane Smith', 'Account Manager');

--
-- Триггеры `managers`
--
DELIMITER $$
CREATE TRIGGER `trg_AfterUpdateManagers` AFTER UPDATE ON `managers` FOR EACH ROW BEGIN
    IF OLD.Position <> NEW.Position THEN
        INSERT INTO managers_log (ManagerID, OldPosition, NewPosition, ChangeDate)
        VALUES (OLD.ManagerID, OLD.Position, NEW.Position, NOW());
    END IF;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `trg_BeforeInsertManagers` BEFORE INSERT ON `managers` FOR EACH ROW BEGIN
    DECLARE cnt INT;
    SELECT COUNT(*) INTO cnt FROM managers WHERE Name = NEW.Name;
    IF cnt > 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Менеджер с таким именем уже существует.';
    END IF;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `trg_UpdateManagers` BEFORE UPDATE ON `managers` FOR EACH ROW BEGIN
    IF OLD.Name <> NEW.Name THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Изменение имени менеджера запрещено';
    END IF;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Структура таблицы `managers_log`
--

CREATE TABLE `managers_log` (
  `ManagerID` int NOT NULL,
  `OldPosition` varchar(255) NOT NULL,
  `NewPosition` varchar(255) NOT NULL,
  `ChangeDate` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `managers_log`
--

INSERT INTO `managers_log` (`ManagerID`, `OldPosition`, `NewPosition`, `ChangeDate`) VALUES
(5, 'Product Manager', 'Test', '2024-04-03'),
(5, 'Test', 'Product Manager', '2024-04-03'),
(8, 'Lead Full Stack Dev', 'Помощник грузчика', '2024-04-03');

-- --------------------------------------------------------

--
-- Структура таблицы `meetings`
--

CREATE TABLE `meetings` (
  `MeetingID` int NOT NULL,
  `ProjectID` int DEFAULT NULL,
  `MeetingDate` date DEFAULT NULL,
  `Agenda` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `meetings`
--

INSERT INTO `meetings` (`MeetingID`, `ProjectID`, `MeetingDate`, `Agenda`) VALUES
(3, 2, '2024-04-05', 'Промежуточный отчет'),
(4, 3, '2024-04-20', 'Тестирование продукта'),
(5, 4, '2024-05-10', 'Запуск проекта');

-- --------------------------------------------------------

--
-- Структура таблицы `positions`
--

CREATE TABLE `positions` (
  `PositionID` int NOT NULL,
  `Title` varchar(255) NOT NULL,
  `SalaryGrade` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `positions`
--

INSERT INTO `positions` (`PositionID`, `Title`, `SalaryGrade`) VALUES
(1, 'Software Developer', 2),
(2, 'Project Manager', 1),
(3, 'Quality Assurance Engineer', 3),
(4, 'UI/UX Designer', 4),
(5, 'System Analyst', 1);

-- --------------------------------------------------------

--
-- Дублирующая структура для представления `positionsalaries`
-- (См. Ниже фактическое представление)
--
CREATE TABLE `positionsalaries` (
`EmployeeID` int
,`Name` varchar(255)
,`SalaryGrade` int
);

-- --------------------------------------------------------

--
-- Структура таблицы `projectdocuments`
--

CREATE TABLE `projectdocuments` (
  `DocumentID` int NOT NULL,
  `ProjectID` int DEFAULT NULL,
  `Title` varchar(255) NOT NULL,
  `DocumentPath` varchar(255) DEFAULT NULL,
  `CreationDate` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `projectdocuments`
--

INSERT INTO `projectdocuments` (`DocumentID`, `ProjectID`, `Title`, `DocumentPath`, `CreationDate`) VALUES
(1, 1, 'Техническое задание', '/docs/project1/specification.pdf', '2024-02-15'),
(2, 1, 'План проекта', '/docs/project1/plan.pdf', '2024-02-20'),
(3, 2, 'Архитектура системы', '/docs/project2/architecture.pdf', '2024-03-01'),
(4, 3, 'Тестовый план', '/docs/project3/test_plan.pdf', '2024-03-15'),
(5, 4, 'Пользовательская документация', '/docs/project4/user_guide.pdf', '2024-04-01');

-- --------------------------------------------------------

--
-- Структура таблицы `projects`
--

CREATE TABLE `projects` (
  `ProjectID` int NOT NULL,
  `Name` varchar(255) NOT NULL,
  `StartDate` date DEFAULT NULL,
  `EndDate` date DEFAULT NULL,
  `Budget` decimal(10,2) DEFAULT NULL,
  `ClientID` int DEFAULT NULL,
  `ProjectManagerID` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `projects`
--

INSERT INTO `projects` (`ProjectID`, `Name`, `StartDate`, `EndDate`, `Budget`, `ClientID`, `ProjectManagerID`) VALUES
(1, 'Project Alpha', '2024-02-01', '2024-02-21', '121000.00', 1, 2),
(2, 'Project Beta', '2024-03-01', '2024-02-21', '192500.00', 2, 2),
(3, 'Project Gamma', '2024-04-01', '2024-02-21', '253000.00', 3, 2),
(4, 'Project Delta', '2024-05-01', '2024-11-01', '313500.00', 4, 2),
(5, 'Project Epsilon', '2024-06-01', '2024-06-15', '374000.00', 5, 2),
(6, 'New Project', '2024-01-01', '2024-12-31', '121000.00', 1, 1),
(7, 'New Project', '2024-01-01', '2024-12-31', '121000.00', 2, 1),
(8, 'New Project', '2024-01-01', '2024-12-31', '121000.00', 3, 1),
(9, 'New Project', '2024-01-01', '2024-12-31', '121000.00', 4, 1),
(10, 'New Project', '2024-01-01', '2024-12-31', '121000.00', 5, 1);

-- --------------------------------------------------------

--
-- Дублирующая структура для представления `projectsandmanagers`
-- (См. Ниже фактическое представление)
--
CREATE TABLE `projectsandmanagers` (
`ManagerName` varchar(255)
,`ProjectName` varchar(255)
);

-- --------------------------------------------------------

--
-- Структура таблицы `projecttechnologies`
--

CREATE TABLE `projecttechnologies` (
  `ProjectTechnologyID` int NOT NULL,
  `ProjectID` int DEFAULT NULL,
  `TechnologyID` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `projecttechnologies`
--

INSERT INTO `projecttechnologies` (`ProjectTechnologyID`, `ProjectID`, `TechnologyID`) VALUES
(1, 1, 1),
(2, 1, 2),
(3, 2, 3),
(4, 3, 4),
(5, 4, 5);

-- --------------------------------------------------------

--
-- Структура таблицы `tasks`
--

CREATE TABLE `tasks` (
  `TaskID` int NOT NULL,
  `ProjectID` int DEFAULT NULL,
  `AssignedTo` int DEFAULT NULL,
  `Description` text,
  `StartDate` date DEFAULT NULL,
  `EndDate` date DEFAULT NULL,
  `StatusID` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `tasks`
--

INSERT INTO `tasks` (`TaskID`, `ProjectID`, `AssignedTo`, `Description`, `StartDate`, `EndDate`, `StatusID`) VALUES
(1, 1, 1, 'Database design', '2024-02-01', '2024-02-10', 3),
(2, 1, 2, 'API development', '2024-02-11', '2024-02-20', 2),
(3, 2, 1, 'Frontend setup', '2024-02-05', '2024-02-15', 2),
(4, 2, 3, 'Backend logic', '2024-02-16', '2024-02-25', 1),
(5, 3, 2, 'Testing', '2024-02-26', '2024-03-07', 1);

-- --------------------------------------------------------

--
-- Структура таблицы `taskstatuses`
--

CREATE TABLE `taskstatuses` (
  `StatusID` int NOT NULL,
  `Name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `taskstatuses`
--

INSERT INTO `taskstatuses` (`StatusID`, `Name`) VALUES
(1, 'Not Started'),
(2, 'In Progress'),
(3, 'Completed'),
(4, 'On Hold'),
(5, 'Cancelled');

-- --------------------------------------------------------

--
-- Структура таблицы `technologies`
--

CREATE TABLE `technologies` (
  `TechnologyID` int NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Description` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `technologies`
--

INSERT INTO `technologies` (`TechnologyID`, `Name`, `Description`) VALUES
(1, 'Java', 'Язык программирования для разработки серверной части'),
(2, 'React', 'Библиотека для создания пользовательских интерфейсов'),
(3, 'Docker', 'Платформа для контейнеризации приложений'),
(4, 'Kubernetes', 'Система управления контейнеризированными приложениями'),
(5, 'TensorFlow', 'Открытая библиотека для машинного обучения');

-- --------------------------------------------------------

--
-- Структура таблицы `worklogs`
--

CREATE TABLE `worklogs` (
  `WorkLogID` int NOT NULL,
  `EmployeeID` int DEFAULT NULL,
  `ProjectID` int DEFAULT NULL,
  `HoursWorked` int DEFAULT NULL,
  `Date` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `worklogs`
--

INSERT INTO `worklogs` (`WorkLogID`, `EmployeeID`, `ProjectID`, `HoursWorked`, `Date`) VALUES
(1, 1, 1, 8, '2024-02-15'),
(2, 2, 1, 6, '2024-02-16'),
(3, 3, 2, 7, '2024-02-17'),
(4, 4, 2, 8, '2024-02-18'),
(5, 5, 3, 5, '2024-02-19');

-- --------------------------------------------------------

--
-- Структура таблицы `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20240402074213_InitialCreate', '7.0.17'),
('20240402075019_CreateManagersTable', '7.0.17');

-- --------------------------------------------------------

--
-- Структура для представления `departmentemployees`
--
DROP TABLE IF EXISTS `departmentemployees`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`127.0.0.1` SQL SECURITY DEFINER VIEW `departmentemployees`  AS SELECT `employees`.`EmployeeID` AS `EmployeeID`, `employees`.`Email` AS `Email`, `employees`.`Name` AS `Name` FROM `employees` ;

-- --------------------------------------------------------

--
-- Структура для представления `employeedetails`
--
DROP TABLE IF EXISTS `employeedetails`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`127.0.0.1` SQL SECURITY DEFINER VIEW `employeedetails`  AS SELECT `e`.`Name` AS `Name`, `e`.`Email` AS `Email`, `e`.`Phone` AS `Phone`, `d`.`Name` AS `DepartmentName` FROM (`employees` `e` join `departments` `d` on((`e`.`DepartmentID` = `d`.`DepartmentID`))) WHERE (`e`.`PositionID` > 1) ;

-- --------------------------------------------------------

--
-- Структура для представления `highbudgetprojects`
--
DROP TABLE IF EXISTS `highbudgetprojects`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`127.0.0.1` SQL SECURITY DEFINER VIEW `highbudgetprojects`  AS SELECT `projects`.`ProjectID` AS `ProjectID`, `projects`.`Name` AS `Name`, `projects`.`Budget` AS `Budget` FROM `projects` WHERE (`projects`.`Budget` > (select avg(`projects`.`Budget`) from `projects`)) ;

-- --------------------------------------------------------

--
-- Структура для представления `positionsalaries`
--
DROP TABLE IF EXISTS `positionsalaries`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`127.0.0.1` SQL SECURITY DEFINER VIEW `positionsalaries`  AS SELECT `e`.`EmployeeID` AS `EmployeeID`, `e`.`Name` AS `Name`, `p`.`SalaryGrade` AS `SalaryGrade` FROM (`employees` `e` join `positions` `p` on((`e`.`PositionID` = `p`.`PositionID`))) ;

-- --------------------------------------------------------

--
-- Структура для представления `projectsandmanagers`
--
DROP TABLE IF EXISTS `projectsandmanagers`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`127.0.0.1` SQL SECURITY DEFINER VIEW `projectsandmanagers`  AS SELECT `p`.`Name` AS `ProjectName`, `e`.`Name` AS `ManagerName` FROM ((`projects` `p` join `employees` `e` on((`p`.`ProjectManagerID` = `e`.`EmployeeID`))) join `departments` `d` on((`e`.`DepartmentID` = `d`.`DepartmentID`))) WHERE (`d`.`DepartmentID` > 1) ;

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `clientfeedback`
--
ALTER TABLE `clientfeedback`
  ADD PRIMARY KEY (`FeedbackID`),
  ADD KEY `ProjectID` (`ProjectID`),
  ADD KEY `ClientID` (`ClientID`);

--
-- Индексы таблицы `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`ClientID`);

--
-- Индексы таблицы `departments`
--
ALTER TABLE `departments`
  ADD PRIMARY KEY (`DepartmentID`),
  ADD KEY `fk_departments_managers` (`ManagerID`);

--
-- Индексы таблицы `employees`
--
ALTER TABLE `employees`
  ADD PRIMARY KEY (`EmployeeID`),
  ADD KEY `PositionID` (`PositionID`),
  ADD KEY `DepartmentID` (`DepartmentID`);

--
-- Индексы таблицы `employeetasks`
--
ALTER TABLE `employeetasks`
  ADD PRIMARY KEY (`EmployeeTaskID`),
  ADD KEY `TaskID` (`TaskID`),
  ADD KEY `employeetasks_ibfk_2` (`EmployeeID`);

--
-- Индексы таблицы `managers`
--
ALTER TABLE `managers`
  ADD PRIMARY KEY (`ManagerID`);

--
-- Индексы таблицы `meetings`
--
ALTER TABLE `meetings`
  ADD PRIMARY KEY (`MeetingID`),
  ADD KEY `ProjectID` (`ProjectID`);

--
-- Индексы таблицы `positions`
--
ALTER TABLE `positions`
  ADD PRIMARY KEY (`PositionID`);

--
-- Индексы таблицы `projectdocuments`
--
ALTER TABLE `projectdocuments`
  ADD PRIMARY KEY (`DocumentID`),
  ADD KEY `ProjectID` (`ProjectID`);

--
-- Индексы таблицы `projects`
--
ALTER TABLE `projects`
  ADD PRIMARY KEY (`ProjectID`),
  ADD KEY `ClientID` (`ClientID`),
  ADD KEY `ProjectManagerID` (`ProjectManagerID`);

--
-- Индексы таблицы `projecttechnologies`
--
ALTER TABLE `projecttechnologies`
  ADD PRIMARY KEY (`ProjectTechnologyID`),
  ADD KEY `ProjectID` (`ProjectID`),
  ADD KEY `TechnologyID` (`TechnologyID`);

--
-- Индексы таблицы `tasks`
--
ALTER TABLE `tasks`
  ADD PRIMARY KEY (`TaskID`),
  ADD KEY `ProjectID` (`ProjectID`),
  ADD KEY `AssignedTo` (`AssignedTo`),
  ADD KEY `StatusID` (`StatusID`);

--
-- Индексы таблицы `taskstatuses`
--
ALTER TABLE `taskstatuses`
  ADD PRIMARY KEY (`StatusID`);

--
-- Индексы таблицы `technologies`
--
ALTER TABLE `technologies`
  ADD PRIMARY KEY (`TechnologyID`);

--
-- Индексы таблицы `worklogs`
--
ALTER TABLE `worklogs`
  ADD PRIMARY KEY (`WorkLogID`),
  ADD KEY `EmployeeID` (`EmployeeID`),
  ADD KEY `ProjectID` (`ProjectID`);

--
-- Индексы таблицы `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `clientfeedback`
--
ALTER TABLE `clientfeedback`
  MODIFY `FeedbackID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT для таблицы `clients`
--
ALTER TABLE `clients`
  MODIFY `ClientID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT для таблицы `departments`
--
ALTER TABLE `departments`
  MODIFY `DepartmentID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT для таблицы `employees`
--
ALTER TABLE `employees`
  MODIFY `EmployeeID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `employeetasks`
--
ALTER TABLE `employeetasks`
  MODIFY `EmployeeTaskID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `managers`
--
ALTER TABLE `managers`
  MODIFY `ManagerID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT для таблицы `meetings`
--
ALTER TABLE `meetings`
  MODIFY `MeetingID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT для таблицы `positions`
--
ALTER TABLE `positions`
  MODIFY `PositionID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `projectdocuments`
--
ALTER TABLE `projectdocuments`
  MODIFY `DocumentID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `projects`
--
ALTER TABLE `projects`
  MODIFY `ProjectID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT для таблицы `projecttechnologies`
--
ALTER TABLE `projecttechnologies`
  MODIFY `ProjectTechnologyID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `tasks`
--
ALTER TABLE `tasks`
  MODIFY `TaskID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT для таблицы `taskstatuses`
--
ALTER TABLE `taskstatuses`
  MODIFY `StatusID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `technologies`
--
ALTER TABLE `technologies`
  MODIFY `TechnologyID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `worklogs`
--
ALTER TABLE `worklogs`
  MODIFY `WorkLogID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `clientfeedback`
--
ALTER TABLE `clientfeedback`
  ADD CONSTRAINT `clientfeedback_ibfk_1` FOREIGN KEY (`ProjectID`) REFERENCES `projects` (`ProjectID`),
  ADD CONSTRAINT `clientfeedback_ibfk_2` FOREIGN KEY (`ClientID`) REFERENCES `clients` (`ClientID`);

--
-- Ограничения внешнего ключа таблицы `departments`
--
ALTER TABLE `departments`
  ADD CONSTRAINT `fk_departments_managers` FOREIGN KEY (`ManagerID`) REFERENCES `managers` (`ManagerID`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `employees`
--
ALTER TABLE `employees`
  ADD CONSTRAINT `employees_ibfk_1` FOREIGN KEY (`PositionID`) REFERENCES `positions` (`PositionID`),
  ADD CONSTRAINT `employees_ibfk_2` FOREIGN KEY (`DepartmentID`) REFERENCES `departments` (`DepartmentID`);

--
-- Ограничения внешнего ключа таблицы `employeetasks`
--
ALTER TABLE `employeetasks`
  ADD CONSTRAINT `employeetasks_ibfk_1` FOREIGN KEY (`TaskID`) REFERENCES `tasks` (`TaskID`),
  ADD CONSTRAINT `employeetasks_ibfk_2` FOREIGN KEY (`EmployeeID`) REFERENCES `employees` (`EmployeeID`) ON DELETE CASCADE;

--
-- Ограничения внешнего ключа таблицы `meetings`
--
ALTER TABLE `meetings`
  ADD CONSTRAINT `meetings_ibfk_1` FOREIGN KEY (`ProjectID`) REFERENCES `projects` (`ProjectID`);

--
-- Ограничения внешнего ключа таблицы `projectdocuments`
--
ALTER TABLE `projectdocuments`
  ADD CONSTRAINT `projectdocuments_ibfk_1` FOREIGN KEY (`ProjectID`) REFERENCES `projects` (`ProjectID`);

--
-- Ограничения внешнего ключа таблицы `projects`
--
ALTER TABLE `projects`
  ADD CONSTRAINT `projects_ibfk_1` FOREIGN KEY (`ClientID`) REFERENCES `clients` (`ClientID`),
  ADD CONSTRAINT `projects_ibfk_2` FOREIGN KEY (`ProjectManagerID`) REFERENCES `employees` (`EmployeeID`);

--
-- Ограничения внешнего ключа таблицы `projecttechnologies`
--
ALTER TABLE `projecttechnologies`
  ADD CONSTRAINT `projecttechnologies_ibfk_1` FOREIGN KEY (`ProjectID`) REFERENCES `projects` (`ProjectID`),
  ADD CONSTRAINT `projecttechnologies_ibfk_2` FOREIGN KEY (`TechnologyID`) REFERENCES `technologies` (`TechnologyID`);

--
-- Ограничения внешнего ключа таблицы `tasks`
--
ALTER TABLE `tasks`
  ADD CONSTRAINT `tasks_ibfk_1` FOREIGN KEY (`ProjectID`) REFERENCES `projects` (`ProjectID`),
  ADD CONSTRAINT `tasks_ibfk_2` FOREIGN KEY (`AssignedTo`) REFERENCES `employees` (`EmployeeID`),
  ADD CONSTRAINT `tasks_ibfk_3` FOREIGN KEY (`StatusID`) REFERENCES `taskstatuses` (`StatusID`);

--
-- Ограничения внешнего ключа таблицы `worklogs`
--
ALTER TABLE `worklogs`
  ADD CONSTRAINT `worklogs_ibfk_1` FOREIGN KEY (`EmployeeID`) REFERENCES `employees` (`EmployeeID`),
  ADD CONSTRAINT `worklogs_ibfk_2` FOREIGN KEY (`ProjectID`) REFERENCES `projects` (`ProjectID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
