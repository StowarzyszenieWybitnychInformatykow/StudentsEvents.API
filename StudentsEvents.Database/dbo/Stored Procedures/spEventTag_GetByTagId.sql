CREATE PROCEDURE [dbo].[spEventTag_GetByEventId]
  @TagId int
AS
BEGIN
  SET NOCOUNT ON;
  SELECT et.EventId FROM [dbo].[EventTags] as et WHERE [TagId] = @TagId
END
