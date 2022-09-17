CREATE PROCEDURE [dbo].[spTag_GetById]
  @Id INT

AS

BEGIN
  SET NOCOUNT ON;

  SELECT t.Id, t.Name
  FROM [dbo].[Tag] t
  WHERE t.Id = @Id 
  AND t.IsDeleted = 0;

END
