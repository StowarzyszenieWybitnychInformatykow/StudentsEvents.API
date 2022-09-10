CREATE VIEW [dbo].[EventTags]
  AS SELECT et.EventID, et.TagID
  FROM [dbo].[EventTag] as et
  ORDER BY et.EventID ASC

