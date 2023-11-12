using EzBooking.Models;
using EzBooking.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Cryptography;

namespace EzBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        public static User user = new User();
        //CREATES
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(User user)
        {
            CreatePasswordHash(user.password, out byte[] passwordHash);


            user.name = user.name;
            user.email = user.email;
            user.phone = user.phone;
            user.status = 1;
            user.passwordHash = passwordHash;

            return Ok(user);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }

}
