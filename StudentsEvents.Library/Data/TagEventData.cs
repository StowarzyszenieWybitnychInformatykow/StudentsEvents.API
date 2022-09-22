using StudentsEvents.Library.DbAccess;
using StudentsEvents.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudentsEvents.Library.Data
{
    public class TagEventData : ITagEventData
    {
        private readonly ISqlDataAccess _data;

        public TagEventData(ISqlDataAccess data)
        {
            _data = data;
        }
        public async Task AddTagsToUpdatedEvent(IEnumerable<TagDatabaseModel> tags, Guid EventId)
        {
            foreach (var item in tags)
            {
                await _data.SaveDataAsync("[dbo].[spEventTag_Add]", new { eventId = EventId, tagId = item.Id });
            }
        }
        public async Task<IEnumerable<TagDatabaseModel>> GetTagsByEventIdAsync(Guid id)
        {
            return await _data.LoadDataAsync<TagDatabaseModel, dynamic>("[dbo].[spTag_GetEventTags]", new { Id = id });
        }
    }
}
