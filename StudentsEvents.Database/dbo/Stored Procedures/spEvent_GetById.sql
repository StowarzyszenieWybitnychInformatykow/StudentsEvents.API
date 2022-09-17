CREATE PROCEDURE [dbo].[spEvent_GetById]
  @Id UNIQUEIDENTIFIER 
AS

BEGIN
  SET NOCOUNT ON;

  SELECT e.Id, e.Name, e.ShortDescription,
  e.Thumbnail, e.Background,
  e.Facebook, e.Website,
  e.Language, e.Upvotes,
  e.Registration, e.Tickets,
  e.Online, e.Location, e.Latitude, e.Longitude, e.City, e.Region,
  e.StartDate, e.EndDate,
  e.StudentGovernmentId, e.Published, e.OwnerID, e.Organization,
  e.LastModified
  FROM [dbo].[Event] e
  WHERE e.Id = @Id AND e.IsDeleted = 0;

END
