using CreditCardManagement.Models;
using CreditCardWebAPI.DTO;
using Microsoft.EntityFrameworkCore;

namespace CreditCardWebAPI.Interface
{
    public interface IOwnerReg
    {
        public void AddOwner(OwnerDTO owner);

        public void AddCustomer(CustomerRegistration customer, int ownerId);

        public void AddCustomerCredit(CreditDescription creditDetails, int customerId);

        public List<CustRegDTO> GetCustomerDetails(int ownerId);
        public int GetCustomerCount(int ownerId);
        public List<CustRegDTO> GetPendingCustomers(int ownerId);

        public int GetPendingCustomersCount(int ownerId);

        public CustomerRegistration DeleteCustomer(int customerId);
        public  OwnerDTO GetUser(string email, string password);

        public bool UpdateContact(int customerId, customerContactDTO contact);
    }
}
