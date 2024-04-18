namespace Domain;

public class Address: BaseEntity
{
    public string CEP { get; set; }
    public string Line1 { get; set; }
    public string City { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}