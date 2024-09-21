namespace SwDc20.Core.Domain.Entities;

public class BaseEntity
{
    public required Guid Id { get; init; } = Guid.NewGuid();
    public required string Version { get; init; }
}