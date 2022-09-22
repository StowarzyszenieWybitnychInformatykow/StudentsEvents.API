using AutoMapper;
using StudentsEvents.API.Filtering;
using StudentsEvents.API.Models;
using StudentsEvents.Library.DBEntityModels;

namespace StudentsEvents.API.Services
{
    public class FilterService : IFilterService
    {
        private readonly IMapper _mapper;

        public FilterService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public IEnumerable<Event> GetSpecificData(IEnumerable<Event> events, FilterModel filter)
        {
            var specifications = GetSpecifications(filter);
            for (int i = 0; i < specifications.Count(); i++)
            {
                events = new Filter().Filtration(events, specifications[i]);
            }
            return events;
        }
        private List<ISpecification<Event>> GetSpecifications(FilterModel filter)
        {
            var specifications = new List<ISpecification<Event>>();
            if (filter?.TagsID != null)
                specifications.Add(new CategorySpecification(filter.TagsID));
            if (filter?.Citys != null || filter?.IsOnline != null)
                specifications.Add(new CitysSpecification(filter?.Citys, filter?.IsOnline));
            if (filter?.IsRegistration != null)
                specifications.Add(new RegistrationSpecification((bool)filter.IsRegistration));
            if (filter?.Start != null || filter?.End != null)
                specifications.Add(new TimeSpecification(filter.Start, filter.End));
            if (filter?.Text != null)
                specifications.Add(new TextSpecification(filter.Text.Split()));
            if (filter?.Tickets != null)
                specifications.Add(new TicketsSpecification((bool)filter.Tickets));

            return specifications;
        }
    }
}
