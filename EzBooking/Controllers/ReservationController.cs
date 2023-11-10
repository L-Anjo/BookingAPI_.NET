using EzBooking.Models;
using EzBooking.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EzBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : Controller
    {
        private readonly ReservationRepo _reservationRepo;
        private readonly HouseRepo _houseRepo;

        public ReservationController(ReservationRepo reservationRepo, HouseRepo houseRepo)
        {
            _houseRepo = houseRepo;
            _reservationRepo = reservationRepo;
            
            // FALTA ReservationStates
        }

        //GETS

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<Reservation>> GetReservations()
        {
            var reservations = _reservationRepo.GetReservations();

            if (reservations == null || reservations.Count == 0)
            {
                return NotFound("Nenhuma reserva encontrada."); //404
            }

            return Ok(reservations);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<House> GetReservationById(int id)
        {
            var reservation = _reservationRepo.GetReservationById(id);

            if (reservation == null)
            {
                return NotFound("Reserva não encontrada."); // Código 404 se a reserva não for encontrada.
            }

            if (id <= 0)
            {
                return BadRequest("ID inválido."); // Código 400 se o ID for inválido.
            }

            return Ok(reservation);
        }


        // RESERVA SUSP?? (?)


        //CREATES
        [HttpPost]
        [ProducesResponseType(201)]
        public IActionResult CreateReservation([FromBody] Reservation reservation)
        {
            if (reservation == null)
            {
                return BadRequest("Dados inválidos");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //FALTA ReservationStatus e User

            _reservationRepo.CreateReservation(reservation);

            return CreatedAtAction("CreateReservation", new { id = reservation.id_reservation }, reservation);

        }
    }
}