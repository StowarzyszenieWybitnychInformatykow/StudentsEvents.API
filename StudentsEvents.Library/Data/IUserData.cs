using StudentsEvents.Library.DBEntityModels;

namespace StudentsEvents.Library.Data
{
    public interface IUserData
    {
        Task<IQueryable<Role>> GetUserRoles(string userId);
    }
}