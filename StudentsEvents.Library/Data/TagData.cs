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
        public async Task<IEnumerable<EventDatabaseModel>> GetTagsAsync()
        {
            throw new NotImplementedException();
        }
        public async Task CreateTagAsync(EventDatabaseModel model)
        {
            throw new NotImplementedException();
        }
        public async Task UpdateTagAsync(EventDatabaseModel model)
        {
            throw new NotImplementedException();
        }
        public async Task DeleteTagAsync(EventDatabaseModel model)
        {
            throw new NotImplementedException();
        }
    }
}
