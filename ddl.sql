DROP DATABASE IF EXISTS dbjournal;

CREATE DATABASE dbjournal;

USE dbjournal;

CREATE TABLE importacao
  (
     issn        VARCHAR(20),
     name        VARCHAR(255),
     qualis_2019 VARCHAR(10)
  );

CREATE TABLE database_indexation
  (
     id          INT auto_increment,
     description VARCHAR(50),
     PRIMARY KEY(id)
  );

CREATE TABLE qualis
  (
     id          INT auto_increment,
     description VARCHAR(10),
     PRIMARY KEY(id)
  );

CREATE TABLE language
  (
     id          INT auto_increment,
     description VARCHAR(50),
     PRIMARY KEY(id)
  );

CREATE TABLE format
  (
     id       INT auto_increment,
     maxpages INT,
     maxwords INT,
     space    INT,
     fontsize INT,
     PRIMARY KEY(id)
  );

CREATE TABLE journal
  (
     id       CHAR(36),
     issn     VARCHAR(20),
     name     VARCHAR(255),
     qualisid INT,
     aimscope VARCHAR(255),
     formatid INT,
     apc      BOOLEAN,
     url      VARCHAR(200),
     PRIMARY KEY(id),
     FOREIGN KEY(qualisid) REFERENCES qualis(id),
     FOREIGN KEY(formatid) REFERENCES format(id)
  );

CREATE TABLE journal_language
  (
     journalid  CHAR(36),
     languageid INT,
     FOREIGN KEY(journalid) REFERENCES journal(id),
     FOREIGN KEY(languageid) REFERENCES language(id)
  );

CREATE TABLE journal_indexation
  (
     journalid           CHAR(36),
     journalindexationid INT,
     FOREIGN KEY(journalid) REFERENCES journal(id),
     FOREIGN KEY(journalindexationid) REFERENCES database_indexation(id)
  );

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