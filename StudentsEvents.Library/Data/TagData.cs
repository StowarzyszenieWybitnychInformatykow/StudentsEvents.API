using AutoMapper;
using StudentsEvents.Library.DbAccess;
using StudentsEvents.Library.DBEntityModels;
using StudentsEvents.Library.Models;

namespace StudentsEvents.Library.Data
{
    public class TagData : ITagData
    {
        private readonly ISqlDataAccess _data;
        private readonly StudentsEventsDataDbContext _context;
        private readonly IMapper _mapper;

        public TagData(ISqlDataAccess data, StudentsEventsDataDbContext context, IMapper mapper)
        {
            _data = data;
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TagDatabaseModel>> GetTagsAsync()
        {
            return _mapper.Map<IEnumerable<TagDatabaseModel>>(_context.Tags.Where(x => x.IsDeleted == false));
        }
        public async Task CreateTagAsync(TagDatabaseModel model)
        {
            await _data.SaveDataAsync("[dbo].[spTag_Add]", new { Name = model.Name, NewIdOutputParam = 0 });
        }
        public async Task UpdateTagAsync(TagDatabaseModel model)
        {
            var data = await GetTagByIdAsync(model.Id);
            data.Name = model.Name;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteTagAsync(TagDatabaseModel model)
        {
            _context.Tags.Where(x => x.IsDeleted == false && x.Id == model.Id).Single().IsDeleted = true;
            await _context.SaveChangesAsync();
        }
        public async Task<TagDatabaseModel> GetTagByIdAsync(int id)
        {
            return (await _data.LoadDataAsync<TagDatabaseModel, dynamic>("[dbo].[spTag_GetById]", new { Id = id })).Single();
        }
    }
}
