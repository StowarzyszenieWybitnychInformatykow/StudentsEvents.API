using AutoMapper;
using StudentsEvents.API.Models;
using StudentsEvents.Library.Data;

namespace StudentsEvents.API.Services
{
    public class TagDataManaging : ITagDataManaging
    {
        private readonly IMapper _mapper;
        private readonly ITagData _tagData;

        public TagDataManaging(IMapper mapper, ITagData tagData)
        {
            _mapper = mapper;
            _tagData = tagData;
        }
        public async Task<PagedList<TagModel>> GetAllTagsAsync(PagingModel paging)
        {

            var data = _mapper.Map<IEnumerable<TagModel>>(await _tagData.GetTagsAsync());

            return PagedList<TagModel>.ToPagedList(_mapper ,(await _tagData.GetTagsAsync()).AsQueryable(),
                        paging.PageNumber,
                        paging.PageSize);
        }
        public async Task<TagModel> GetTagByIdAsync(int id)
        {
            return _mapper.Map<TagModel>(await _tagData.GetTagByIdAsync(id));
        }
        public async Task CreateAsync(TagModel model)
        {
            await _tagData.CreateTagAsync(_mapper.Map<TagDatabaseModel>(model));
        }
        public async Task UpdateAsync(TagModel model)
        {
            await _tagData.UpdateTagAsync(_mapper.Map<TagDatabaseModel>(model));
        }
        public async Task DeleteAsync(TagModel model)
        {
            await _tagData.DeleteTagAsync(_mapper.Map<TagDatabaseModel>(model));
        }
    }
}
