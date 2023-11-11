using EzBooking.Models;
using EzBooking.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EzBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : Controller
    {
        private readonly PaymentRepo _paymentRepo;

        public PaymentController(PaymentRepo paymentRepo)
        {
            _paymentRepo = paymentRepo;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<Payment>> GetPayments()
        {
            var payments = _paymentRepo.GetPayments();

            if (payments == null || payments.Count == 0)
            {
                return NotFound("Nenhum pagamento encontrado."); //404
            }

            return Ok(payments);
        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePayment([FromBody] Payment paymentCreate)
        {
            if (paymentCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            bool created = _paymentRepo.CreatePayment(paymentCreate);

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

        [HttpGet("{paymentId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<Payment> GetPayment(int paymentId)
        {
            var payment = _paymentRepo.GetPayment(paymentId);

            if (payment == null)
            {
                return NotFound("Payment not found"); //404
            }

            return Ok(payment);
        }
    }
}
