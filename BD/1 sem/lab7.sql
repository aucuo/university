SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `lab7`
--

-- --------------------------------------------------------

--
-- Структура таблицы `Customer`
--

CREATE TABLE `Customer` (
  `CustomerID` int NOT NULL,
  `ProjectID` int NOT NULL,
  `Customer_statusID` int NOT NULL,
  `Customer_name` varchar(55) DEFAULT NULL,
  `Contacts` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `Customer_status`
--

CREATE TABLE `Customer_status` (
  `Customer_statusID` int NOT NULL,
  `Customer_status` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `Department`
--

CREATE TABLE `Department` (
  `DepartmentID` int NOT NULL,
  `DirectionID` int NOT NULL,
  `Director` varchar(55) NOT NULL,
  `Definition` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `Direction`
--

CREATE TABLE `Direction` (
  `DirectionID` int NOT NULL,
  `Direction` varchar(255) NOT NULL,
  `Number_of_people` int NOT NULL,
  `Main_specialist` varchar(70) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `Employee`
--

CREATE TABLE `Employee` (
  `EmployeeID` int NOT NULL,
  `OfficeID` int NOT NULL,
  `ProjectID` int NOT NULL,
  `PostID` int NOT NULL,
  `Employee_name` varchar(55) NOT NULL,
  `Employee_age` int DEFAULT NULL
) ;

-- --------------------------------------------------------

--
-- Структура таблицы `Office`
--

CREATE TABLE `Office` (
  `OfficeID` int NOT NULL,
  `DepartmentID` int NOT NULL,
  `Director` varchar(55) NOT NULL,
  `Address` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `Post`
--

CREATE TABLE `Post` (
  `PostID` int NOT NULL,
  `Post` varchar(7) NOT NULL,
  `Salary` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `Project`
--

CREATE TABLE `Project` (
  `ProjectID` int NOT NULL,
  `Deadline` date NOT NULL,
  `Price` int NOT NULL,
  `Project_name` varchar(255) NOT NULL,
  `Project_statusID` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `Project_status`
--

CREATE TABLE `Project_status` (
  `Project_statusID` int NOT NULL,
  `Project_status` varchar(12) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `Customer`
--
ALTER TABLE `Customer`
  ADD PRIMARY KEY (`CustomerID`),
  ADD UNIQUE KEY `Contacts` (`Contacts`),
  ADD UNIQUE KEY `Customer_name` (`Customer_name`),
  ADD KEY `ProjectID` (`ProjectID`),
  ADD KEY `Customer_statusID` (`Customer_statusID`);

--
-- Индексы таблицы `Customer_status`
--
ALTER TABLE `Customer_status`
  ADD PRIMARY KEY (`Customer_statusID`),
  ADD UNIQUE KEY `Customer_status` (`Customer_status`);

--
-- Индексы таблицы `Department`
--
ALTER TABLE `Department`
  ADD PRIMARY KEY (`DepartmentID`),
  ADD UNIQUE KEY `Director` (`Director`),
  ADD UNIQUE KEY `Definition` (`Definition`),
  ADD KEY `DirectionID` (`DirectionID`);

--
-- Индексы таблицы `Direction`
--
ALTER TABLE `Direction`
  ADD PRIMARY KEY (`DirectionID`),
  ADD UNIQUE KEY `Direction` (`Direction`),
  ADD UNIQUE KEY `Main_specialist` (`Main_specialist`);

--
-- Индексы таблицы `Employee`
--
ALTER TABLE `Employee`
  ADD PRIMARY KEY (`EmployeeID`),
  ADD UNIQUE KEY `Employee_name` (`Employee_name`),
  ADD KEY `OfficeID` (`OfficeID`),
  ADD KEY `ProjectID` (`ProjectID`),
  ADD KEY `PostID` (`PostID`);

--
-- Индексы таблицы `Office`
--
ALTER TABLE `Office`
  ADD PRIMARY KEY (`OfficeID`),
  ADD UNIQUE KEY `Director` (`Director`),
  ADD UNIQUE KEY `Address` (`Address`),
  ADD KEY `DepartmentID` (`DepartmentID`);

--
-- Индексы таблицы `Post`
--
ALTER TABLE `Post`
  ADD PRIMARY KEY (`PostID`),
  ADD UNIQUE KEY `Post` (`Post`);

--
-- Индексы таблицы `Project`
--
ALTER TABLE `Project`
  ADD PRIMARY KEY (`ProjectID`),
  ADD KEY `Project_statusID` (`Project_statusID`);

--
-- Индексы таблицы `Project_status`
--
ALTER TABLE `Project_status`
  ADD PRIMARY KEY (`Project_statusID`),
  ADD UNIQUE KEY `Project_status` (`Project_status`);

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `Customer`
--
ALTER TABLE `Customer`
  ADD CONSTRAINT `customer_ibfk_1` FOREIGN KEY (`ProjectID`) REFERENCES `Project` (`ProjectID`),
  ADD CONSTRAINT `customer_ibfk_2` FOREIGN KEY (`Customer_statusID`) REFERENCES `Customer_status` (`Customer_statusID`);

--
-- Ограничения внешнего ключа таблицы `Department`
--
ALTER TABLE `Department`
  ADD CONSTRAINT `department_ibfk_1` FOREIGN KEY (`DirectionID`) REFERENCES `Direction` (`DirectionID`);

--
-- Ограничения внешнего ключа таблицы `Employee`
--
ALTER TABLE `Employee`
  ADD CONSTRAINT `employee_ibfk_1` FOREIGN KEY (`OfficeID`) REFERENCES `Office` (`OfficeID`),
  ADD CONSTRAINT `employee_ibfk_2` FOREIGN KEY (`ProjectID`) REFERENCES `Project` (`ProjectID`),
  ADD CONSTRAINT `employee_ibfk_3` FOREIGN KEY (`PostID`) REFERENCES `Post` (`PostID`);

--
-- Ограничения внешнего ключа таблицы `Office`
--
ALTER TABLE `Office`
  ADD CONSTRAINT `office_ibfk_1` FOREIGN KEY (`DepartmentID`) REFERENCES `Department` (`DepartmentID`);

--
-- Ограничения внешнего ключа таблицы `Project`
--
ALTER TABLE `Project`
  ADD CONSTRAINT `project_ibfk_1` FOREIGN KEY (`Project_statusID`) REFERENCES `Project_status` (`Project_statusID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
