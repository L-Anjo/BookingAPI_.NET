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
        public async Task<ActionResult<IEnumerable<House>>> GetHouses()
        {
            var houses = await _houseRepo.GetHouses();

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
        public async Task<ActionResult<House>> GetHouseById(int id)
        {
            var house = await _houseRepo.GetHouseById(id);

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
        [ProducesResponseType(409)]
        public async Task<IActionResult> CreateHouse([FromBody] House house)
        {
            if (house == null)
            {
                return BadRequest("Dados inválidos");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (house.price != null && house.priceyear != null)
                return BadRequest("A casa so pode ter preço mensal ou anual");


            PostalCode existingPostalCode = _postalCodeRepo.GetPostalCodeById(house.PostalCode.postalCode);

            if (existingPostalCode!=null && _houseRepo.PostalCodePropertyExists(existingPostalCode.postalCode, house.propertyAssessment))
                return StatusCode(409, "Já Existe uma casa com esse artigo matricial nesse codigo postal");

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
            
            house.PostalCode = existingPostalCode;

            StatusHouse status = _statusHouseRepo.GetStatusHouseById(1);
            house.StatusHouse = status;

            await _houseRepo.CreateHouse(house);

            return CreatedAtAction("CreateHouse", new { id = house.id_house }, house);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateHouse(int id, [FromBody] House house)
        {
            if (house == null)
                return BadRequest(ModelState);

            if (!_houseRepo.HouseExists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            PostalCode existingPostalCode = _postalCodeRepo.GetPostalCodeById(house.PostalCode.postalCode);

            if (existingPostalCode != null && _houseRepo.PostalCodePropertyExists(existingPostalCode.postalCode, house.propertyAssessment))
                return StatusCode(409, "Já Existe uma casa com esse artigo matricial nesse codigo postal");

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

            StatusHouse status = _statusHouseRepo.GetStatusHouseById(1);
            var rhouse = await _houseRepo.GetHouseById(id);
            rhouse.name = house.name;
            rhouse.price = house.price;
            rhouse.priceyear = house.priceyear;
            rhouse.codDoor = house.codDoor;
            rhouse.floorNumber = house.floorNumber;
            rhouse.doorNumber = house.doorNumber;
            rhouse.ImageData = house.ImageData;
            rhouse.guestsNumber = house.guestsNumber;
            rhouse.propertyAssessment = house.propertyAssessment;
            rhouse.road = house.road;
            rhouse.sharedRoom = house.sharedRoom;
            rhouse.StatusHouse = status;
            rhouse.PostalCode = existingPostalCode;

            _houseRepo.UpdateHouse(rhouse);

            return Ok();
        }

        //DELETE
        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (!_houseRepo.HouseExists(id))
            {
                return NotFound();
            }

            var houseToDelete = await _houseRepo.GetHouseById(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_houseRepo.DeleteHouse(houseToDelete))
            {
                ModelState.AddModelError("", "Erro ao eliminar a Casa");
            }

            var responseMessage = $"A casa com o ID {id} foi eliminada com sucesso.";
            return Ok(responseMessage);
        }


    }
}
