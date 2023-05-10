using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace CreditCardManagement.Models
{
    public class CustomerRegistration
    {
        [Key]
        public int id { get; set; }
        public string customerName { get; set; }
        public string contact { get; set; }
        public string address { get; set; }
        public Guid uniqueId { get; set; }

        [DefaultValue(0)]
        public decimal totalCreditAmount { get; set; }
        public Guid custUniqueId { get; set; }
    }
}
