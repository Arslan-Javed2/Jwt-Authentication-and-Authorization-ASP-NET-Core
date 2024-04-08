using LoginAPI.Data;
using LoginAPI.Models;
using LoginAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoginAPI.Repositories.Implementations
{
    public class PaymentDetailsAPIRepository : IPaymentDetailsAPI
    {
        private readonly MyDBContext _context;

        public PaymentDetailsAPIRepository(MyDBContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<string>> AddPaymentDetails(PaymentDetails paymentDetails)
        {
            await _context.PaymentDetails.AddAsync(paymentDetails);
            await _context.SaveChangesAsync();
            return "Payment Added Successfully";
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<ActionResult<List<PaymentDetails>>> GetPaymentDetails()
        {
            var paymentDetails = await _context.PaymentDetails.ToListAsync();
            return paymentDetails;
        }

        public async Task<ActionResult<PaymentDetails>> GetPaymenteDetailsbyId(int id)
        {
            var result = await _context.PaymentDetails.FindAsync(id);
            return result;
        }
    }
}
