CREATE PROCEDURE [dbo].[spEvent_Add]
  @Name NVARCHAR(128),
  @ShortDescription NVARCHAR(128),
  @Thumbnail NVARCHAR(256),
  @Website NVARCHAR(256),
  @Tickets BIT,
  @Latitude FLOAT,
  @Longitude FLOAT,
  @City NVARCHAR(128),
  @Region NVARCHAR(128),
  @Tags NVARCHAR(MAX),
  @StartDate DATETIME2,
  @EndDate DATETIME2,
  @StudentGovernmentId INT,
  @Published BIT = 0,
  @Owner NVARCHAR(128),
  @NewIdOutputParam INT

AS

BEGIN
  SET NOCOUNT ON;
  
  INSERT INTO [dbo].[Event] ([Name], [ShortDescription],
  [Thumbnail], [Website], [Tickets], [Latitude], [Longitude],
  [City], [Region], [Tags], [StartDate], [EndDate],
  [StudentGovernmentId], [Published], [Owner], [LastModified])
  VALUES (@Name, @ShortDescription,
  @Thumbnail, @Website, @Tickets, @Latitude, @Longitude,
  @City, @Region, @Tags, @StartDate, @EndDate,
  @StudentGovernmentId, @Published, @Owner, GETDATE());

  SELECT @NewIdOutputParam = SCOPE_IDENTITY();

END