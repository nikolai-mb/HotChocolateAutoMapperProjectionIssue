namespace HotChocolateAutoMapperProjectionIssue.Dtos;

public class DriverDto
{
    public Guid Guid { get; set; }

    public string Name { get; set; } = default!;

    public ICollection<VehicleDto> Vehicles { get; set; } = default!;
}
