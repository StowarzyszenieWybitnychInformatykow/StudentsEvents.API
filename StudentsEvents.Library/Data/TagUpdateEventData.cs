using StudentsEvents.Library.DbAccess;
using StudentsEvents.Library.Models;

namespace StudentsEvents.Library.Data
{
    public class TagUpdateEventData : ITagUpdateEventData
    {
        private readonly ISqlDataAccess _data;

        public TagUpdateEventData(ISqlDataAccess data)
        {
            _data = data;
        }
        public async Task AddTagsToEvent(IEnumerable<TagDatabaseModel> tags, Guid EventId)
        {
            foreach (var item in tags)
            {
                await _data.SaveDataAsync("[dbo].[spUpdateEventTag_Add]", new { eventId = EventId, tagId = item.Id });
            }
        }
    }
}
