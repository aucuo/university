CREATE TABLE `clientfeedback` (
  `FeedbackID` int NOT NULL,
  `ProjectID` int DEFAULT NULL,
  `ClientID` int DEFAULT NULL,
  `Date` date DEFAULT NULL,
  `Text` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `clients` (
  `ClientID` int NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Industry` varchar(255) DEFAULT NULL,
  `ContactPerson` varchar(255) DEFAULT NULL,
  `Email` varchar(255) DEFAULT NULL,
  `Phone` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `departments` (
  `DepartmentID` int NOT NULL,
  `Name` varchar(255) NOT NULL,
  `ManagerID` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `employees` (
  `EmployeeID` int NOT NULL,
  `Name` varchar(255) NOT NULL,
  `PositionID` int DEFAULT NULL,
  `DepartmentID` int DEFAULT NULL,
  `Email` varchar(255) DEFAULT NULL,
  `Phone` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `employeetasks` (
  `EmployeeTaskID` int NOT NULL,
  `TaskID` int DEFAULT NULL,
  `EmployeeID` int DEFAULT NULL,
  `TimeSpent` int DEFAULT NULL,
  `Date` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `managers` (
  `ManagerID` int NOT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `Position` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `meetings` (
  `MeetingID` int NOT NULL,
  `ProjectID` int DEFAULT NULL,
  `MeetingDate` date DEFAULT NULL,
  `Agenda` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `positions` (
  `PositionID` int NOT NULL,
  `Title` varchar(255) NOT NULL,
  `SalaryGrade` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `projectdocuments` (
  `DocumentID` int NOT NULL,
  `ProjectID` int DEFAULT NULL,
  `Title` varchar(255) NOT NULL,
  `DocumentPath` varchar(255) DEFAULT NULL,
  `CreationDate` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `projects` (
  `ProjectID` int NOT NULL,
  `Name` varchar(255) NOT NULL,
  `StartDate` date DEFAULT NULL,
  `EndDate` date DEFAULT NULL,
  `Budget` decimal(10,2) DEFAULT NULL,
  `ClientID` int DEFAULT NULL,
  `ProjectManagerID` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `projecttechnologies` (
  `ProjectTechnologyID` int NOT NULL,
  `ProjectID` int DEFAULT NULL,
  `TechnologyID` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `tasks` (
  `TaskID` int NOT NULL,
  `ProjectID` int DEFAULT NULL,
  `AssignedTo` int DEFAULT NULL,
  `Description` text,
  `StartDate` date DEFAULT NULL,
  `EndDate` date DEFAULT NULL,
  `StatusID` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `taskstatuses` (
  `StatusID` int NOT NULL,
  `Name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `technologies` (
  `TechnologyID` int NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Description` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `worklogs` (
  `WorkLogID` int NOT NULL,
  `EmployeeID` int DEFAULT NULL,
  `ProjectID` int DEFAULT NULL,
  `HoursWorked` int DEFAULT NULL,
  `Date` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

ALTER TABLE `clientfeedback`
  ADD PRIMARY KEY (`FeedbackID`),
  ADD KEY `ProjectID` (`ProjectID`),
  ADD KEY `ClientID` (`ClientID`);

ALTER TABLE `clients`
  ADD PRIMARY KEY (`ClientID`);

ALTER TABLE `departments`
  ADD PRIMARY KEY (`DepartmentID`),
  ADD KEY `fk_departments_managers` (`ManagerID`);

ALTER TABLE `employees`
  ADD PRIMARY KEY (`EmployeeID`),
  ADD KEY `PositionID` (`PositionID`),
  ADD KEY `DepartmentID` (`DepartmentID`);

ALTER TABLE `employeetasks`
  ADD PRIMARY KEY (`EmployeeTaskID`),
  ADD KEY `TaskID` (`TaskID`),
  ADD KEY `employeetasks_ibfk_2` (`EmployeeID`);

ALTER TABLE `managers`
  ADD PRIMARY KEY (`ManagerID`);

ALTER TABLE `meetings`
  ADD PRIMARY KEY (`MeetingID`),
  ADD KEY `ProjectID` (`ProjectID`);

ALTER TABLE `positions`
  ADD PRIMARY KEY (`PositionID`);

ALTER TABLE `projectdocuments`
  ADD PRIMARY KEY (`DocumentID`),
  ADD KEY `ProjectID` (`ProjectID`);

ALTER TABLE `projects`
  ADD PRIMARY KEY (`ProjectID`),
  ADD KEY `ClientID` (`ClientID`),
  ADD KEY `ProjectManagerID` (`ProjectManagerID`);

ALTER TABLE `projecttechnologies`
  ADD PRIMARY KEY (`ProjectTechnologyID`),
  ADD KEY `ProjectID` (`ProjectID`),
  ADD KEY `TechnologyID` (`TechnologyID`);

ALTER TABLE `tasks`
  ADD PRIMARY KEY (`TaskID`),
  ADD KEY `ProjectID` (`ProjectID`),
  ADD KEY `AssignedTo` (`AssignedTo`),
  ADD KEY `StatusID` (`StatusID`);

ALTER TABLE `taskstatuses`
  ADD PRIMARY KEY (`StatusID`);

ALTER TABLE `technologies`
  ADD PRIMARY KEY (`TechnologyID`);

ALTER TABLE `worklogs`
  ADD PRIMARY KEY (`WorkLogID`),
  ADD KEY `EmployeeID` (`EmployeeID`),
  ADD KEY `ProjectID` (`ProjectID`);