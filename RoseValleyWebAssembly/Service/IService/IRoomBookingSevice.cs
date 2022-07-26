using Models;

namespace RoseValleyWebAssembly.Service.IService
{
    public interface IRoomBookingSevice
    {
        public Task<RoomBookingDTO> SaveBookingDetails(RoomBookingDTO bookingDetails);

        public Task<RoomBookingDTO> BookingVilla(RoomBookingDTO request);

    }
}
