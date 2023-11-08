using EzBooking.Data;
using EzBooking.Models;

namespace EzBooking.Repository
{
    public class UserRepo
    {
        private readonly DataContext _context;
        public UserRepo(DataContext context)
        {
            _context = context;

        }
        public ICollection<User> GetUsers()
        {
            return _context.Users.OrderBy(u => u.id_user).ToList();
        }
    }
}
