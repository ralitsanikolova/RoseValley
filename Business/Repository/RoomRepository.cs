using AutoMapper;
using Business.Repository.IRepository;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Business.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public RoomRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<RoomDTO> CreateRoom(RoomDTO roomDTO)
        {
            Room room = _mapper.Map<RoomDTO, Room>(roomDTO);

            room.CreatedDate_18118020 = DateTime.Now;
            room.CreatedBy = "";

            var addedRoom = await _db.Rooms.AddAsync(room);
            await _db.SaveChangesAsync();

            return _mapper.Map<Room, RoomDTO>(addedRoom.Entity);
        }

        public async Task<int> DeleteRoom(int roomId)
        {
            var detalsOfRoom = await _db.Rooms.FindAsync(roomId);
            if (detalsOfRoom != null)
            {
                var allImg = await _db.RoomsImages.Where(x => x.RoomId == roomId).ToListAsync();
                
                foreach(var image in allImg)
                {
                    if (File.Exists(image.ImageUrl))
                    {
                        File.Delete(image.ImageUrl);
                    }
                }
                // След като снимката е изтрита от директорията може да се махне от базата 

                _db.RoomsImages.RemoveRange(allImg);
                _db.Rooms.Remove(detalsOfRoom);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<RoomDTO>> GetAllRooms(string checkIn, string checkOut )
        {
           

            return _mapper.Map<IEnumerable<Room>, IEnumerable<RoomDTO>>(_db.Rooms
                .Include(x => x.Images)
                .ToList());

        }

        public async Task<RoomDTO> GetRoom(int roomId, string checkIn , string checkOut)
        {
            try
            {
                RoomDTO room = _mapper.Map<Room, RoomDTO>(
                    await _db.Rooms
                    .Include(x => x.Images)
                    //.Include(a => a.Amenities)
                    .FirstOrDefaultAsync(x => x.Id == roomId));

                return room;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<RoomDTO> IsRoomUnique(string name,int roomId=0 )
        {
            try
            {
                //Ако Ид е 0 Добавяме 
                if (roomId == 0)
                {

                    // Взимаме от базата данните и ги свързаме към DTO ,
                    // проверява се дали  името съответства и при спазване актуализира

                    RoomDTO room = _mapper.Map<Room, RoomDTO>(
                        await _db.Rooms.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower()));

                    return room;
                }

                //Ако iD-tp съществува се проверява дали няма съотвествие с друго
                else
                {
                    RoomDTO room = _mapper.Map<Room, RoomDTO>(
                       await _db.Rooms.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower()
                       && x.Id!= roomId));

                    return room;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<RoomDTO> UpdateRoom(int roomId, RoomDTO roomDTO)
        {
            try
            {
                if (roomId == roomDTO.Id)
                {
                    //If valid update room
                    Room detailsOfRoom = await _db.Rooms.FindAsync(roomId);

                    //Прехрвъля се от DTO към ROOM защото трябва да се прикачи към базата новата информация
                    Room room = _mapper.Map<RoomDTO, Room>(roomDTO, detailsOfRoom);

                    room.UpdatedDate_18118020 = DateTime.Now;
                    room.UpdatedBy = "";
                    
                    // updated е ентити ,затова се оставя като var
                    var updated = _db.Rooms.Update(room);

                    await _db.SaveChangesAsync();
                    return _mapper.Map<Room, RoomDTO>(updated.Entity);

                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
