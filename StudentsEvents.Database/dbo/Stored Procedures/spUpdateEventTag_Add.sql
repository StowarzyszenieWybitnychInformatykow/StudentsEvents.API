CREATE PROCEDURE [dbo].[spUpdateEventTag_Add]
  @eventId UNIQUEIDENTIFIER,
  @tagId INT

AS
BEGIN
  SET NOCOUNT ON;
  INSERT INTO [dbo].[EventTags] (EventId, TagId)
  VALUES (@eventId, @tagId)
END
