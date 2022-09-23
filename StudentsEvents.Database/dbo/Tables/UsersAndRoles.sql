CREATE TABLE [dbo].[User]
(
  [Id] VARCHAR(28) NOT NULL, 
  [RoleId] INT NOT NULL,

   PRIMARY KEY ([Id], [RoleId])
)
