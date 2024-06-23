namespace DTOs;


public class CreateHotelDTO
{
    public string Name { get; set; }
    public double Rate { get; set; }
    public string CoverImageUrl { get; set; }
    
    public string? PostalCode { get; set; }
    public string? City { get; set; }
    public string? AddressLine { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
}