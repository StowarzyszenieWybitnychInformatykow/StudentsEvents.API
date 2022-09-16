CREATE PROCEDURE [dbo].[spEvent_GetPage]
  @page INT = 0,
  @pageSize INT = 10

AS

BEGIN
  SET NOCOUNT ON;

  SELECT
  e.Id, e.Name, e.ShortDescription,
  e.Thumbnail, e.Background,
  e.Facebook, e.Website,
  e.Language, e.Tags, e.Upvotes,
  e.Registration, e.Tickets,
  e.Online, e.Location, e.Latitude, e.Longitude, e.City, e.Region,
  e.StartDate, e.EndDate,
  e.StudentGovernmentId, e.Published, e.OwnerID, e.Organization,
  e.LastModified
  FROM [dbo].[Event] e
  WHERE e.Published = 1
  and e.EndDate > GETDATE()
  ORDER BY e.StartDate
  OFFSET @page * @pageSize ROWS
  FETCH NEXT @pageSize ROWS ONLY;

END
