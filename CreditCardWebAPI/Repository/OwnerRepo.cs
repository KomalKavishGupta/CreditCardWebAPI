using AutoMapper;
using CreditCardManagement.Models;
using CreditCardWebAPI.Context;
using CreditCardWebAPI.DTO;
using CreditCardWebAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace CreditCardWebAPI.Repository
{
    public class OwnerRepo : IOwnerReg
    {
        private readonly DataContext _dbContext;
        private readonly IMapper _mapper;
        public OwnerRepo(DataContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void AddCustomer(CustomerRegistration customer, int id)
        {
            try
            {
                OwnerRegisteration? oneOwner = _dbContext.OwnerReg.Find(id);
               
                 customer.uniqueId = oneOwner.hashId;
                _dbContext.CustReg.Add(customer);
                _dbContext.SaveChanges();



            }
            catch
            {
                throw;
            }
        }

        public void AddCustomerCredit(CreditDescription creditDetails, int id)
        {
            try
            {
                CustomerRegistration? customer= _dbContext.CustReg.Find(id);
                var creditAmount = customer.totalCreditAmount;

                creditDetails.customerId = customer.id;
                creditDetails.customerHash = customer.custUniqueId;
                _dbContext.CreditDesc.Add(creditDetails);
                _dbContext.SaveChanges();

                if(creditDetails.paidStatus == true) {
                    customer.totalCreditAmount = creditAmount - creditDetails.amount;
                }
                else
                {
                    customer.totalCreditAmount = creditAmount + creditDetails.amount;
                }
                //customer.totalCreditAmount = creditAmount + creditDetails.amount;
                _dbContext.CustReg.Update(customer);
                _dbContext.SaveChanges();


            }
            catch
            {
                throw;
            }
        }

        public void AddOwner(OwnerDTO owner)
        {
            try
            {
                var ownerDetails = _mapper.Map<OwnerDTO, OwnerRegisteration>(owner);
                ownerDetails.hashId = Guid.NewGuid();
                _dbContext.OwnerReg.Add(ownerDetails);
                _dbContext.SaveChanges();

            }
            catch
            {
                throw;
            }
        }

        public CustomerRegistration DeleteCustomer(int customerId)
        {
            try
            {
                CustomerRegistration? customer = _dbContext.CustReg.Where(c=> c.id == customerId).SingleOrDefault();
                if(customer != null)
                {
                    _dbContext.CustReg.Remove(customer);
                    _dbContext.SaveChanges();
                    return customer;
                }
                else
                {
                    throw new Exception("No Record Found!");
                }

            }
            catch {
                throw;
            }
        }

        public int GetCustomerCount(int ownerId)
        {
            try
            {
                var ownerUniqueId = _dbContext.OwnerReg.Find(ownerId);
                var totalCustomers =_dbContext.CustReg.Count(o => o.uniqueId == ownerUniqueId.hashId);
                return totalCustomers;

            }
            catch
            {
                throw new Exception("No entry!!");
            }
        }

        public List<CustRegDTO> GetCustomerDetails(int ownerId)
        {
            try
            {
                var ownerUniqueId = _dbContext.OwnerReg.Find(ownerId);

                if(ownerUniqueId != null)
                {
                    var FilteredContacts = _mapper.Map<List<CustomerRegistration>, List<CustRegDTO>>(_dbContext.CustReg.Where(o => o.uniqueId == ownerUniqueId.hashId).ToList());
                    return FilteredContacts;
                }
                else
                {
                    throw new ArgumentNullException(nameof(ownerId));
                }
               

            }
            catch
            {
                throw new Exception("No records Found.");
            }
        }

        public List<CustRegDTO> GetPendingCustomers(int ownerId)
        {
            try
            {
                var ownerUniqueId = _dbContext.OwnerReg.Find(ownerId);

                var pendingContacts = _mapper.Map<List<CustomerRegistration>, List<CustRegDTO>>(_dbContext.CustReg.Where(c => c.uniqueId == ownerUniqueId.hashId && c.totalCreditAmount > 0).ToList());
                
                return pendingContacts;

            }
            catch
            {
                throw new Exception("No records Found.");
            }
        }

        public int GetPendingCustomersCount(int ownerId)
        {
            try
            {
                var ownerUniqueId = _dbContext.OwnerReg.Find(ownerId);
                var customerCount = _dbContext.CustReg.Count(c=> c.uniqueId == ownerUniqueId.hashId &&  c.totalCreditAmount > 0);
                return customerCount;
            }
            catch
            {
                throw new Exception("No entry!!");

            }
            
        }

        public OwnerDTO GetUser(string email, string password)
        { 
            var loggedInOwner = _mapper.Map<OwnerRegisteration, OwnerDTO>(_dbContext.OwnerReg.FirstOrDefault(u => u.email == email && u.password == password));
            //return _dbContext.OwnerReg.FirstOrDefaultAsync(u => u.email == email && u.password == password);
            return loggedInOwner;
        }

        public bool UpdateContact(int customerId, customerContactDTO contact)
        {
            try
            {
                CustomerRegistration? customer = _dbContext.CustReg.Find(customerId);

                customer.contact = contact.contact;
              
                _dbContext.CustReg.Update(customer);
                _dbContext.SaveChanges();
                return true;
                //var ownerUniqueId = _dbContext.OwnerReg.Find(ownerId);

            }
            catch
            {
                return false;
            }
            throw new NotImplementedException();
        }


        //public bool UpdateCreditAmount(int customerId, decimal amount, bool borrowed)
        //{
        //    try
        //    {

        //    }
        //    catch
        //    {

        //    }
        //    throw new NotImplementedException();
        //}
    }
}
