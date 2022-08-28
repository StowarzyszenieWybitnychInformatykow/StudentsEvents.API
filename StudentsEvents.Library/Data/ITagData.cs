using StudentsEvents.API.Models;

namespace StudentsEvents.Library.Data
{
    public interface ITagData
    {
        Task CreateTagAsync(EventDatabaseModel model);
        Task DeleteTagAsync(EventDatabaseModel model);
        Task<IEnumerable<EventDatabaseModel>> GetTagsAsync();
        Task UpdateTagAsync(EventDatabaseModel model);
    }
}