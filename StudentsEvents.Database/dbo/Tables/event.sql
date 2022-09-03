CREATE TABLE [dbo].[event]
(
  [id] INT NOT NULL PRIMARY KEY IDENTITY,
  [name] NVARCHAR(128) NOT NULL,
  [short-description] NVARCHAR(MAX) NOT NULL,
  [thumbnail] NVARCHAR(256) NOT NULL,
  [tickets] BIT NOT NULL,
  [latitude] FLOAT NOT NULL,
  [longitude] FLOAT NOT NULL,
  [tags] NVARCHAR(MAX) NOT NULL,
  [start-date] DATETIME NOT NULL,
  [end-date] DATETIME2 NOT NULL,
  [student-government-id] INT NOT NULL,
  [published] BIT NOT NULL DEFAULT 0,
  [owner] NVARCHAR(128) NOT NULL,
  [last-edit] DATETIME2 NOT NULL DEFAULT CURRENT_TIMESTAMP
)

