using Models;

namespace Business.Repository.IRepository
{
    public interface IRoomImageRepository
    {
        // Функцииите ще са създаване, изтриване и извличане

        public Task<int> CreateRoomImage(RoomImageDTO img);
        public Task<int> DeleteRoomImageByRoomID(int roomId);
        public Task<int> DeleteRoomImageByImageID(int imageId);
        public Task<int> DeleteRoomImageByImageUrl(string imageUrl);
        public Task<IEnumerable<RoomImageDTO>> GetAllRoomImages(int roomId);

    }
}
