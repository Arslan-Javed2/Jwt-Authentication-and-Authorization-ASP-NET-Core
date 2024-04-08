using LoginAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoginAPI.Repositories.Interfaces
{
    public interface IPaymentDetailsAPI:IDisposable
    {
        Task<ActionResult<List<PaymentDetails>>> GetPaymentDetails();
        Task<ActionResult<PaymentDetails>> GetPaymenteDetailsbyId(int id);
        Task<ActionResult<string>> AddPaymentDetails(PaymentDetails paymentDetails);
    }
}
