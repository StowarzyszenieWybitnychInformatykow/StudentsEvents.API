using StudentsEvents.Library.DBEntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsEvents.Library.Data
{
    public class UserData : IUserData
    {
        private readonly StudentsEventsDataDbContext _context;

        public UserData(StudentsEventsDataDbContext context)
        {
            _context = context;
        }
        public async Task<IQueryable<Role>> GetUserRoles(string userId)
        {
            return _context.Users.Where(x => x.Id == userId)
                .Select(x => _context.Roles.Where(z => z.Id == x.RoleId)
                .Single());
        }
    }
}
