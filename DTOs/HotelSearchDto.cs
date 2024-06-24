namespace DTOs;

public class HotelSearchDto
{
    public DateTime? MininumDate { get; set; }
    public DateTime? MaximumDate { get; set; }
    public string? CityName { get; set; }
    public decimal? MinimumPrice { get; set; }
    public decimal? MaximumPrice { get; set; }
    public short? MinimumRate { get; set; }
}