using EzBooking.Data;
using EzBooking.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace EzBooking.Repository
{
    public class UserRepo
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public UserRepo(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

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

        public User GetUserByEmail(string email)
        {
            return _context.Users.Where(p => p.email == email).FirstOrDefault();
        }

        public bool UpdateUser(User user)
        {
                _context.Update(user);
                return Save();
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        public string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.email)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims, 
                expires: DateTime.Now.AddDays(1), 
                signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

    }
}
