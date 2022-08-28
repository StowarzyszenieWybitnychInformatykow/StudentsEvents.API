using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsEvents.API.Models;
using StudentsEvents.API.Services;

namespace StudentsEvents.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagDataManaging _tagData;

        public TagsController(ITagDataManaging tagData)
        {
            _tagData = tagData;
        }
        [HttpGet]
        public async Task<IEnumerable<TagModel>> Get()
        {
            return await _tagData.GetAllTagsAsync();
        }
        [HttpGet("{id}")]
        public async Task<TagModel> Get(int id)
        {
            return await _tagData.GetTagByIdAsync(id);
        }
        [HttpPost]
        public async Task Create(TagModel model)
        {
            await _tagData.CreateAsync(model);
        }
        [HttpPut("{id}")]
        public async Task Update(int id, TagModel model)
        {
            await _tagData.UpdateAsync(model);
        }
        [HttpDelete]
        public async Task Delete(TagModel model)
        {
            await _tagData.DeleteAsync(model);
        }
    }
}
