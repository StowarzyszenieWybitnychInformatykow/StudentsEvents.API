CREATE PROCEDURE [dbo].[spEventTag_Add]
  @eventId UNIQUEIDENTIFIER,
  @tagId INT,
  @NewEventTagId INT OUTPUT

AS
BEGIN
  SET NOCOUNT ON;
  INSERT INTO [dbo].[EventTags] (EventId, TagId)
  VALUES (@eventId, @tagId)

  SELECT @NewEventTagId = SCOPE_IDENTITY()
END

