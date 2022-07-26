using Business.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace RoseValleyAPI.Controllers
{
    [Route("api/[controller]")]
    public class AmenityController : Controller
    {
        private readonly IAmenityRepository _amenityRepository;

        public AmenityController(IAmenityRepository amenityRepository)
        {
            _amenityRepository = amenityRepository;
        }

        [HttpGet]   
        public  async Task<IActionResult> GetAllAmenities()
        {
            var amenities = await _amenityRepository.GetAllAmenities();
            return Ok(amenities);
        }
    }
}
