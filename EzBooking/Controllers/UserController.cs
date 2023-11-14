using EzBooking.Models;
using EzBooking.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using System.Text;

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
        [Authorize]
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

        [HttpGet("{userId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<User> GetUser(int userId)
        {
            var user = _userRepo.GetUser(userId);

            if (user == null)
            {
                return NotFound("User not found"); //404
            }

            return Ok(user);
        }



        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateUser([FromBody] User userCreate)
        {
            if (userCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var checkEmail = _userRepo.CheckEmail(userCreate.email);
            if (checkEmail == true)
            {
                ModelState.AddModelError("", "Email already exists");
                return StatusCode(422, ModelState);
            }

            // _userRepo.CreatePasswordHash(userCreate.password, out byte[] passwordHash, out byte[] passwordSalt);
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(userCreate.password);

            userCreate.password = hashedPassword;
            userCreate.status = 1;

            bool created = _userRepo.CreateUser(userCreate);

            if (created)
            {
                return Ok("Successfully created");
            }
            else
            {
                ModelState.AddModelError("Database", "Failed to save the user");
                return BadRequest(ModelState);
            }  
        }

        [HttpPut("{userId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateUser(int userId,
           [FromBody] User updatedUser)
        {

            var existingUser = _userRepo.GetUser(userId);

            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.name = updatedUser.name;
            existingUser.email = updatedUser.email;
            existingUser.password = updatedUser.password;
            existingUser.phone = updatedUser.phone;
            existingUser.token = updatedUser.token;
            existingUser.status = updatedUser.status;


            bool updated = _userRepo.UpdateUser(existingUser);

            if (updated)
            {
                return Ok("Successfully updated");
            }
            else
            {
                ModelState.AddModelError("", "Something went wrong updating owner");
                return StatusCode(500, ModelState);
            }
        }

        [HttpDelete("{userId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUser(int userId)
        {
            if (!_userRepo.UserExists(userId))
            {
                return NotFound();
            }

            var userToDelete = _userRepo.GetUser(userId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_userRepo.DeleteUser(userToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting owner");
            }

            return NoContent();
        }

    }
}
