CREATE VIEW [dbo].[vwEvent_Get.sql]
  AS SELECT e.Id, e.Name, e.ShortDescription,
  e.Thumbnail, e.Background,
  e.Facebook, e.Website,
  e.Language, e.Tags, e.Upvotes,
  e.Registration, e.Tickets,
  e.Online, e.Location, e.Latitude, e.Longitude, e.City, e.Region,
  e.StartDate, e.EndDate,
  e.StudentGovernmentId, e.Published, e.OwnerID, e.Organization,
  e.LastModified
  FROM [dbo].[Event] as e 
  ORDER BY e.StartDate ASC