using EzBooking.Models;
using EzBooking.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EzBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserRepo _userRepo;

        public UserController(UserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            var users = _userRepo.GetUsers();

            if (users == null || users.Count == 0)
            {
                return NotFound("Nenhum utilizador encontrado."); //404
            }

            return Ok(users);
        }
    }
}
