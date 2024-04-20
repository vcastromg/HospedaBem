namespace DTOs;

public class RoomSearchDTO
{
    public DateTime MininumDate { get; set; }
    public DateTime MaximumDate { get; set; }
    public string CityName { get; set; }
    public double MinimumPrice { get; set; }
    public double MaximumPrice { get; set; }
    public short MinimumRate { get; set; }
}