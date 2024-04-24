namespace ValueObjects;

public class BookingPeriod
{
    public DateTime CheckInDate { get; }
    public DateTime CheckOutDate { get; }

    public BookingPeriod(DateTime checkInDate, DateTime checkOutDate)
    {
        if (checkInDate >= checkOutDate)
        {
            throw new ArgumentException("Check-in date must be before check-out date");
        }

        CheckInDate = checkInDate;
        CheckOutDate = checkOutDate;
    }   
}