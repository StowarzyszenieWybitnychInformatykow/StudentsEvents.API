CREATE TABLE [dbo].[EventTags]
(
  [EventId] INT FOREIGN KEY REFERENCES [dbo].[Event](Id) NOT NULL,
  [TagId] INT FOREIGN KEY REFERENCES [dbo].[Tag](Id) NOT NULL,
  PRIMARY KEY ([EventId], [TagId])
)
