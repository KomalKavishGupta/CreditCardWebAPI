using CreditCardManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CreditCardWebAPI.Context
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<OwnerRegisteration> OwnerReg { get; set; }

        public DbSet<CustomerRegistration> CustReg { get; set; }

        public DbSet<CreditDescription> CreditDesc { get; set; }
    }
}
