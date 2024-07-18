alter table journal add column CreatedAt DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP;
alter table journal add column UpdatedAt DateTime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP;
