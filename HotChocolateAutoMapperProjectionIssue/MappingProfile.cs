using AutoMapper;
using HotChocolateAutoMapperProjectionIssue.Dtos;
using HotChocolateAutoMapperProjectionIssue.Entities;

namespace HotChocolateAutoMapperProjectionIssue;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Driver, DriverDto>().ForAllMembers(i => i.ExplicitExpansion());
        CreateMap<Vehicle, VehicleDto>().ForAllMembers(i => i.ExplicitExpansion());
    }
}
