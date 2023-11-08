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
        //[HttpPost]
        //[ProducesResponseType(201)]
        //public IActionResult CreateHouse([FromBody] House house)
        //{
        //    if (house == null)
        //    {
        //        return BadRequest("Dados inválidos"); // Retorna 400 Bad Request se os dados forem inválidos
        //    }

        //    if (_houseRepo.CreateHouse(house))
        //    {
        //        return CreatedAtAction("CreateHouse", new { id = house.id_house }, house);
        //        // Retorna 201 Created e o objeto recém-criado
        //    }
        //    else
        //    {
        //        return BadRequest("Falha ao criar a casa"); // Retorna 400 Bad Request se a criação falhar
        //    }
        //}
    }
}
