using StudentsEvents.Library.DBEntityModels;

namespace StudentsEvents.API.Filtering
{
    public class TextSpecification : ISpecification<Event>
    {
        private readonly string[] _text;

        public TextSpecification(string[] text)
        {
            _text = text;
        }
        public bool IsSatisfied(Event entity)
        {
            var result = true;
            foreach (var item in _text)
            {
                if (!entity.Name.ToLowerInvariant().Contains(item.ToLowerInvariant()) &&
                    !entity.ShortDescription.ToLowerInvariant().Contains(item.ToLowerInvariant()))
                {
                    return false;
                }
            }
            return result;
        }
    }
}
