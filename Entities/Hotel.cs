namespace Domain.Entities;

public class Hotel: BaseEntity
{
    public Hotel() {}

    public Hotel(string name, ICollection<Room> rooms)
    {
        Name = name;
        Rooms = rooms;
    }

    public string Name { get; set; }
    public double Rate { get; set; }
    
    public virtual Address Address { get; set; }
    public virtual ICollection<Room>? Rooms { get; set; }
}