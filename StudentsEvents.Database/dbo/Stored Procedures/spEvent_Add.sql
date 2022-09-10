CREATE PROCEDURE [dbo].[spEvent_Add]
  @Name NVARCHAR(128),
  @ShortDescription NVARCHAR(128),
  
  @Thumbnail NVARCHAR(256),
  @Background NVARCHAR(256),

  @Facebook NVARCHAR(256) = 'N/A',
  @Website NVARCHAR(256) = 'N/A',

  @Language NVARCHAR(128) = 'N/A',
  @Tags NVARCHAR(MAX),
  @Upvotes INT = 0,

  @Registration BIT = 0,
  @Tickets BIT = 0,

  @Online BIT = 0,
  @Latitude FLOAT = 0,
  @Longitude FLOAT = 0,
  @City NVARCHAR(128) = 'N/A',
  @Region NVARCHAR(128) = 'N/A',

  @StartDate DATETIME2,
  @EndDate DATETIME2,

  @StudentGovernmentId INT,
  @Published BIT,
  @OwnerID INT,
  @Organization NVARCHAR(128),

  @NewEventId INT OUTPUT

AS

BEGIN
  SET NOCOUNT ON;
  
  INSERT INTO [dbo].[Event] (
    [Name], [ShortDescription],
    [Thumbnail], [Background],
    [Facebook], [Website],
    [Language], [Tags], [Upvotes],
    [Registration], [Tickets],
    [Online], [Latitude], [Longitude], [City], [Region],
    [StartDate], [EndDate],
    [StudentGovernmentId], [Published], [OwnerID], [Organization]
  )
  VALUES(
    @Name, @ShortDescription,
    @Thumbnail, @Background,
    @Facebook, @Website,
    @Language, @Tags, @Upvotes,
    @Registration, @Tickets,
    @Online, @Latitude, @Longitude, @City, @Region,
    @StartDate, @EndDate,
    @StudentGovernmentId, @Published, @OwnerID, @Organization
  )

  

  SELECT @NewEventId = SCOPE_IDENTITY();

END