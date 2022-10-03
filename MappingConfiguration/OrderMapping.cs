using AutoMapper;
using Phantom.API.Model;
using Phantom.API.Model.ResponseOBJ;

namespace Phantom.API.MappingConfiguration
{
    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            CreateMap<Order, TrackRes>().ReverseMap();
        }
    }
}
