using AutoMapper;
using Phantom.API.Model;
using Phantom.API.Model.Dto;

namespace Phantom.API.MappingConfiguration
{
    public class UserAccessMapping : Profile
    {
        public UserAccessMapping()
        {
            CreateMap<Customer, RegisterCustomerDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}
