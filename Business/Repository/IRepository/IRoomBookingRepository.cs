using Models;

namespace Business.Repository.IRepository
{
    public interface IRoomBookingRepository
    {
        public Task<RoomBookingDTO> CreateBooking (RoomBookingDTO bookingDetails);
        public Task<RoomBookingDTO> GetBooking  (int orderId);
        public Task<IEnumerable<RoomBookingDTO>> GetAllBookings();
        public Task<bool> IsItBooked(int roomId, DateTime checkIn, DateTime checkOut);

        public Task<int> DeleteBooking(int bookId);

    }
}
