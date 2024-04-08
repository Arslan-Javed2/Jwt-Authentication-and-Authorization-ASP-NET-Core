using LoginAPI.Models;
using LoginAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace LoginAPI.Controllers
{
    [Route("api/[controller]")]//attribute routing
    [ApiController]
    public class PaymentDetailsAPIController : ControllerBase
    {
        private readonly IPaymentDetailsAPI _paymentDetailsAPI;

        public PaymentDetailsAPIController(IPaymentDetailsAPI paymentDetailsAPI)
        {
            _paymentDetailsAPI = paymentDetailsAPI;
        }

        [HttpGet("GetPaymentDetails")]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult<List<PaymentDetails>>> GetPaymentDetails()
        {

            var paymentDetails= await _paymentDetailsAPI.GetPaymentDetails();
            if(paymentDetails is null)
            {
                return NotFound();
            }
            if (paymentDetails.Value.Count == 0)
            {
                return NoContent();
            }
            return Ok(paymentDetails.Value);
            
        }

        [HttpPost("AddPaymentDetails")]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult<string>> AddPaymentDetails(PaymentDetails paymentDetails)
        {
            var result = await _paymentDetailsAPI.AddPaymentDetails(paymentDetails);
            if(result.Value!= "Payment Added Successfully")
            {
                return StatusCode(statusCode: 501);
            }
            return Ok(result.Value);
        }

        [HttpGet("GetPaymentDetailsById{id}")]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult<PaymentDetails>> GetPaymentDetailsById(int id)
        {
            var result=await _paymentDetailsAPI.GetPaymenteDetailsbyId(id);
            if(result is null)
            {
                return NotFound();
            }
            return Ok(result.Value);
        }
    }
}
