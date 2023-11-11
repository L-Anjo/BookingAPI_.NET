using EzBooking.Models;
using EzBooking.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EzBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentStatesController : Controller
    {
        private readonly PaymentStateRepo _paymentStateRepo;

        public PaymentStatesController(PaymentStateRepo paymentStateRepo)
        {
            _paymentStateRepo = paymentStateRepo;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<PaymentStates>> GetPaymentStates()
        {
            var paymentStates = _paymentStateRepo.GetPaymentStates();

            if (paymentStates == null || paymentStates.Count == 0)
            {
                return NotFound("Nenhum estado de pagamento encontrado."); //404
            }

            return Ok(paymentStates);
        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePaymentStates([FromBody] PaymentStates paymentCreate)
        {
            if (paymentCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            bool created = _paymentStateRepo.CreatePaymentStates(paymentCreate);

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

        [HttpDelete("{paymentStatesId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeletePaymentStates(int paymentStatesId)
        {
            var paymentStatesToDelete = _paymentStateRepo.GetPaymentStates(paymentStatesId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_paymentStateRepo.DeletePaymentStates(paymentStatesToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting owner");
            }

            return NoContent();
        }

    }
}
