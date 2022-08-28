using StudentsEvents.API.Models;
using StudentsEvents.Library.Data;

namespace StudentsEvents.Library.SampleData
{
    public class SampleTagData : ITagData
    {
        List<TagDatabaseModel> _tags = new();
        public SampleTagData()
        {
            _tags.Add(new TagDatabaseModel()
            {
                Id = 1,
                Name = "Tag1"
            });
        }
        public async Task CreateTagAsync(TagDatabaseModel model)
        {
            _tags.Add(model);
        }

        public async Task DeleteTagAsync(TagDatabaseModel model)
        {
            _tags.Remove(model);
        }

        public async Task<TagDatabaseModel> GetTagByIdAsync(int id)
        {
            return _tags.Where(x => x.Id == id).First();
        }

        public async Task<IEnumerable<TagDatabaseModel>> GetTagsAsync()
        {
            return _tags.AsEnumerable();
        }

        public async Task UpdateTagAsync(TagDatabaseModel model)
        {
            var data = _tags.Where(x => x.Id == model.Id).FirstOrDefault();
            data.Name = model.Name;
        }
    }
}
