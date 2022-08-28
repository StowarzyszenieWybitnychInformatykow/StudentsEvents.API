using StudentsEvents.API.Models;
using StudentsEvents.Library.DbAccess;

namespace StudentsEvents.Library.Data
{
    public class TagData : ITagData
    {
        private readonly ISqlDataAccess _data;

        public TagData(ISqlDataAccess data)
        {
            _data = data;
        }
        public async Task<IEnumerable<TagDatabaseModel>> GetTagsAsync()
        {
            throw new NotImplementedException();
        }
        public async Task CreateTagAsync(TagDatabaseModel model)
        {
            throw new NotImplementedException();
        }
        public async Task UpdateTagAsync(TagDatabaseModel model)
        {
            throw new NotImplementedException();
        }
        public async Task DeleteTagAsync(TagDatabaseModel model)
        {
            throw new NotImplementedException();
        }
        public async Task<TagDatabaseModel> GetTagByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
