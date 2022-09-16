CREATE TABLE [dbo].[Event]
(
  [Id] INT NOT NULL PRIMARY KEY IDENTITY,

  -- INFO FIELDS
  [Name] NVARCHAR(128) NOT NULL,
  [ShortDescription] NVARCHAR(MAX) NOT NULL,
  
  [Thumbnail] NVARCHAR(256) NOT NULL,
  [Background] NVARCHAR(256) NOT NULL,

  [Facebook] NVARCHAR(256) DEFAULT 'N/A',
  [Website] NVARCHAR(256) DEFAULT 'N/A',
  
  [Language] NVARCHAR(128) NOT NULL DEFAULT 'N/A',
  [Tags] NVARCHAR(MAX) NOT NULL,
  [Upvotes] INT NOT NULL DEFAULT 0,

  [Registration] BIT NOT NULL DEFAULT 0,
  [Tickets] BIT NOT NULL DEFAULT 0, -- FOR PAID EVENTS

  -- LOCATION FIELDS
  [Online] BIT, -- if true, the rest of the location fields are ignored
  [Location] NVARCHAR(128) DEFAULT 'N/A',
  [Latitude] FLOAT DEFAULT 0,
  [Longitude] FLOAT DEFAULT 0,
  [City] NVARCHAR(128) DEFAULT 'N/A',
  [Region] NVARCHAR(128) DEFAULT 'N/A',
  
  -- DATE FIELDS
  [StartDate] DATETIME2 NOT NULL,
  [EndDate] DATETIME2 NOT NULL,

  -- ORGANIZER FIELDS
  [StudentGovernmentId] INT FOREIGN KEY REFERENCES [dbo].[StudentGovernment](Id) NOT NULL, 
  [Published] BIT NOT NULL DEFAULT 0, -- if true, the event is visible to the public
  [OwnerID] INT FOREIGN KEY REFERENCES [dbo].[User](Id) NOT NULL,
  [Organization] NVARCHAR(128) NOT NULL DEFAULT 'N/A',

  [LastModified] DATETIME2 NOT NULL DEFAULT CURRENT_TIMESTAMP,
)


