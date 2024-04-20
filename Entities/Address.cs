namespace Domain.Entities;

public class Address: BaseEntity
{
    public string PostalCode { get; set; }
    public string City { get; set; }
    public string AddressLine { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}