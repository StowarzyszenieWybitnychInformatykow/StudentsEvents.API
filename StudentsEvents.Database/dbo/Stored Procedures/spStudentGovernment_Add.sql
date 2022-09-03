CREATE PROCEDURE [dbo].[spStudentGovernment_Add]
@Name NVARCHAR(128),
@ShortName NVARCHAR(32),
@University NVARCHAR(128),
@City NVARCHAR(128),
@Region NVARCHAR(128),
@Website NVARCHAR(256),
@Email NVARCHAR(128),
@Username NVARCHAR(128),
@PasswordHash NVARCHAR(128),
@NewIdOutputParam INT

AS

BEGIN
  SET NOCOUNT ON;

  INSERT INTO [dbo].[StudentGovernment] ([Name], [ShortName],
  [University], [City], [Region], [Website], [Email], [Username], [PasswordHash])
  VALUES (@Name, @ShortName,
  @University, @City, @Region, @Website, @Email, @Username, @PasswordHash);

  SELECT @NewIdOutputParam = SCOPE_IDENTITY();

END