-- INNER JOIN
SELECT a.Name, b.Text
FROM clients a
INNER JOIN clientfeedback b ON a.ClientID = b.ClientID;

-- LEFT JOIN
SELECT a.Name, b.Text
FROM clients a
LEFT JOIN clientfeedback b ON a.ClientID = b.ClientID;

-- RIGHT JOIN
SELECT a.Name, b.Text
FROM clients a
RIGHT JOIN clientfeedback b ON a.ClientID = b.ClientID;

-- FULL JOIN аналог
SELECT a.Name, b.Text
FROM clients a
LEFT JOIN clientfeedback b ON a.ClientID = b.ClientID
UNION
SELECT a.Name, b.Text
FROM clients a
RIGHT JOIN clientfeedback b ON a.ClientID = b.ClientID;

-- CROSS JOIN
SELECT a.Name, b.Text
FROM clients a
CROSS JOIN clientfeedback b;

-- UNION
SELECT Name FROM clients
UNION
SELECT Text AS Name FROM clientfeedback;

-- EXCEPT и INTERSECT не поддерживаются

-- Доп.задание
SELECT p.Name AS ProjectName, c.Name AS ClientName, pd.Title AS DocumentName, t.Name
FROM projects p
INNER JOIN clients c ON p.ClientID = c.ClientID
LEFT JOIN projectdocuments pd ON p.ProjectID = pd.ProjectID
LEFT JOIN projecttechnologies pt ON p.ProjectID = pt.ProjectID
LEFT JOIN technologies t ON pt.TechnologyID = t.TechnologyID
WHERE p.ProjectID = 1;
