namespace HotChocolateAutoMapperProjectionIssue.Entities;

public class Driver
{
    public int Id { get; set; }

    public Guid Guid { get; set; }

    public string Name { get; set; } = default!;

    public string LicenseNumber { get; set; } = default!;

    public ICollection<Vehicle> Vehicles { get; set; } = default!;
}
