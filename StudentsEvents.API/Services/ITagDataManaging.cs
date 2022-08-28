using StudentsEvents.API.Models;

namespace StudentsEvents.API.Services
{
    public interface ITagDataManaging
    {
        Task CreateAsync(TagModel model);
        Task DeleteAsync(TagModel model);
        Task<IEnumerable<TagModel>> GetAllTagsAsync();
        Task<TagModel> GetTagByIdAsync(int id);
        Task UpdateAsync(TagModel model);
    }
}