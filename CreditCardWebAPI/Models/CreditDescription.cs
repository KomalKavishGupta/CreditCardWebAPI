using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace CreditCardManagement.Models
{
    public class CreditDescription
    {
        [Key]
        public int id { get; set; }
        public int customerId { get; set; }
        public Guid customerHash { get; set; }
        public decimal amount { get; set; }
        public string description { get; set; }

        [DefaultValue(false)]
        public bool paidStatus { get; set; }
        public DateTime date { get; set; }

    }
}
