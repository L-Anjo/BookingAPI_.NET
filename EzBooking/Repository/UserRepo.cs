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
            return _context.Users.OrderBy(h => h.id_user).ToList();
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

        public bool CheckEmail(string email)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.email == email);
            return existingUser != null;
        }

        public bool UserExists(int userId)
        {
            return _context.Users.Any(p => p.id_user == userId);
        }

        public bool DeleteUser(User user)
        {
            _context.Remove(user);
            return Save();
        }

        public User GetUser(int userId)
        {
            return _context.Users.Where(p => p.id_user == userId).FirstOrDefault();
        }

        public bool UpdateUser(User user)
        {
            try
            {
                _context.Update(user);
                return Save();
            }
            catch (Exception ex)
            {
                // Log the exception or add debugging messages
                Console.WriteLine(ex.Message);
                return false; // or rethrow the exception for detailed analysis
            }

        }

    }
}
