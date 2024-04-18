namespace Domain;

public class Hotel: BaseEntity
{
    public string Name { get; set; }
    public double Rate { get; set; }
    
    public virtual Address Address { get; set; }
    public virtual ICollection<Room> Rooms { get; set; }
}