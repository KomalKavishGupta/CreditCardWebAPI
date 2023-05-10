using CreditCardManagement.Models;
using CreditCardWebAPI.DTO;
using CreditCardWebAPI.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardWebAPI.Controllers
{
    //[Authorize]
    [EnableCors("AllowAngularOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerCreditController : ControllerBase
    {
        private readonly IOwnerReg _Iowner;
        public CustomerCreditController(IOwnerReg Iowner)
        {
            _Iowner = Iowner;
        }

        [HttpGet]
        [Route("{ownerId:int}")]
        public async Task<ActionResult<IEnumerable<CustRegDTO>>> GetCustomerDetails([FromRoute] int ownerId)
        {
            var allCustomers = await Task.FromResult(_Iowner.GetCustomerDetails(ownerId));
            return Ok(allCustomers);
        }
        [HttpGet]
        [Route("pendingCustomers/{ownerId:int}")]
        public async Task<ActionResult<IEnumerable<CustRegDTO>>> GetPendingCustomers([FromRoute] int ownerId)
        {
            var pendingCustomers = await Task.FromResult(_Iowner.GetPendingCustomers(ownerId));
            return Ok(pendingCustomers);
        }

        [HttpPost]
        [Route("addCustomer/{ownerId:int}")]
        public async Task<ActionResult<CustomerRegistration>> AddCustomer(CustomerRegistration customer, [FromRoute] int ownerId)
        {
            customer.custUniqueId = Guid.NewGuid();
            _Iowner.AddCustomer(customer, ownerId);
            //return Ok(emp);
            return await Task.FromResult(customer);
        }

        [HttpPost]
        [Route("addCustomerCredit/{customerId:int}")]
        public async Task<ActionResult<CreditDescription>> AddCustomerCredit(CreditDescription customerCredit, [FromRoute] int customerId)
        {
            _Iowner.AddCustomerCredit(customerCredit, customerId);
            //return Ok(emp);
            return await Task.FromResult(customerCredit);
        }

        [HttpPut]
        [Route("updateContact/{custId:int}")]
        public async Task<ActionResult<bool>> UpdateCustomerContact([FromRoute] int custId, customerContactDTO contact)
        {
            _Iowner.UpdateContact(custId, contact);
            return await Task.FromResult(true);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerRegistration>> DeleteCustomerById(int id)
        {
            var deletedCustomer = _Iowner.DeleteCustomer(id);
            return await Task.FromResult<CustomerRegistration>(deletedCustomer);
        }
    }
}
