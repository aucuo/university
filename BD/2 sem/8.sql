-- 1. INSERT TRIGGER - подставка данных из ContactPerson если email не указан

DELIMITER $$
CREATE TRIGGER trg_InsertClients
BEFORE INSERT ON clients
FOR EACH ROW
BEGIN
    IF NEW.Email IS NULL OR NEW.Email = '' THEN
        SET NEW.Email = CONCAT(NEW.ContactPerson, '@example.com');
    END IF;
END$$
DELIMITER ;

-- 2. UPDATE TRIGGER - запрещает изменение имени менеджера
DELIMITER $$
CREATE TRIGGER trg_UpdateManagers
BEFORE UPDATE ON managers
FOR EACH ROW
BEGIN
    IF OLD.Name <> NEW.Name THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Изменение имени менеджера запрещено';
    END IF;
END$$
DELIMITER ;

-- 3. DELETE TRIGGER - запрет удаления клиентов из индустрии Retail
DELIMITER $$
CREATE TRIGGER trg_DeleteClients
BEFORE DELETE ON clients
FOR EACH ROW
BEGIN
    IF OLD.Industry = 'Retail' THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Удаление клиентов из индустрии Retail запрещено';
    END IF;
END$$
DELIMITER ;

-- 4. AFTER UPDATE - логирование изменение должностей менеджеров
DELIMITER $$
CREATE TRIGGER trg_AfterUpdateManagers
AFTER UPDATE ON managers
FOR EACH ROW
BEGIN
    IF OLD.Position <> NEW.Position THEN
        INSERT INTO managers_log (ManagerID, OldPosition, NewPosition, ChangeDate)
        VALUES (OLD.ManagerID, OLD.Position, NEW.Position, NOW());
    END IF;
END$$
DELIMITER ;

-- 5. BEFORE INSERT - аналог INSTEAD OF триггера - проверяет уникальность имени менеджера и предотвращает вставку
DELIMITER $$

CREATE TRIGGER trg_BeforeInsertManagers
BEFORE INSERT ON managers
FOR EACH ROW
BEGIN
    DECLARE cnt INT;
    SELECT COUNT(*) INTO cnt FROM managers WHERE Name = NEW.Name;
    IF cnt > 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Менеджер с таким именем уже существует.';
    END IF;
END$$

DELIMITER ;
