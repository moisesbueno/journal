
INSERT INTO qualis
            (description)
SELECT i.qualis_2019
FROM   importacao AS i
WHERE  qualis_2019 != ''
GROUP  BY i.qualis_2019;

INSERT INTO journal
            (id,
             issn,
             name,
             qualisid)
SELECT Uuid() AS Id,
       i.issn,
       i.name,
       q.id   AS QualisId
FROM   importacao AS i
       LEFT JOIN qualis AS q
              ON i.qualis_2019 = q.description; 