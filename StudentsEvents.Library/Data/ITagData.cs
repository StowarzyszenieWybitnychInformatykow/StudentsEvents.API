using StudentsEvents.Library.Models;

namespace StudentsEvents.Library.Data
{
    public interface ITagData
    {
        Task CreateTagAsync(TagDatabaseModel model);
        Task DeleteTagAsync(TagDatabaseModel model);
        Task<TagDatabaseModel> GetTagByIdAsync(int id);
        Task<IEnumerable<TagDatabaseModel>> GetTagsAsync();
        Task UpdateTagAsync(TagDatabaseModel model);
    }
}