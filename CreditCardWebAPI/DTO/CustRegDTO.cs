using System.ComponentModel;

namespace CreditCardWebAPI.DTO
{
    public class CustRegDTO
    {
        public int id { get; set; }
        public string customerName { get; set; }
        public string contact { get; set; }
        public string address { get; set; }
        public decimal totalCreditAmount { get; set; }
        public Guid custUniqueId { get; set; }
    }
}
