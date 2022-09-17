using StudentsEvents.Library.Models;

namespace StudentsEvents.Library.Data
{
    public interface ITagEventData
    {
        Task AddTagsToEvent(IEnumerable<TagDatabaseModel> tags, Guid EventId);
        Task<IEnumerable<TagDatabaseModel>> GetTagsByEventIdAsync(Guid id);
    }
}