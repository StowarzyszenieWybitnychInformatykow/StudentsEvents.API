CREATE VIEW [dbo].[vwEvent_GetUnpublished]
  AS SELECT TOP (100) e.Id, e.Name, e.ShortDescription,
  [e].[Thumbnail], e.Background,
  e.Facebook, e.Website,
  e.Language, e.Upvotes,
  e.Registration, e.Tickets,
  e.Online, e.Location, e.Latitude, e.Longitude, e.City, e.Region,
  e.StartDate, e.EndDate,
  e.StudentGovernmentId, e.Published, e.OwnerID, e.Organization,
  e.LastModified
  FROM [dbo].[Event] as e 
  WHERE [Published] = 0 AND e.IsDeleted = 0
  ORDER BY e.StartDate ASC
