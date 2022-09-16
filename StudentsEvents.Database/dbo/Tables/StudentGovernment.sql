CREATE TABLE [dbo].[StudentGovernment]
(
  [Id] INT NOT NULL PRIMARY KEY IDENTITY,

  -- INFO FIELDS
  [Name] NVARCHAR(128) NOT NULL,
  [ShortName] NVARCHAR(32) NOT NULL,
  [University] NVARCHAR(128) NOT NULL,
  [City] NVARCHAR(128) NOT NULL,
  [Region] NVARCHAR(128) NOT NULL,

  -- CONTACT FIELDS
  [Facebook] NVARCHAR(256) NOT NULL DEFAULT 'N/A',
  [Website] NVARCHAR(256) DEFAULT 'N/A',
  [Email] NVARCHAR(128) NOT NULL,

  [Username] NVARCHAR(128) NOT NULL,
)
