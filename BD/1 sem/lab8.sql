-- 1
CREATE TABLE software_projects (
    id INTEGER PRIMARY KEY,
    project_name TEXT NOT NULL,
    start_date DATE NOT NULL,
    end_date DATE NOT NULL,
    budget DECIMAL NOT NULL,
    status TEXT NOT NULL
);

-- 2
INSERT INTO software_projects (id, project_name, start_date, end_date, budget, status) VALUES
(1, 'Alpha', '2023-01-01', '2023-06-30', 100000, 'Active'),
(2, 'Beta', '2023-02-15', '2023-12-15', 150000, 'Active'),
(3, 'Gamma', '2023-03-20', '2023-07-20', 120000, 'Completed'),
(4, 'Delta', '2023-04-25', '2023-09-25', 50000, 'Delayed'),
(5, 'Epsilon', '2023-05-10', '2024-01-10', 80000, 'Active'),
(6, 'Zeta', '2023-06-15', '2023-12-31', 70000, 'Planning'),
(7, 'Eta', '2023-07-01', '2023-10-01', 90000, 'Active'),
(8, 'Theta', '2023-08-05', '2024-02-05', 110000, 'Planning'),
(9, 'Iota', '2023-09-15', '2023-11-15', 95000, 'Active'),
(10, 'Kappa', '2023-10-20', '2024-04-20', 200000, 'Planning');

-- 3
SELECT * FROM software_projects
WHERE budget > 80000;

SELECT * FROM software_projects
LIMIT 4 OFFSET 4;

SELECT * FROM software_projects
ORDER BY end_date;

-- 4
UPDATE software_projects
SET budget = budget * 1.1, status = 'Under Review'
WHERE budget > 100000 AND status != 'Completed';

-- 5
DELETE FROM software_projects
WHERE status = 'Planning' AND budget < 80000;