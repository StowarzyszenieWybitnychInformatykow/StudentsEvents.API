using StudentsEvents.Library.DBEntityModels;

namespace StudentsEvents.API.Services
{
    public interface IUserManaging
    {
        Task<IEnumerable<Role>> GetRoles(string userId);
    }
}