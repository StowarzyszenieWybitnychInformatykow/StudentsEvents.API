CREATE VIEW [dbo].[vwEvent_Get.sql]
  AS SELECT e.Id, e.Name, e.ShortDescription, e.Thumbnail, e.Website, 
          e.Tickets, e.Latitude, e.Longitude, e.City,
          e.Region, e.Tags, e.StartDate, e.EndDate,
          e.StudentGovernmentId, e.Published, e.Owner,
          e.LastModified
  FROM [dbo].[Event] as e 
  ORDER BY e.StartDate ASC