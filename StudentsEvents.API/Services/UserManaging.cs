using StudentsEvents.Library.Data;
using StudentsEvents.Library.DBEntityModels;

namespace StudentsEvents.API.Services
{
    public class UserManaging : IUserManaging
    {
        private readonly IUserData _userData;

        public UserManaging(IUserData userData)
        {
            _userData = userData;
        }
        public async Task<IEnumerable<Role>> GetRoles(string userId)
        {
            return await _userData.GetUserRoles(userId);
        }
    }
}
