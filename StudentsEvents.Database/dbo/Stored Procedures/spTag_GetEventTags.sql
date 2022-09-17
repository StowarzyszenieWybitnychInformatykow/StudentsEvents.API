CREATE PROCEDURE [dbo].[spTag_GetEventTags]
  @Id UNIQUEIDENTIFIER
AS
BEGIN
  SET NOCOUNT ON;

  SELECT t.Id, t.Name
  FROM [dbo].[EventTags] as et
  LEFT JOIN [dbo].[Tag] as t on et.TagId = t.Id
  WHERE et.EventId = @Id;
END
