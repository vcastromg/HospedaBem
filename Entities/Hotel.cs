namespace Domain.Entities;

public class Hotel: BaseEntity
{
    public Hotel() {}

    public Hotel(string name, string address, double latitude, double longitude, ICollection<Room> rooms)
    {
        Name = name;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
        Rooms = rooms;
    }

    public string Name { get; set; }
    public string Address { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    
    public virtual ICollection<Room> Rooms { get; set; }
}