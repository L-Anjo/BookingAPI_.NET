using EzBooking.Data;
using EzBooking.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

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

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool CreateUser(User user)
        {
            _context.Add(user);

            return Save();
        }


    }
}
