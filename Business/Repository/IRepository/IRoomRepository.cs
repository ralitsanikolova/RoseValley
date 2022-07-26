using Models;

namespace Business.Repository.IRepository
{
    public interface IRoomRepository
    {
        public Task<RoomDTO> CreateRoom( RoomDTO roomDTO);
        public Task<RoomDTO> UpdateRoom(int roomId, RoomDTO roomDTO);
        public Task<RoomDTO> GetRoom(int roomId, string checkIn = null, string checkOut = null);
        public Task<int> DeleteRoom(int roomId);
        public Task<IEnumerable<RoomDTO>> GetAllRooms(string checkIn = null, string checkOut=null);

        //Ако нищо не се вклюв ID-tо да е сетнато на 0
        public Task<RoomDTO> IsRoomUnique(string name, int roomId=0 );

    }
}
