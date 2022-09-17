using StudentsEvents.Library.Models;

namespace StudentsEvents.Library.Services
{
    public interface ITagDataManaging
    {
        Task CreateAsync(TagModel model);
        Task DeleteAsync(TagModel model);
        Task<PagedList<TagModel>> GetAllTagsAsync(PagingModel paging);
        Task<TagModel> GetTagByIdAsync(int id);
        Task UpdateAsync(TagModel model);
    }
}