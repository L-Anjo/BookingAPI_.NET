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
        private readonly PaymentStateRepo _paymentStateRepo;

        public PaymentController(PaymentRepo paymentRepo, PaymentStateRepo paymentStateRepo)
        {
            _paymentRepo = paymentRepo;
            _paymentStateRepo = paymentStateRepo;
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


            var existingState = _paymentStateRepo.GetPaymentState(paymentCreate.id_payment);
            if (existingState == null)
            {
                return NotFound("Estado do pagamento não existe");
            }

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


        [HttpPut("{paymentId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePayment(int paymentId,
           [FromBody] Payment updatedPayment)
        {

            var existingPayment = _paymentRepo.GetPayment(paymentId);

            if (existingPayment == null)
            {
                return NotFound();
            }

            existingPayment.paymentMethod = updatedPayment.paymentMethod;
            existingPayment.paymentDate = updatedPayment.paymentDate;
            existingPayment.paymentValue = updatedPayment.paymentValue;
            existingPayment.creationDate = updatedPayment.creationDate;
            existingPayment.state = updatedPayment.state;

            bool updated = _paymentRepo.UpdatePayment(existingPayment);

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

        [HttpDelete("{paymentId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeletePayment(int paymentId)
        {
            var paymentToDelete = _paymentRepo.GetPayment(paymentId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_paymentRepo.DeletePayment(paymentToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting owner");
            }

            return NoContent();
        }
    }
}
