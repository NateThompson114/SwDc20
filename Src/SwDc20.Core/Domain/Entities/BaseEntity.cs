namespace SwDc20.Core.Domain.Entities;

public class BaseEntity
{
    public required Guid Id { get; set; } = Guid.NewGuid();
    public required string Version { get; set; }
}