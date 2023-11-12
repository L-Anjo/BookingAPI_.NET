using EzBooking.Models;
using EzBooking.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace EzBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : Controller
    {
        private readonly ReservationRepo _reservationRepo;
        private readonly ReservationStatesRepo _reservationStatesRepo;
        private readonly HouseRepo _houseRepo;
        private readonly UserRepo _userRepo;

        public ReservationController(ReservationRepo reservationRepo, ReservationStatesRepo reservationStatesRepo, HouseRepo houseRepo, UserRepo userRepo)
        {
            _reservationRepo = reservationRepo;
            _reservationStatesRepo = reservationStatesRepo;
            _houseRepo = houseRepo;
            _userRepo = userRepo;
        }

        //GETS

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<Reservation>> GetReservations()
        {
            var reservations = _reservationRepo.GetReservations(); // Use um método que já inclui as propriedades associadas

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
        public ActionResult<Reservation> GetReservationById(int id)
        {
            var reservation = _reservationRepo.GetReservationById(id);

            if (reservation == null)
            {
                return NotFound("Reserva não encontrada."); // Código 404 se a casa não for encontrada.
            }

            if (id <= 0)
            {
                return BadRequest("ID inválido."); // Código 400 se o ID for inválido.
            }

            return Ok(reservation);
        }


    }
}
