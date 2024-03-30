namespace Domain.Entities;

public class Hotel: BaseEntity
{
    public string Name { get; set; }
    public string Address { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    
    public virtual ICollection<Room> Rooms { get; set; }
}