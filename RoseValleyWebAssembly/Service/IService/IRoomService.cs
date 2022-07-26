using Models;

namespace RoseValleyWebAssembly.Service.IService
{
    public interface IRoomService
    {
        public Task<IEnumerable<RoomDTO>> GetRooms(string checkIn, string checkOut);
        public Task<RoomDTO> GetRoomDetail(int roomId, string checkIn, string checkOut);

    }
}
