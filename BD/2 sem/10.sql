START TRANSACTION;
INSERT INTO clients (Name, Industry, ContactPerson, Email, Phone) VALUES ('NewCorp', 'IT', 'John Doe', 'johndoe@newcorp.com', '1234567890');
INSERT INTO managers (Name, Position) VALUES ('Jane Smith', 'Account Manager');
COMMIT;

START TRANSACTION;
UPDATE clients SET Email = 'newemail@newcorp.com', Phone = '0987654321' WHERE ClientID = 9;
COMMIT;

START TRANSACTION;
DELETE FROM meetings WHERE ProjectID IN (SELECT ClientID FROM clients WHERE Name = 'OldCorp');
DELETE FROM clients WHERE Name = 'OldCorp';
COMMIT;

START TRANSACTION;
UPDATE clients SET ContactPerson = 'New Manager' WHERE ClientID = 2;
COMMIT;

-- with IF
DELIMITER $$

CREATE PROCEDURE AddMeeting(IN p_ProjectID INT, IN p_MeetingDate DATE, IN p_Agenda TEXT)
BEGIN
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

DELIMITER ;
CALL AddMeeting(-1, '2024-04-15', 'Обсуждение проекта');

-- SESSIONS
-- 1
SET SESSION TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
START TRANSACTION;
INSERT INTO meetings (ProjectID, MeetingDate, Agenda) VALUES (10, '2024-05-01', 'Планирование проекта');
-- 
SET SESSION TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
SELECT * FROM meetings WHERE ProjectID = 10;

-- 2
SET SESSION TRANSACTION ISOLATION LEVEL READ COMMITTED;

-- 3
SET SESSION TRANSACTION ISOLATION LEVEL REPEATABLE READ;

-- 4
SET SESSION TRANSACTION ISOLATION LEVEL SERIALIZABLE;
--
SET SESSION TRANSACTION ISOLATION LEVEL SERIALIZABLE;
START TRANSACTION;
    UPDATE meetings SET Agenda = 'Новая агенда для ProjectID 1' WHERE ProjectID = 1;
COMMIT;
