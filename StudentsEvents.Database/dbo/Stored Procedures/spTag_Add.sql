CREATE PROCEDURE [dbo].[spTag_Add]
  @Name NVARCHAR(128),
  @NewIdOutputParam INT

AS
BEGIN
  SET NOCOUNT ON;

  INSERT INTO [dbo].[Tag] ([Name])
  VALUES (@Name)

  SELECT @NewIdOutputParam = SCOPE_IDENTITY()

END
