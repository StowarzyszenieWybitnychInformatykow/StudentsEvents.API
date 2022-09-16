using StudentsEvents.API.Models;
using StudentsEvents.Library.DbAccess;
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
        public async Task AddTagsToEvent(IEnumerable<TagDatabaseModel> tags, Guid EventId)
        {
            List<Task> tasks = new List<Task>();
            foreach (var item in tags)
            {
                tasks.Add(_data.SaveDataAsync("[dbo].[spEventTag_Add]", new { eventId = EventId, tagId = item.Id, NewEventTagId = 0 }));
            }
            await Task.WhenAll(tasks);
        }
        public async Task<IEnumerable<TagDatabaseModel>> GetTagsByEventIdAsync(Guid id)
        {
            return await _data.LoadDataAsync<TagDatabaseModel, dynamic>("[dbo].[spTag_GetEventTags]", new { Id = id });
        }
    }
}
