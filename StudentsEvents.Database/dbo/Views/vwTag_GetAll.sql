CREATE VIEW [dbo].[vwTag_GetAll]
  AS SELECT t.Id, t.Name
  FROM [dbo].[Tag] as t