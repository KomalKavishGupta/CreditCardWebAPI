using AutoMapper;
using CreditCardManagement.Models;
using CreditCardWebAPI.DTO;
using System.Runtime;

namespace CreditCardWebAPI
{
    public class MapperHelper : Profile
    {
        public MapperHelper() {
            CreateMap<CustomerRegistration, CustRegDTO>().ReverseMap();
            CreateMap<OwnerRegisteration, OwnerDTO>().ReverseMap();
        }
    }
}
