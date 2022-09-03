CREATE PROCEDURE [dbo].[spEvent_GetById]
  @Id INT
AS

BEGIN
  SET NOCOUNT ON;

  SELECT e.Id, e.Name, e.ShortDescription, e.Thumbnail, e.Website,
         e.Tickets, e.Latitude, e.Longitude, e.City, e.Region,
         e.Tags, e.StartDate, e.EndDate, e.StudentGovernmentId,
         e.Published, e.Owner, e.LastModified
  FROM [dbo].[Event] e
  WHERE e.Id = @Id;

END
