namespace SwDc20.Core.Domain.Entities.Character;

public class TransferData
{
    public Guid ItemId { get; set; }
    public int Quantity { get; set; } = 1;
    public Guid? DestinationId { get; set; }
}