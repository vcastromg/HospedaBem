using Domain;

namespace Application.Repositories
{
    public interface BookingRepository : BaseRepository<Booking>
    {
        public ICollection<Booking> GetBookingsByRoomId(long roomId);
    }
}
