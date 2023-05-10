using System.ComponentModel.DataAnnotations;

namespace CreditCardManagement.Models
{
    public class OwnerRegisteration
    {
        [Key]
        public int id { get; set; }
        public string businessName { get; set; }
        public string ownerName { get; set; }
        public Guid hashId { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string contact { get; set; }
        public string address { get; set; }

    }

    public class Jwt
    {
        public string key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }
    }

    public class ownerLogin
    {
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
