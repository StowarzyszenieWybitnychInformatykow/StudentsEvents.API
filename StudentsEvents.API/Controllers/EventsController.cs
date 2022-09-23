using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentsEvents.API.Models;
using StudentsEvents.API.Services;
using StudentsEvents.Library.DBEntityModels;
using System.Data;

namespace StudentsEvents.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventDataManaging _eventData;
        private readonly ILogger<EventsController> _logger;

        public EventsController(IEventDataManaging eventData, ILogger<EventsController> logger)
        {
            _eventData = eventData;
            _logger = logger;
        }

        //[HttpGet("GetAll")]
        //public async Task<IActionResult> GetAll([FromQuery] PagingModel paging, [FromQuery] FilterModel filter)
        //{
        //    var owners = await _eventData.GetAllAsync(paging, filter);
        //    var metadata = new
        //    {
        //        owners.TotalCount,
        //        owners.PageSize,
        //        owners.CurrentPage,
        //        owners.TotalPages,
        //        owners.HasNext,
        //        owners.HasPrevious
        //    };
        //    Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
        //    return Ok(owners);
        //}
        [HttpGet("GetPublishedPreview")]
        public async Task<IActionResult> GetPublishedPreview([FromQuery] PagingModel paging, [FromQuery] FilterModel filter)
        {
            var owners = await _eventData.GetPublishedPreviewAsync(paging, filter);
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

        [HttpGet("GetPublished")]
        public async Task<IActionResult> GetPublished([FromQuery] PagingModel paging, [FromQuery] FilterModel filter)
        {
            var owners = await _eventData.GetPublishedAsync(paging,filter);
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
        [HttpGet("GetUnfinished")]
        public async Task<IActionResult> GetUnfinished([FromQuery] PagingModel paging, [FromQuery] FilterModel filter)
        {
            var owners = await _eventData.GetUnfinishedAsync(paging, filter);
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
        [HttpGet("GetUnpublished")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUnpublished([FromQuery] PagingModel paging, [FromQuery] FilterModel filter)
        {
            var owners = await _eventData.GetUnpublishedAsync(paging, filter);
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
        [HttpGet("GetMy")]
        [Authorize]
        public async Task<IActionResult> GetMy([FromQuery] PagingModel paging, [FromQuery] FilterModel filter)
        {
            var userId = GetUserId();
            var owners = await _eventData.GetMyAsync(paging, filter, userId);
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
        [HttpGet("GetUpdated")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUpdatedAsync([FromQuery] PagingModel paging, [FromQuery] FilterModel filter)
        {
            var owners = await _eventData.GetUpdatedAsync(paging, filter);
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

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _eventData.GetByIdAsync(id));
        }

        [HttpPost("ApproveUpdatedEvent")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ApproveUpdatedEvent([FromQuery] Guid guid, [FromQuery] DateTimeOffset date)
        {
            await _eventData.ApproveUpdateEventAsync(guid, date);
            return Ok();
        }
        [HttpPost("DeleteUpdatedEvent")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUpdatedEvent([FromQuery] Guid guid, [FromQuery] DateTimeOffset date)
        {
            await _eventData.DeleteUpdateEventAsync(guid, date);
            return Ok();
        }
        [HttpPost("PublishEvent")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PublishEvent([FromBody] Guid id)
        {
            await _eventData.PublishEventAsync(id);
            return Ok();
        }
        [HttpPost("UnpublishEvent")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UnpublishEvent([FromBody] Guid id)
        {
            await _eventData.UnpublishEventAsync(id);
            return Ok();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] EventAddModel data)
        {
            var id = await _eventData.CreateAsync(data, GetUserId());
            return Ok(id);
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EventUpdateModel modified)
        {
            var model = await _eventData.GetByIdAsync(modified.Id);
            var userId = GetUserId();
            if (userId != model.OwnerID)
            {
                return Unauthorized("You are not the owner");
            }
            await _eventData.UpdateAsync(modified, userId);
            return Ok();
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await _eventData.GetByIdAsync(id);
            if (GetUserId() != model.OwnerID && User.Claims
                .Where(x => x.Type.Contains("role"))
                ?.FirstOrDefault()
                ?.Value != "Admin")
            {
                return Unauthorized("You are not the owner or admin");
            }
            await _eventData.DeleteAsync(id);
            return Ok();
        }
        private string GetUserId()
        {
            return User.Claims.Where(x => x.Type == "user_id").Single().Value;
        }
    }
}
