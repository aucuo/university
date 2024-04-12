-- Создание ролей
CREATE ROLE data_entry;
CREATE ROLE data_reviewer;
CREATE ROLE admin;

-- Создание пользователей
CREATE USER 'user1'@'localhost' IDENTIFIED BY '';
CREATE USER 'user2'@'localhost' IDENTIFIED BY '';
CREATE USER 'user3'@'localhost' IDENTIFIED BY '';
CREATE USER 'user4'@'localhost' IDENTIFIED BY '';
CREATE USER 'user5'@'localhost' IDENTIFIED BY '';

-- Назначение ролей пользователям
GRANT data_entry TO 'user1'@'localhost', 'user2'@'localhost';
GRANT data_reviewer TO 'user3'@'localhost', 'user4'@'localhost';
GRANT admin TO 'user5'@'localhost';

-- Ограничения доступа

-- для data_entry
GRANT INSERT ON aucusoft.clients TO 'data_entry';
GRANT INSERT ON aucusoft.employees TO 'data_entry';
GRANT INSERT ON aucusoft.employeetasks TO 'data_entry';
GRANT INSERT ON aucusoft.worklogs TO 'data_entry';

GRANT UPDATE ON aucusoft.clientfeedback TO 'data_entry';

-- для data_reviewer
GRANT SELECT ON aucusoft.projects TO 'data_reviewer';
GRANT SELECT ON aucusoft.tasks TO 'data_reviewer';
GRANT SELECT ON aucusoft.taskstatuses TO 'data_reviewer';
GRANT SELECT ON aucusoft.technologies TO 'data_reviewer';
GRANT SELECT ON aucusoft.projecttechnologies TO 'data_reviewer';

-- для admin
GRANT ALL PRIVILEGES ON aucusoft.* TO 'admin';
-- GRANT CREATE USER, DROP USER, GRANT OPTION ON *.* TO 'admin';
GRANT CREATE, DROP ON aucusoft.* TO 'admin';
GRANT ALTER, CREATE, INDEX ON aucusoft.* TO 'admin';
GRANT SELECT ON aucusoft.managers_log TO 'admin';

FLUSH PRIVILEGES;