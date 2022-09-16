CREATE PROCEDURE [dbo].[spEventTag_GetByEventId]
  @EventId int
AS
BEGIN
  SET NOCOUNT ON;
  SELECT et.TagId FROM [dbo].[EventTags] as et WHERE [EventId] = @EventId
END
