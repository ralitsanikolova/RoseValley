using Models;

namespace RoseValleyWebAssembly.Service.IService
{
    public interface IAmenityService
    {
        public Task<IEnumerable<AmenityDTO>> GetAllAmenities();
    }
}
