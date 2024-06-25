namespace Domain.Entities;

public class Room: BaseEntity
{
    public ushort Number { get; set; }
    public ushort GuestsCapacity { get; set; }
    public bool IsAvailable { get; set; }
    public decimal Price { get; set; }
    public string Type { get; set; }
    public virtual Hotel Hotel { get; set; }
}