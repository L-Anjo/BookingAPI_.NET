using EzBooking.Models;
using EzBooking.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace EzBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : Controller
    {
        private readonly HouseRepo _houseRepo;
        private readonly StatusHouseRepo _statusHouseRepo;
        private readonly PostalCodeRepo _postalCodeRepo;

        public HouseController(HouseRepo houseRepo, StatusHouseRepo statusHouseRepo, PostalCodeRepo postalCodeRepo)
        {
            _houseRepo = houseRepo;
            _statusHouseRepo = statusHouseRepo;
            _postalCodeRepo = postalCodeRepo;
        }

        //GETS

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

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<House> GetHouseById(int id)
        {
            var house = _houseRepo.GetHouseById(id);

            if (house == null)
            {
                return NotFound("Casa não encontrada."); // Código 404 se a casa não for encontrada.
            }

            if (id <= 0)
            {
                return BadRequest("ID inválido."); // Código 400 se o ID for inválido.
            }

            return Ok(house);
        }

        //Sera no User????
        [HttpGet("susp")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<House>> GetHousesSusp()
        {
            var houses = _houseRepo.GetHousesSusp();

            if (houses == null || houses.Count == 0)
            {
                return NotFound("Nenhuma casa encontrada."); //404
            }

            return Ok(houses);
        }

        //CREATES
        [HttpPost]
        [ProducesResponseType(201)]
        public IActionResult CreateHouse([FromBody] House house)
        {
            if (house == null)
            {
                return BadRequest("Dados inválidos");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PostalCode existingPostalCode = _postalCodeRepo.GetPostalCodeById(house.PostalCode.postalCode);

            if (existingPostalCode == null)
            {
                existingPostalCode = new PostalCode
                {
                    postalCode = house.PostalCode.postalCode,
                    concelho = house.PostalCode.concelho,
                    district = house.PostalCode.district,
                };
                _postalCodeRepo.CreatePostalCode(existingPostalCode);
            }
            
            //CASA NãO PODE TER MESMO CODIGO POSTAL E PROPERTY
            house.PostalCode = existingPostalCode;

            StatusHouse status = _statusHouseRepo.GetStatusHouseById(1);
            house.StatusHouse = status;

            _houseRepo.CreateHouse(house);

            return CreatedAtAction("CreateHouse", new { id = house.id_house }, house);
        }
        
    }
}
