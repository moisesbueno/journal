CREATE TABLE importacao
  (
     issn        VARCHAR(20),
     name        VARCHAR(255),
     qualis_2019 VARCHAR(10),
     CreatedAt DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP,
     UpdatedAt DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
  );

CREATE TABLE database_indexation
  (
     id          INT auto_increment,
     description VARCHAR(50),
     CreatedAt DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP,
     UpdatedAt DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
     PRIMARY KEY(id)
  );

CREATE TABLE qualis
  (
     id          INT auto_increment,
     description VARCHAR(10),
     CreatedAt DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP,
     UpdatedAt DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
     PRIMARY KEY(id)
  );

CREATE TABLE language
  (
     id          INT auto_increment,
     description VARCHAR(50),
     CreatedAt DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP,
     UpdatedAt DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
     PRIMARY KEY(id)
  );

CREATE TABLE format
  (
     id       INT auto_increment,
     maxpages INT,
     maxwords INT,
     space    INT,
     fontsize INT,
     CreatedAt DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP,
     UpdatedAt DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
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
     CreatedAt DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP,
     UpdatedAt DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
     PRIMARY KEY(id),
     FOREIGN KEY(qualisid) REFERENCES qualis(id),
     FOREIGN KEY(formatid) REFERENCES format(id)
  );

CREATE TABLE journal_language
  (
     journalid  CHAR(36),
     languageid INT,
     CreatedAt DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP,
     UpdatedAt DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
     FOREIGN KEY(journalid) REFERENCES journal(id),
     FOREIGN KEY(languageid) REFERENCES language(id)
  );

CREATE TABLE journal_indexation
  (
     journalid           CHAR(36),
     journalindexationid INT,
     CreatedAt DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP,
     UpdatedAt DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
     FOREIGN KEY(journalid) REFERENCES journal(id),
     FOREIGN KEY(journalindexationid) REFERENCES database_indexation(id)
  );