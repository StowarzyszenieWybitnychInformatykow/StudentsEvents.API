using StudentsEvents.Library.DBEntityModels;

namespace StudentsEvents.API.Filtering
{
    public class RegistrationSpecification : ISpecification<Event>
    {
        private readonly bool _isRegistration;

        public RegistrationSpecification(bool isRegistration)
        {
            _isRegistration = isRegistration;
        }
        public bool IsSatisfied(Event entity)
        {
            if(entity.Registration == _isRegistration)
            {
                return true;
            }
            return false;
        }
    }
}
