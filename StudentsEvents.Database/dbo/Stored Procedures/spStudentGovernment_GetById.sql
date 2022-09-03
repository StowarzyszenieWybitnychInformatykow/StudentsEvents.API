CREATE PROCEDURE [dbo].[spStudentGovernment_GetById]
  @Id INT
AS

BEGIN

  SET NOCOUNT ON;

  SELECT sg.Id, sg.Name, sg.ShortName, sg.University,
          sg.City, sg.Region, sg.Website, sg.Email, sg.Username
  FROM [dbo].[StudentGovernment] sg
  WHERE sg.Id = @Id;

END
