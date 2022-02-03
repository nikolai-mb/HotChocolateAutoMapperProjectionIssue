namespace HotChocolateAutoMapperProjectionIssue.Entities;

public class Vehicle
{
    public int Id { get; set; }

    public Guid Guid { get; set; }

    public DateTime ManufactureDate { get; set; }

    public int DriverId { get; set; }
    public Driver Driver { get; set; } = default!;
}
