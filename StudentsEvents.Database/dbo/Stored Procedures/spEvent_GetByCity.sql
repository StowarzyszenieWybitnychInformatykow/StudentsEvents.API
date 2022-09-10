CREATE PROCEDURE [dbo].[spEvent_GetById]
  @City INT
AS

BEGIN
  SET NOCOUNT ON;

  SELECT e.Id, e.Name, e.ShortDescription,
  e.Thumbnail, e.Background,
  e.Facebook, e.Website,
  e.Language, e.Tags, e.Upvotes,
  e.Registration, e.Tickets,
  e.Online, e.Latitude, e.Longitude, e.City, e.Region,
  e.StartDate, e.EndDate,
  e.StudentGovernmentId, e.Published, e.OwnerID, e.Organization,
  e.LastModified
  FROM [dbo].[Event] e
  WHERE e.City LIKE '%' + @City + '%'
  AND e.Published = 1
  AND e.EndDate > GETDATE();

END
