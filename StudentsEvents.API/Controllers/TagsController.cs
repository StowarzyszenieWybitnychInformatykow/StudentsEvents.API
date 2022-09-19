using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        public async Task<IActionResult> Get([FromQuery] PagingModel paging)
        {
            var owners = await _tagData.GetAllTagsAsync(paging);
            var metadata = new
            {
                owners.TotalCount,
                owners.PageSize,
                owners.CurrentPage,
                owners.TotalPages,
                owners.HasNext,
                owners.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(owners);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _tagData.GetTagByIdAsync(id));
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(TagModel model)
        {
            await _tagData.CreateAsync(model);
            return Ok();
        }
        //[Authorize]
        //[HttpPut]
        //public async Task<IActionResult> Update(TagModel model)
        //{
        //    await _tagData.UpdateAsync(model);
        //    return Ok();
        //}
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete(TagModel model)
        {
            await _tagData.DeleteAsync(model);
            return Ok();
        }
    }
}
