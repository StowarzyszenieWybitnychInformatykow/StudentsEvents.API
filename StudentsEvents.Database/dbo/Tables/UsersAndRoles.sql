CREATE TABLE [dbo].[User]
(
  [Id] UNIQUEIDENTIFIER NOT NULL, 
  [RoleId] INT NOT NULL,

   PRIMARY KEY ([Id], [RoleId])
)
