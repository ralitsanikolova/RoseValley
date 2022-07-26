using AutoMapper;
using DataAccess.Data;
using Models;

namespace Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RoomDTO, Room>().ReverseMap();
            CreateMap<RoomImageDTO, RoomImage>().ReverseMap();
            CreateMap<AmenityDTO,Amenity>().ReverseMap(); 
            CreateMap<RoomBooking, RoomBooking>().ReverseMap();
        }
    }
}
