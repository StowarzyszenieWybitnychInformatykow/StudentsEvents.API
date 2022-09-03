CREATE PROCEDURE [dbo].[spEvent_GetUnpublishedByGovernmentId]
  @StudentGovernmentId int

AS
BEGIN
  SET NOCOUNT ON;
  
  SELECT e.Id, e.Name, e.ShortDescription, e.Thumbnail,
          e.Tickets, e.Latitude, e.Longitude, e.City,
          e.Region, e.Tags, e.StartDate, e.EndDate,
          e.StudentGovernmentId, e.Published, e.Owner,
          e.LastModified
  FROM [dbo].[Event] as e 
  WHERE [StudentGovernmentId] = @StudentGovernmentId AND [Published] = 0
END
