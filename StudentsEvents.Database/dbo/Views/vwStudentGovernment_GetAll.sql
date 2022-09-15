CREATE VIEW [dbo].[vwStudentGovernment_GetAll]
  AS SELECT sg.Id,
  sg.Name, sg.ShortName, sg.University, sg.City, sg.Region,
  sg.Facebook, sg.Website, sg.Email,
  sg.Username
  FROM [dbo].[StudentGovernment] as sg
  ORDER BY sg.Name ASC
