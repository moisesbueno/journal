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
<<<<<<< HEAD
     Id          CHAR(36),
=======
     id          INT auto_increment,
>>>>>>> c63afb58e6d06c77e8f9a02d593152036bd6f245
     description VARCHAR(50),
     CreatedAt DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP,
     UpdatedAt DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
     PRIMARY KEY(id)
  );

CREATE TABLE qualis
  (
<<<<<<< HEAD
     Id          CHAR(36),
=======
     id          INT auto_increment,
>>>>>>> c63afb58e6d06c77e8f9a02d593152036bd6f245
     description VARCHAR(10),
     CreatedAt DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP,
     UpdatedAt DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
     PRIMARY KEY(id)
  );

CREATE TABLE language
  (
<<<<<<< HEAD
     Id          CHAR(36),
=======
     id          INT auto_increment,
>>>>>>> c63afb58e6d06c77e8f9a02d593152036bd6f245
     description VARCHAR(50),
     CreatedAt DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP,
     UpdatedAt DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
     PRIMARY KEY(id)
  );

CREATE TABLE format
  (
<<<<<<< HEAD
     Id          CHAR(36),
=======
     id       INT auto_increment,
>>>>>>> c63afb58e6d06c77e8f9a02d593152036bd6f245
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
<<<<<<< HEAD
     Id       CHAR(36),
     issn     VARCHAR(20),
     name     VARCHAR(255),
     qualisid CHAR(36),
     aimscope VARCHAR(255),
     formatid CHAR(36),
=======
     id       CHAR(36),
     issn     VARCHAR(20),
     name     VARCHAR(255),
     qualisid INT,
     aimscope VARCHAR(255),
     formatid INT,
>>>>>>> c63afb58e6d06c77e8f9a02d593152036bd6f245
     apc      BOOLEAN,
     url      VARCHAR(200),
     CreatedAt DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP,
     UpdatedAt DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
<<<<<<< HEAD
     PRIMARY KEY(Id),
     FOREIGN KEY(qualisid) REFERENCES qualis(Id),
     FOREIGN KEY(formatid) REFERENCES format(Id)
=======
     PRIMARY KEY(id),
     FOREIGN KEY(qualisid) REFERENCES qualis(id),
     FOREIGN KEY(formatid) REFERENCES format(id)
>>>>>>> c63afb58e6d06c77e8f9a02d593152036bd6f245
  );

CREATE TABLE journal_language
  (
<<<<<<< HEAD
     Journalid  CHAR(36),
     Languageid CHAR(36),
=======
     journalid  CHAR(36),
     languageid INT,
>>>>>>> c63afb58e6d06c77e8f9a02d593152036bd6f245
     CreatedAt DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP,
     UpdatedAt DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
     FOREIGN KEY(journalid) REFERENCES journal(id),
     FOREIGN KEY(languageid) REFERENCES language(id)
  );

CREATE TABLE journal_indexation
  (
<<<<<<< HEAD
     Journalid           CHAR(36),
     Journalindexationid CHAR(36),
=======
     journalid           CHAR(36),
     journalindexationid INT,
>>>>>>> c63afb58e6d06c77e8f9a02d593152036bd6f245
     CreatedAt DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP,
     UpdatedAt DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
     FOREIGN KEY(journalid) REFERENCES journal(id),
     FOREIGN KEY(journalindexationid) REFERENCES database_indexation(id)
  );

CREATE TABLE user
(
<<<<<<< HEAD
	Id CHAR(36) NOT NULL,
=======
	Id varchar(36) NOT NULL,
>>>>>>> c63afb58e6d06c77e8f9a02d593152036bd6f245
    Email varchar(80) NOT NULL,
    Password varchar(80) NOT NULL,
    CreatedAt DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    primary key (Id)
);