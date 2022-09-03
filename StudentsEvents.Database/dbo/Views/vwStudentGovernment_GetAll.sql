CREATE VIEW [dbo].[vwStudentGovernment_GetAll]
  AS SELECT sg.Id, sg.Name, sg.ShortName, sg.University, sg.City, 
            sg.Region, sg.Website, sg.Email, sg.Username
  FROM [dbo].[StudentGovernment] as sg
          