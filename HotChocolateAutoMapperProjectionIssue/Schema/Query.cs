using HotChocolate.Resolvers;
using HotChocolateAutoMapperProjectionIssue.Dtos;
using HotChocolateAutoMapperProjectionIssue.Entities;
using HotChocolateAutoMapperProjectionIssue.Repository;

namespace HotChocolateAutoMapperProjectionIssue.Schema;

public class Query
{
    [UseDbContext(typeof(AutomobileRepository))]
    [UseProjection]
    [UseFiltering]
    public IQueryable<DriverDto> Drivers(
        [ScopedService] AutomobileRepository repository,
        IResolverContext context)
    {
        return repository.Drivers.ProjectTo<Driver, DriverDto>(context);
    }

    [UseDbContext(typeof(AutomobileRepository))]
    [UseProjection]
    public IQueryable<VehicleDto> Vehicles(
        [ScopedService] AutomobileRepository repository,
        IResolverContext context)
    {
        return repository.Vehicles.ProjectTo<Vehicle, VehicleDto>(context);
    }
}
