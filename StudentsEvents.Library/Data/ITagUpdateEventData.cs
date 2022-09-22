using StudentsEvents.Library.Models;

namespace StudentsEvents.Library.Data
{
    public interface ITagUpdateEventData
    {
        Task AddTagsToEvent(IEnumerable<TagDatabaseModel> tags, Guid EventId);
    }
}