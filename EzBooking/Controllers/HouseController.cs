using EzBooking.Models;
using EzBooking.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EzBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : Controller
    {
        private readonly HouseRepo _houseRepo;

        public HouseController(HouseRepo houseRepo)
        {
            _houseRepo = houseRepo;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<House>> GetHouses()
        {
            var houses = _houseRepo.GetHouses();

            if (houses == null || houses.Count == 0)
            {
                return NotFound("Nenhuma casa encontrada."); //404
            }

            return Ok(houses);
        }
    }
}
