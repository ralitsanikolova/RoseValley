using AutoMapper;
using Business.Repository.IRepository;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Business.Repository
{
    public class AmenityRepository : IAmenityRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public AmenityRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<AmenityDTO> CreateAmenity(AmenityDTO amenityDTO)
        {
            var amenity = _mapper.Map<AmenityDTO, Amenity>(amenityDTO);

            amenity.CreatedDate_18118020 = DateTime.Now;
            amenity.CreatedBy = "";

            var addedAmenity =  _db.Amenities.Add(amenity);
            await _db.SaveChangesAsync();

            return _mapper.Map<Amenity, AmenityDTO>(addedAmenity.Entity);
        }

        public async Task<int> DeleteAmenity(int amenityId)
        {
            var details = await _db.Amenities.FindAsync(amenityId);
            if (details != null)
            {
                _db.Amenities.Remove(details);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<AmenityDTO>> GetAllAmenities()
        {
            try
            {
                 IEnumerable<AmenityDTO> amenities =
                  _mapper.Map<IEnumerable<Amenity>, IEnumerable<AmenityDTO>>(await _db.Amenities.ToListAsync());

            return amenities;

            }
            catch (Exception ex)
            {
              return null;
            }
        }

        public async Task<AmenityDTO> GetAmenity(int amenityId)
        {
            try
            {
                AmenityDTO amenity = _mapper.Map<Amenity, AmenityDTO>(
                    await _db.Amenities.FirstOrDefaultAsync(x => x.Id == amenityId));

                return amenity;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<AmenityDTO> IsAmenityUnique(string name, int amenityId = 0)
        {
            try
            {
                if (amenityId == 0)
                {
                    AmenityDTO amenity = _mapper.Map<Amenity, AmenityDTO>(
                        await _db.Amenities.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower()));

                    return amenity;
                }
                else
                {
                    AmenityDTO amenity = _mapper.Map<Amenity, AmenityDTO>(
                        await _db.Amenities.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower() && x.Id != amenityId));

                    return amenity;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
            

        public async Task<AmenityDTO> UpdateAmenity(int amenityId, AmenityDTO amenityDTO)
        {

            try
            {
                if (amenityId  == amenityDTO.Id)
                {
                    //If valid update room
                    var details = await _db.Amenities.FindAsync(amenityId);

                    //Прехрвъля се от DTO към ROOM защото трябва да се прикачи към базата новата информация
                    var amenity = _mapper.Map<AmenityDTO, Amenity>(amenityDTO, details);

                    amenity.UpdatedDate_18118020 = DateTime.Now;
                    amenity.UpdatedBy = "";

                    // updated е ентити ,затова се оставя като var
                    var updated = _db.Amenities.Update(amenity);

                    await _db.SaveChangesAsync();
                    return _mapper.Map<Amenity, AmenityDTO>(updated.Entity);
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
