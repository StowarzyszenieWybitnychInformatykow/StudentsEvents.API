CREATE PROCEDURE [dbo].[spUpdateEvent_Add]
  @ID UNIQUEIDENTIFIER,
  @Name NVARCHAR(128),
  @ShortDescription NVARCHAR(128),
  
  @Thumbnail NVARCHAR(256),
  @Background NVARCHAR(256),

  @Facebook NVARCHAR(256) = 'N/A',
  @Website NVARCHAR(256) = 'N/A',

  @Language NVARCHAR(128) = 'N/A',
  @Upvotes INT = 0,

  @Registration BIT = 0,
  @Tickets BIT = 0,

  @Online BIT = 0,
  @Location NVARCHAR(128) = 'N/A',
  @Latitude FLOAT = 0,
  @Longitude FLOAT = 0,
  @City NVARCHAR(128) = 'N/A',
  @Region NVARCHAR(128) = 'N/A',

  @StartDate DATETIMEOFFSET,
  @EndDate DATETIMEOFFSET,

  @StudentGovernmentId INT = Null,
  @Published BIT,
  @OwnerID NVARCHAR(128),
  @Organization NVARCHAR(128),
  @LastModified DATETIMEOFFSET,

  @NewEventId INT OUTPUT

AS

BEGIN
  SET NOCOUNT ON;
  
  INSERT INTO [dbo].[UpdateEvent] ([EventId],
    [Name], [ShortDescription],
    [Thumbnail], [Background],
    [Facebook], [Website],
    [Language], [Upvotes],
    [Registration], [Tickets],
    [Online], [Location], [Latitude], [Longitude], [City], [Region],
    [StartDate], [EndDate],
    [StudentGovernmentId], [Published], [OwnerID], [Organization],
    [LastModified]
  )
  VALUES(@ID,
    @Name, @ShortDescription,
    @Thumbnail, @Background,
    @Facebook, @Website,
    @Language,  @Upvotes,
    @Registration, @Tickets,
    @Online, @Location, @Latitude, @Longitude, @City, @Region,
    @StartDate, @EndDate,
    @StudentGovernmentId, @Published, @OwnerID, @Organization,
    @LastModified
  )

  

  SELECT @NewEventId = SCOPE_IDENTITY();

END