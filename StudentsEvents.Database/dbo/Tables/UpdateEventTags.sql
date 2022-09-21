CREATE TABLE [dbo].[UpdateEventTags]
(
  [EventId] INT FOREIGN KEY REFERENCES [dbo].[UpdateEvent](Id) NOT NULL,
  [TagId] INT FOREIGN KEY REFERENCES [dbo].[Tag](Id) NOT NULL,
  PRIMARY KEY ([EventId], [TagId])
)
