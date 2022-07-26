using AutoMapper;
using Business.Repository.IRepository;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Business.Repository
{
    public class RoomImageRepository : IRoomImageRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public RoomImageRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<int> CreateRoomImage(RoomImageDTO img)
        {
            //convert DTO to image
            var roomImage = _mapper.Map<RoomImageDTO, RoomImage>(img);
            await _db.RoomsImages.AddAsync(roomImage);
            return await _db.SaveChangesAsync();
        }
        public async Task<int> DeleteRoomImageByImageUrl(string imageUrl)
        {
            var allImgs = await _db.RoomsImages.FirstOrDefaultAsync(room => room.ImageUrl.ToLower() == imageUrl.ToLower());
            _db.RoomsImages.Remove(allImgs);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteRoomImageByImageID(int imageId)
        {
            var roomImage = await _db.RoomsImages.FindAsync(imageId);
            _db.RoomsImages.Remove(roomImage);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteRoomImageByRoomID(int roomId)
        {
           var roomImage = await _db.RoomsImages.Where(img => img.RoomId == roomId).ToListAsync();
           _db.RoomsImages.RemoveRange(roomImage);
           return await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<RoomImageDTO>> GetAllRoomImages(int roomId)
        {
            return _mapper.Map<IEnumerable<RoomImage>, IEnumerable<RoomImageDTO>>(
            await _db.RoomsImages.Where(img => img.RoomId == roomId).ToListAsync());
        }
    }
}
