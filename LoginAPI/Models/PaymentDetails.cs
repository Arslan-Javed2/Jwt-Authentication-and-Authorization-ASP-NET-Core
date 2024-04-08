using System.ComponentModel.DataAnnotations;

namespace LoginAPI.Models
{
    public class PaymentDetails
    {
        [Key]
        public int PaymentDetailId { get; set; }
        public string CardOwnerName { get; set; } = "";
        public string CardNumber { get; set; } = "";
        public string ExpirationDate { get; set; } = "";
        public string SecurityCode { get; set; } = "";
    }
}
